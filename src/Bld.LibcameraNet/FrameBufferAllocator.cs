﻿using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class FrameBufferAllocator
{
    private readonly IntPtr _allocatorPtr;
    private readonly HashSet<LibcameraStream> _allocatedStreams = new();

    public FrameBufferAllocator(Camera camera)
    {
        _allocatorPtr = LibcameraNative.FramebufferAllocatorCreate(camera.GetPtr());
    }

    public List<FrameBuffer> Alloc(LibcameraStream stream)
    {
        var ret = LibcameraNative.FramebufferAllocatorAllocate(_allocatorPtr, stream.GetPtr());
        if (ret < 0)
        {
            throw new Exception("Unable to allocate buffers");
        }

        _allocatedStreams.Add(stream);
        var buffersPtr = LibcameraNative.FramebufferAllocatorBuffers(_allocatorPtr, stream.GetPtr());
        var buffersCnt = LibcameraNative.FramebufferListSize(buffersPtr);
        var buffers = new List<FrameBuffer>();
        for (nuint i = 0; i < buffersCnt; i++)
        {
            // TODO: libcamera-rs have some hack. Need to research more
            var bufferPtr = LibcameraNative.FramebufferListGet(buffersPtr, i);
            var buffer = new FrameBuffer(bufferPtr);
            buffers.Add(buffer);
        }

        return buffers;
    }
}