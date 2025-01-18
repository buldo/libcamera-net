namespace Bld.LibcameraNet;

public class ControlList
{
    private readonly IntPtr _ctrlPtr;

    internal ControlList(IntPtr ctrlPtr)
    {
        _ctrlPtr = ctrlPtr;
    }

    internal IntPtr GetPtr()
    {
        return _ctrlPtr;
    }
}