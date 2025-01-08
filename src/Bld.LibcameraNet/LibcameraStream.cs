namespace Bld.LibcameraNet;

public class LibcameraStream
{
    private readonly IntPtr _streamPtr;

    public LibcameraStream(IntPtr streamPtr)
    {
        _streamPtr = streamPtr;
    }

    internal IntPtr GetPtr()
    {
        return _streamPtr;
    }
}