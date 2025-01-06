namespace Bld.LibcameraNet;

public class StreamConfiguration
{
    private readonly IntPtr _confPtr;

    internal StreamConfiguration(IntPtr confPtr)
    {
        _confPtr = confPtr;
    }
}