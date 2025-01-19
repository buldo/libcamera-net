namespace Bld.LibcameraNet;

public class MappedPlane
{
    public int fd { get; set; }
    public nuint offset { get; set; }
    public UInt64 len { get; set; }
}