namespace Bld.LibcameraNet.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating camera manager");
            using var cameraManager = new CameraManager();
            Console.WriteLine("Camera manager created");
        }
    }
}
