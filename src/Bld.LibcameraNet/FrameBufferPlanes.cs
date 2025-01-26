using System.Collections;
using Bld.LibcameraNet.Interop;
using LibcameraNative = Bld.LibcameraNet.Interop.Libcamera.LibcameraNative;

namespace Bld.LibcameraNet;

public class FrameBufferPlanes : IReadOnlyList<FrameBufferPlane>
{
    private readonly IntPtr _planesPtr;
    private readonly List<FrameBufferPlane> _planes = new();

    internal FrameBufferPlanes(IntPtr planesPtr)
    {
        _planesPtr = planesPtr;
        var planesCnt = LibcameraNative.FramebufferPlanesSize(_planesPtr);
        for (nuint i = 0; i < planesCnt; i++)
        {
            var planePtr = LibcameraNative.FramebufferPlanesAt(_planesPtr, i);
            var plane = new FrameBufferPlane(planePtr);
            _planes.Add(plane);
        }
    }

    public IEnumerator<FrameBufferPlane> GetEnumerator()
    {
        return _planes.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_planes).GetEnumerator();
    }

    public int Count => _planes.Count;

    public FrameBufferPlane this[int index] => _planes[index];
}