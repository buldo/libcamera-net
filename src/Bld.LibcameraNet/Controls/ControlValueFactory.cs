using Bld.LibcameraNet.Interop.Libcamera;

namespace Bld.LibcameraNet.Controls;

internal static class ControlValueFactory<TId> where TId: struct, Enum
{
    public static ControlValue<TId> Create(ControlValueDefinition<TId> definition)
    {
        return definition.Type switch
        {
            ControlType.ControlTypeNone => new ControlValue<TId>(definition),
            ControlType.ControlTypeBool => new ControlValue<TId>(definition),
            ControlType.ControlTypeByte => new ControlValue<TId>(definition),
            ControlType.ControlTypeInteger32 => new ControlValue<TId>(definition),
            ControlType.ControlTypeInteger64 => new ControlValue<TId>(definition),
            ControlType.ControlTypeFloat => new ControlValue<TId>(definition),
            ControlType.ControlTypeString => new StringControlValue<TId>(definition),
            ControlType.ControlTypeRectangle => new ControlValue<TId>(definition),
            ControlType.ControlTypeSize => new ControlValue<TId>(definition),
            ControlType.ControlTypePoint => new ControlValue<TId>(definition),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}