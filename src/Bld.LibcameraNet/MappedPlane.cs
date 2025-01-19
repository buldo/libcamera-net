namespace Bld.LibcameraNet;

public class MappedPlane
{
    public int fd { get; set; }
    public nuint offset { get; set; }
    public nuint len { get; set; }
}