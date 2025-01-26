using System.Reflection;
using System.Runtime.InteropServices;

using Bld.LibcameraNet.Interop;
using Bld.LibcameraNet.Interop.Libcamera;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;

namespace Bld.LibcameraNet.JpegCapture;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Only when LibcameraNet referenced as project
        NativeLibrary.SetDllImportResolver(typeof(CameraManager).Assembly, DllImportResolver);

        var filename = args.Length == 1? args[0] : DateTime.Now.Ticks + ".jpg";

        using var mgr = new CameraManager();
        mgr.Start();
        using var cameras = mgr.GetCameras();

        if (cameras.Count == 0)
        {
            throw new Exception("No cameras found");
        }
        var cam = cameras[0];
        var cameraModel = cam.Properties.Get<CameraModel>();
        Console.WriteLine($"Using camera: {cameraModel.Value}");

        cam.Acquire();

        // This will generate default configuration for each specified role
        using var cfgs = cam.GenerateConfiguration([StreamRole.StillCapture]);

        // Use MJPEG format so we can write resulting frame directly into jpeg file
        var streamConfiguration = cfgs.Get(0);
        var pixelFormats = streamConfiguration.StreamFormats.PixelFormats;
        Console.WriteLine("PixelFormats:");
        for (int i = 0; i < pixelFormats.Count; i++)
        {
            var format = pixelFormats[i];
            Console.WriteLine($"    {format.GetName()}");
        }

        Console.WriteLine($"Generated config: {cfgs}");

        streamConfiguration.PixelFormat = KnownPixelFormats.DRM_FORMAT_RGB888;
        var validationResult = cfgs.Validate();
        switch (validationResult)
        {
            case CameraConfigurationStatus.Valid:
                Console.WriteLine("Camera configuration valid!");
                break;
            case CameraConfigurationStatus.Adjusted:
                Console.WriteLine($"Camera configuration was adjusted: {cfgs}");
                break;
            case CameraConfigurationStatus.Invalid:
                throw new Exception("Error validating camera configuration");
        }

        var pixelFormatAfterConfig = streamConfiguration.PixelFormat;
        Console.WriteLine($"PixelFormat after config: {pixelFormatAfterConfig.GetName()}");
        if (pixelFormatAfterConfig != KnownPixelFormats.DRM_FORMAT_RGB888)
        {
            throw new Exception("RGB888 is not supported by the camera");
        }

        var size = streamConfiguration.Size;
        Console.WriteLine($"Size: {size.Width}x{size.Height}");

        var camConfigurationResult = cam.Configure(cfgs);
        if (camConfigurationResult < 0)
        {
            throw new Exception("Unable to configure camera");
        }

        var alloc = new FrameBufferAllocator(cam);

        // Allocate frame buffers for the stream
        var stream = streamConfiguration.GetStream();
        var buffers = alloc.Alloc(stream);
        Console.WriteLine($"Allocated {buffers.Count} buffers");

        // Convert FrameBuffer to MemoryMappedFrameBuffer, which allows reading &[u8]
        var mmBuffers = buffers
            .Select(b => new MemoryMappedFrameBuffer(b))
            .ToList();

        // Create capture requests and attach buffers
        var reqs = new List<Request>();
        foreach (var buf in mmBuffers)
        {
            var request = cam.CreateRequest();
            request.AddBuffer(stream, buf);
            reqs.Add(request);
        }

        // Completed capture requests are returned as a callback
        var channel = System.Threading.Channels.Channel.CreateUnbounded<Request>();
        var tx = channel.Writer;
        var rx = channel.Reader;
        cam.OnRequestCompleted(req => tx.TryWrite(req));

        cam.Start();

        // Multiple requests can be queued at a time, but for this example we just want a single frame.
        cam.QueueRequest(reqs.First());

        Console.WriteLine("Waiting for camera request execution");
        await rx.WaitToReadAsync();
        var req = await rx.ReadAsync();

        Console.WriteLine($"Camera request {req} completed!");
        Console.WriteLine($"Metadata: {req.Metadata}");

        // Get framebuffer for our stream
        var framebuffer = (MemoryMappedFrameBuffer)req.GetBuffer(stream);
        //Console.WriteLine($"FrameBuffer metadata: {framebuffer.Metadata}");

        // MJPEG format has only one data plane containing encoded jpeg data with all the headers
        var planes = framebuffer.GetData();
        var image = Image.LoadPixelData<Rgb24>(planes, 3280, 2464);
        image.Save("img.jpg", new JpegEncoder());
    }

    private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName.StartsWith("libcamera"))
        {
            return NativeLibrary.Load($"runtimes/linux-arm64/native/{LibcameraConsts.LibName}");
        }

        // Otherwise, fallback to default import resolver.
        return IntPtr.Zero;
    }
}