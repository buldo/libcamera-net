﻿using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class Request
{
    private readonly IntPtr _reqPtr;
    private readonly Dictionary<LibcameraStream, IAsFrameBuffer> _buffers;

    internal Request(IntPtr reqPtr)
    {
        _reqPtr = reqPtr;
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
}