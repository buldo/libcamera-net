using System.Runtime.InteropServices;

using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Interop;

public class CameraModel : StringControlValue, IProperty<CameraModel>
{
    public static PropertyId Id => PropertyId.MODEL;

    private CameraModel(ControlType type, int numElements, IntPtr dataPtr)
        : base(type, numElements, dataPtr)
    {
    }

    public static CameraModel Create(ControlType type, int numElements, IntPtr dataPtr)
    {
        return new CameraModel(type, numElements, dataPtr);
    }
}

public abstract class ControlValue<T>
{
    public T Value { get; protected set;}
}

public class StringControlValue : ControlValue<string>
{
    internal StringControlValue(ControlType type, int numElements, IntPtr dataPtr)
    {
        if (type != ControlType.ControlTypeString)
        {
            throw new TypeMismatchException();
        }

        Value = Marshal.PtrToStringAnsi(dataPtr, numElements);
    }
}

public class TypeMismatchException : Exception
{
    
}