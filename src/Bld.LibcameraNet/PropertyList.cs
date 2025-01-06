using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class PropertyList
{
    private readonly IntPtr _listPtr;

    internal PropertyList(IntPtr listPtr)
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
}

