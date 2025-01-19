using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

// TODO: Add dispose
public class Request
{
    private readonly IntPtr _reqPtr;
    private readonly Dictionary<LibcameraStream, IAsFrameBuffer> _buffers = new();

    internal Request(IntPtr reqPtr)
    {
        _reqPtr = reqPtr;
    }

    public UInt64 Cookie => LibcameraNative.RequestCookie(_reqPtr);

    public RequestStatus Status => LibcameraNative.RequestStatus(_reqPtr);

    public UInt32 Sequence => LibcameraNative.RequestSequence(_reqPtr);

    public ControlList Metadata
    {
        get
        {
            var ptr = LibcameraNative.RequestMetadata(_reqPtr);
            return new ControlList(ptr);
        }
    }

    public void AddBuffer<T>(LibcameraStream stream, T buffer) where T: IAsFrameBuffer
    {
        var ret = LibcameraNative.RequestAddBuffer(_reqPtr, stream.GetPtr(), buffer.AsFrameBuffer().GetPtr());
        if (ret < 0)
        {
            throw new Exception();
            //Err(io::Error::from_raw_os_error(ret))
        }
        else
        {
            _buffers.Add(stream, buffer);
        }
    }

    internal IntPtr GetPtr()
    {
        return _reqPtr;
    }

    public override string ToString()
    {
        return $"seq: {Sequence}; status: {Status}; cookie: {Cookie};";
    }
}