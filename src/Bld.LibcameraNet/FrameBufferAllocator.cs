using Bld.LibcameraNet.Interop;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

namespace Bld.LibcameraNet;

public class FrameBufferAllocator
{
    private readonly IntPtr _allocatorPtr;
    private readonly HashSet<LibcameraStream> _allocatedStreams = new();

    public FrameBufferAllocator(Camera camera)
    {
        _allocatorPtr = LibcameraNative.FramebufferAllocatorCreate(camera.GetPtr());
    }

    public List<LibcameraFrameBuffer> Alloc(LibcameraStream stream)
    {
        var ret = LibcameraNative.FramebufferAllocatorAllocate(_allocatorPtr, stream.GetPtr());
        if (ret < 0)
        {
            throw new Exception("Unable to allocate buffers");
        }

        _allocatedStreams.Add(stream);
        var buffersPtr = LibcameraNative.FramebufferAllocatorBuffers(_allocatorPtr, stream.GetPtr());
        var buffersCnt = LibcameraNative.FramebufferListSize(buffersPtr);
        var buffers = new List<LibcameraFrameBuffer>();
        for (nuint i = 0; i < buffersCnt; i++)
        {
            // TODO: libcamera-rs have some hack. Need to research more
            var bufferPtr = LibcameraNative.FramebufferListGet(buffersPtr, i);
            var buffer = new LibcameraFrameBuffer(bufferPtr);
            buffers.Add(buffer);
        }

        return buffers;
    }
}