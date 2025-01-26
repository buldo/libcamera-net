namespace Bld.LibcameraNet.Interop.Libcamera;

public enum ControlType : byte
{
    ControlTypeNone,
    ControlTypeBool,
    ControlTypeByte,
    ControlTypeInteger32,
    ControlTypeInteger64,
    ControlTypeFloat,
    ControlTypeString,
    ControlTypeRectangle,
    ControlTypeSize,
    ControlTypePoint,
};