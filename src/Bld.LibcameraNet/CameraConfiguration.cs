using Bld.LibcameraNet.Interop;
using Bld.LibcameraNet.Interop.Libcamera;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

namespace Bld.LibcameraNet;

public class CameraConfiguration : IDisposable
{
    private readonly IntPtr _cfgPtr;
    private bool _disposedValue;

    internal CameraConfiguration(IntPtr cfgPtr)
    {
        _cfgPtr = cfgPtr;
    }

    public StreamConfiguration Get(int index)
    {
        var confPtr = LibcameraNative.CameraConfigurationAt(_cfgPtr, index);
        return new StreamConfiguration(confPtr);
    }

    public CameraConfigurationStatus Validate()
    {
        return LibcameraNative.CameraConfigurationValidate(_cfgPtr);
    }

    internal IntPtr GetPtr()
    {
        return _cfgPtr;
    }

    #region Dispose
    ~CameraConfiguration() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // dispose managed state (managed objects)
            }

            // free unmanaged resources (unmanaged objects) and override finalizer
            LibcameraNative.CameraConfigurationDestroy(_cfgPtr);

            // set large fields to null
            _disposedValue = true;
        }
    }
    #endregion
}