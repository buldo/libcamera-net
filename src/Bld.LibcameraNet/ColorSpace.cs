namespace Bld.LibcameraNet;

public class ColorSpace
{
    private readonly string _name;

    internal ColorSpace(string name)
    {
        _name = name;
    }

    public static ColorSpace Raw { get; } = new ColorSpace(nameof(Raw));

    public static ColorSpace Srgb { get; } = new ColorSpace(nameof(Srgb));

    public static ColorSpace Sycc { get; } = new ColorSpace(nameof(Sycc));

    public static ColorSpace Smpte170m { get; } = new ColorSpace(nameof(Smpte170m));

    public static ColorSpace Rec709 { get; } = new ColorSpace(nameof(Rec709));

    public static ColorSpace Rec2020 { get; } = new ColorSpace(nameof(Rec2020));

    public static ColorSpace Unknown { get; } = new ColorSpace(nameof(Unknown));

    internal static ColorSpace? FromShimValue(byte value)
    {
        switch (value)
        {
            case 0: return null;
            case 1: return Raw;
            case 2: return Srgb;
            case 3: return Sycc;
            case 4: return Smpte170m;
            case 5: return Rec709;
            case 6: return Rec2020;
            default: return Unknown;
        }
    }

    public override string ToString()
    {
        return _name;
    }
}