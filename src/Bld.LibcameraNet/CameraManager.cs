using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class CameraManager : IDisposable
{
    private bool _disposedValue;
    private readonly IntPtr _nativeCameraManager;

    public CameraManager()
    {
        _nativeCameraManager = LibcameraNative.CameraManagerCreate();
    }

    public nint Start()
    {
        return LibcameraNative.CameraManagerStart(_nativeCameraManager);
    }

    public void Stop()
    {
        LibcameraNative.CameraManagerStop(_nativeCameraManager);
    }

    public CameraList GetCameras()
    {
        var cameraListPtr = LibcameraNative.CameraManagerCameras(_nativeCameraManager);
        return new CameraList(cameraListPtr);
    }

    #region Dispose
    ~CameraManager() => Dispose(false);

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
            LibcameraNative.CameraManagerDestroy(_nativeCameraManager);

            // set large fields to null
            _disposedValue = true;
        }
    }
    #endregion
}