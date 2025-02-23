using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet;

public class LibcameraFrameBuffer
{
    private readonly IntPtr _bufferPtr;

    internal LibcameraFrameBuffer(IntPtr bufferPtr)
    {
        _bufferPtr = bufferPtr;
    }

    public FrameBufferPlanes GetPlanes()
    {
        var ptr = LibcameraNative.FramebufferPlanes(_bufferPtr);
        return new FrameBufferPlanes(ptr);
    }

    internal IntPtr GetPtr()
    {
        return _bufferPtr;
    }
}