using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace MW5HOTAS
{
    class Program
    {
        public static DirectInput DiInstance = new DirectInput();
        private static readonly List<string> _foundDevices = new List<string>();
        private static string _settingsFileName = "HOTASMappings.Remap";

        static void Main(string[] args)
        {
            var diDeviceInstances = DiInstance.GetDevices();

            var remapText = string.Empty;
            Console.WriteLine("Looking for devices...\n");
            foreach (var device in diDeviceInstances)
            {
                if (!IsStickType(device)) continue;
                var joystick = new Joystick(DiInstance, device.InstanceGuid);
                var vidpid = $"VID 0x{joystick.Properties.VendorId:x4}, PID 0x{joystick.Properties.ProductId:X4}";
                if (vidpid == "VID 0x1234, PID 0xBEAD") continue;
                if (_foundDevices.Contains(vidpid)) continue;
                Console.WriteLine($"{joystick.Properties.ProductName} - {vidpid}");
                _foundDevices.Add(vidpid);
                remapText += BuildText(joystick);
            }

            remapText += File.ReadAllText("Base.txt");
            File.WriteAllText(_settingsFileName, remapText);

            Console.WriteLine($"\nDone\nCreated settings file {_settingsFileName}\n\nPress ENTER to exit");
            Console.ReadLine();

        }

        public static bool IsStickType(DeviceInstance deviceInstance)
        {
            return deviceInstance.Type == DeviceType.Joystick
                   || deviceInstance.Type == DeviceType.Gamepad
                   || deviceInstance.Type == DeviceType.FirstPerson
                   || deviceInstance.Type == DeviceType.Flight
                   || deviceInstance.Type == DeviceType.Driving
                   || deviceInstance.Type == DeviceType.Supplemental;
        }

        private static string BuildText(Joystick joystick)
        {
            return $"START_BIND\n" +
                   $"NAME: {joystick.Properties.ProductName}\n" +
                   $"VID: 0x{joystick.Properties.VendorId:X4}\n" +
                   $"PID: 0x{joystick.Properties.ProductId:X4}\n\n";
        }

    }
}
