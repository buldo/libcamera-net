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

public class BoolControlValue<TIdEnum>
    : ControlValue<TIdEnum, bool> where TIdEnum : struct, Enum
{
    public BoolControlValue(ControlValueDefinition<TIdEnum> definition)
        : base(definition)
    {
        var dataPtr = LibcameraNative.ControlValueGet(definition.ValuePtr);
        Value = Marshal.ReadByte(dataPtr) != 0;
    }
}

public class ByteControlValue<TIdEnum>
    : ControlValue<TIdEnum, byte> where TIdEnum : struct, Enum
{
    public ByteControlValue(ControlValueDefinition<TIdEnum> definition)
        : base(definition)
    {
        var dataPtr = LibcameraNative.ControlValueGet(definition.ValuePtr);
        Value = Marshal.ReadByte(dataPtr);
    }
}

public class Integer32ControlValue<TIdEnum>
    : ControlValue<TIdEnum, Int32> where TIdEnum : struct, Enum
{
    public Integer32ControlValue(ControlValueDefinition<TIdEnum> definition)
        : base(definition)
    {
        var dataPtr = LibcameraNative.ControlValueGet(definition.ValuePtr);
        Value = Marshal.ReadInt32(dataPtr);
    }
}

public class Integer64ControlValue<TIdEnum>
    : ControlValue<TIdEnum, Int64> where TIdEnum : struct, Enum
{
    public Integer64ControlValue(ControlValueDefinition<TIdEnum> definition)
        : base(definition)
    {
        var dataPtr = LibcameraNative.ControlValueGet(definition.ValuePtr);
        Value = Marshal.ReadInt32(dataPtr);
    }
}

public class FloatControlValue<TIdEnum>
    : ControlValue<TIdEnum, float> where TIdEnum : struct, Enum
{
    public FloatControlValue(ControlValueDefinition<TIdEnum> definition)
        : base(definition)
    {
        var dataPtr = LibcameraNative.ControlValueGet(definition.ValuePtr);
        // TODO
        Value = 0;
    }
}