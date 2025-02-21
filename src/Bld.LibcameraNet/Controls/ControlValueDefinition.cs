using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Controls;

public class ControlValueDefinition<TIdEnum> where TIdEnum: Enum
{
    public ControlValueDefinition(TIdEnum id, IntPtr valuePtr)
    {
        Id = id;
        ValuePtr = valuePtr;
    }

    public TIdEnum Id { get; }

    internal IntPtr ValuePtr { get; }

    public ControlType Type => LibcameraNative.ControlValueType(ValuePtr);

    public int NumElements => (int)LibcameraNative.ControlValueNumElements(ValuePtr);
}