using System.Runtime.InteropServices;

using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Controls;

public class ControlValue<TId> where TId : struct, Enum
{
    protected readonly ControlValueDefinition<TId> _definition;

    public ControlValue(ControlValueDefinition<TId> definition)
    {
        _definition = definition;
    }

    public TId Id => _definition.Id;
}

public class ControlValue<TId, TValue>
    : ControlValue<TId> where TId : struct, Enum
{
    protected ControlValue(ControlValueDefinition<TId> definition)
        : base(definition)
    {

    }

    public TValue Value { get; protected set; }
}

public class StringControlValue<TIdEnum>
    : ControlValue<TIdEnum, string> where TIdEnum : struct,Enum
{
    public StringControlValue(ControlValueDefinition<TIdEnum> definition)
        : base(definition)
    {
        var dataPtr = LibcameraNative.ControlValueGet(definition.ValuePtr);
        Value = Marshal.PtrToStringAnsi(dataPtr, definition.NumElements);
    }
}