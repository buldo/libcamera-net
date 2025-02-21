using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Controls;

internal static class ControlValueFactory<TId> where TId: struct, Enum
{
    public static ControlValue<TId> Create(ControlValueDefinition<TId> definition)
    {
        return definition.Type switch
        {
            ControlType.ControlTypeNone => new ControlValue<TId>(definition),
            ControlType.ControlTypeBool => new BoolControlValue<TId>(definition),
            ControlType.ControlTypeByte => new ByteControlValue<TId>(definition),
            ControlType.ControlTypeInteger32 => new Integer32ControlValue<TId>(definition),
            ControlType.ControlTypeInteger64 => new Integer64ControlValue<TId>(definition),
            ControlType.ControlTypeFloat => new FloatControlValue<TId>(definition),
            ControlType.ControlTypeString => new StringControlValue<TId>(definition),
            ControlType.ControlTypeRectangle => new ControlValue<TId>(definition),
            ControlType.ControlTypeSize => new ControlValue<TId>(definition),
            ControlType.ControlTypePoint => new ControlValue<TId>(definition),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}