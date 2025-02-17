﻿using Bld.LibcameraNet.Interop;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

namespace Bld.LibcameraNet;

public class FrameBuffer
{
    private readonly IntPtr _bufferPtr;

    internal FrameBuffer(IntPtr bufferPtr)
    {
        _bufferPtr = bufferPtr;
    }

    public FrameBufferPlanes GetPlanes()
    {
        var ptr = LibcameraNative.FramebufferPlanes(_bufferPtr);
        return new FrameBufferPlanes(ptr);
    }

    internal IntPtr GetPtr()
    {
        return _bufferPtr;
    }
}