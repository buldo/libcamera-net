using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet;

public class ControlList
{
    private readonly IntPtr _listPtr;

    internal ControlList(IntPtr listPtr)
    {
        _listPtr = listPtr;
    }

    public T? Get<T>() where T : class, IProperty<T>
    {
        var controlPtr = LibcameraNative.ControlListGet(_listPtr, (int)T.Id);
        if (controlPtr == IntPtr.Zero)
        {
            return null;
        }

        var ty = LibcameraNative.ControlValueType(controlPtr);
        var numElements = LibcameraNative.ControlValueNumElements(controlPtr);
        var data = LibcameraNative.ControlValueGet(controlPtr);

        return T.Create(ty, (int)numElements, data);
    }

    internal IntPtr GetPtr()
    {
        return _listPtr;
    }
}

