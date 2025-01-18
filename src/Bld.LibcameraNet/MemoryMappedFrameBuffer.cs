namespace Bld.LibcameraNet;

public class MemoryMappedFrameBuffer : IAsFrameBuffer
{
    private readonly FrameBuffer _frameBuffer;

    public MemoryMappedFrameBuffer(FrameBuffer frameBuffer)
    {
        _frameBuffer = frameBuffer;
        throw new NotImplementedException();
    }

    public FrameBuffer AsFrameBuffer()
    {
        return _frameBuffer;
    }
}