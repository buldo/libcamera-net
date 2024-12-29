using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class CameraList : IDisposable
{
    private readonly IntPtr _listPtr;
    private readonly Camera?[] _cameras;
    private bool _disposedValue;

    internal CameraList(IntPtr listPtr)
    {
        _listPtr = listPtr;
        Count = (int)LibcameraNative.CameraListSize(_listPtr);
        _cameras = new Camera[Count];
    }

    public int Count { get; }


    public Camera this[int index]
    {
        get
        {
            if (_cameras[index] == null)
            {
                var camera = LibcameraNative.CameraListGet(_listPtr, index);
                _cameras[index] = new Camera(camera);
            }

            return _cameras[index]!;
        }
    }

    #region Dispose
    ~CameraList() => Dispose(false);

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
            LibcameraNative.CameraListDestroy(_listPtr);

            // set large fields to null
            _disposedValue = true;
        }
    }
    #endregion
}