using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public interface IProperty<T>
{
    static abstract PropertyId Id { get; }

    static abstract T Create(ControlType type, int numElements, IntPtr dataPtr);
}