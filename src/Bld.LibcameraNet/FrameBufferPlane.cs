using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet;

public class FrameBufferPlane
{
    private readonly IntPtr _planePtr;

    internal FrameBufferPlane(IntPtr planePtr)
    {
        _planePtr = planePtr;
    }

    public int Fd => LibcameraNative.FramebufferPlaneFd(_planePtr);

    public nuint? Offset
    {
        get
        {
            var isValid = LibcameraNative.FramebufferPlaneOffsetValid(_planePtr);
            if(isValid)
            {
                return LibcameraNative.FramebufferPlaneOffset(_planePtr);
            }
            else
            {
                return null;
            }
        }
    }

    public nuint Length => LibcameraNative.FramebufferPlaneLength(_planePtr);
}