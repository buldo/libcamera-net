﻿using Bld.LibcameraNet.Interop;
using Bld.LibcameraNet.Interop.Libcamera;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

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

    internal IntPtr GetPtr()
    {
        return _reqPtr;
    }

    public ControlList<ControlId> GetMetadata()
    {
        var ptr = LibcameraNative.RequestMetadata(_reqPtr);
        return new ControlList<ControlId>(ptr);
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

    public override string ToString()
    {
        return $"seq: {Sequence}; status: {Status}; cookie: {Cookie};";
    }

    public IAsFrameBuffer GetBuffer(LibcameraStream stream)
    {
        return _buffers[stream];
    }
}