using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet;

public class LibcameraStream
{
    private readonly IntPtr _streamPtr;

    public LibcameraStream(IntPtr streamPtr)
    {
        _streamPtr = streamPtr;
    }

    public StreamConfiguration Configuration
    {
        get
        {
            var configurationPtr = LibcameraNative.StreamGetConfiguration(_streamPtr);
            return new StreamConfiguration(configurationPtr);
        }
    }

    internal IntPtr GetPtr()
    {
        return _streamPtr;
    }
}