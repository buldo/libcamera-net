namespace Bld.LibcameraNet;

public class FrameBuffer
{
    private readonly IntPtr _bufferPtr;

    internal FrameBuffer(IntPtr bufferPtr)
    {
        _bufferPtr = bufferPtr;
    }

    internal IntPtr GetPtr()
    {
        return _bufferPtr;
    }
}