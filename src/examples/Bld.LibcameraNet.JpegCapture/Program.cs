using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using Bld.LibcameraNet.Interop;


namespace Bld.LibcameraNet.JpegCapture;

internal class Program
{
    // TODO: RIGHT format
    private static PixelFormat PIXEL_FORMAT_MJPEG = new PixelFormat();

    static void Main(string[] args)
    {
        // Only when LibcameraNet referenced as project
        NativeLibrary.SetDllImportResolver(typeof(CameraManager).Assembly, DllImportResolver);

        var filename = args.Length == 1? args[0] : DateTime.Now.Ticks + ".jpg";

        using var mgr = new CameraManager();
        using var cameras = mgr.GetCameras();

        if (cameras.Count == 0)
        {
            throw new Exception("No cameras found");
        }
        var cam = cameras[0];
        var cameraModel = cam.Properties.Get<CameraModel>();
        Console.WriteLine($"Using camera: {cameraModel}");

        var acqResult = cam.Acquire();
        if (acqResult < 0)
        {
            throw new Exception("No cameras found");
        }

        // This will generate default configuration for each specified role
        using var cfgs = cam.GenerateConfiguration([StreamRole.Viewfinder]);

        // Use MJPEG format so we can write resulting frame directly into jpeg file
        var streamConfiguration = cfgs.Get(0);
        streamConfiguration.PixelFormat = PIXEL_FORMAT_MJPEG;

        Console.WriteLine($"Generated config: {cfgs}");

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

        // Ensure that pixel format was unchanged
        //    assert_eq!(
        //        cfgs.get(0).unwrap().get_pixel_format(),
        //        PIXEL_FORMAT_MJPEG,
        //        "MJPEG is not supported by the camera"
        //    );

        //    cam.configure(&mut cfgs).expect("Unable to configure camera");

        //    let mut alloc = FrameBufferAllocator::new(&cam);

        //    // Allocate frame buffers for the stream
        //    let cfg = cfgs.get(0).unwrap();
        //    let stream = cfg.stream().unwrap();
        //    let buffers = alloc.alloc(&stream).unwrap();
        //    println!("Allocated {} buffers", buffers.len());

        //    // Convert FrameBuffer to MemoryMappedFrameBuffer, which allows reading &[u8]
        //    let buffers = buffers
        //        .into_iter()
        //        .map(| buf | MemoryMappedFrameBuffer::new(buf).unwrap())
        //        .collect::< Vec < _ >> ();

        //    // Create capture requests and attach buffers
        //    let mut reqs = buffers
        //        .into_iter()
        //        .map(| buf | {
        //        let mut req = cam.create_request(None).unwrap();
        //        req.add_buffer(&stream, buf).unwrap();
        //        req
        //        })
        //    .collect::< Vec < _ >> ();

        //    // Completed capture requests are returned as a callback
        //    let(tx, rx) = std::sync::mpsc::channel();
        //    cam.on_request_completed(move | req | {
        //        tx.send(req).unwrap();
        //    });

        //    cam.start(None).unwrap();

        //    // Multiple requests can be queued at a time, but for this example we just want a single frame.
        //    cam.queue_request(reqs.pop().unwrap()).unwrap();

        //    println!("Waiting for camera request execution");
        //    let req = rx.recv_timeout(Duration::from_secs(2)).expect("Camera request failed");

        //    println!("Camera request {:?} completed!", req);
        //    println!("Metadata: {:#?}", req.metadata());

        //    // Get framebuffer for our stream
        //    let framebuffer: &MemoryMappedFrameBuffer < FrameBuffer > = req.buffer(&stream).unwrap();
        //    println!("FrameBuffer metadata: {:#?}", framebuffer.metadata());

        //    // MJPEG format has only one data plane containing encoded jpeg data with all the headers
        //    let planes = framebuffer.data();
        //    let jpeg_data = planes.get(0).unwrap();
        //    // Actual JPEG-encoded data will be smalled than framebuffer size, its length can be obtained from metadata.
        //    let jpeg_len = framebuffer.metadata().unwrap().planes().get(0).unwrap().bytes_used as usize;

        //    std::fs::write(&filename, &jpeg_data[..jpeg_len]).unwrap();
        //    println!("Written {} bytes to {}", jpeg_len, &filename);

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