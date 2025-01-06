using System.Reflection;
using System.Runtime.InteropServices;
using Bld.LibcameraNet.Interop;

namespace Bld.LibcameraNet.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NativeLibrary.SetDllImportResolver(typeof(CameraManager).Assembly, DllImportResolver);
            Console.WriteLine("Creating camera manager");
            using var cameraManager = new CameraManager();
            Console.WriteLine("Camera manager created");
            
            cameraManager.Start();
            Console.WriteLine("Camera manager started");

            using var cameraList = cameraManager.GetCameras();
            Console.WriteLine($"Found {cameraList.Count} cameras");
        }
        
        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName.StartsWith("libcamera"))
            {
                return NativeLibrary.Load($"runtimes/linux-arm64/native/{LibcameraConsts.LibName}");
            }

            // Otherwise, fallback to default import resolver.
            return IntPtr.Zero;
        }
    }
}
