using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DcRat.Properties;
using MaxMind.GeoIP2;
using static DcRat.Helper.RegistrySeeker;

namespace DcRat.Helper
{
    public class Helper
    {
        public static DatabaseReader reader = new DatabaseReader(new MemoryStream(Resources.GeoLite2_City));

        public class Aes
        {
            private static byte[] keyArray = Encoding.UTF8.GetBytes("DcRat_qwqdanchun");

            public static byte[] Encrypt(byte[] toEncryptArray)
            {
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return resultArray;
            }

            public static byte[] Decrypt(byte[] toEncryptArray)
            {
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return resultArray;
            }
        }
        public static byte[] Xor(byte[] buffer, string xorKey)
        {
            char[] key = xorKey.ToCharArray();
            byte[] newByte = new byte[buffer.Length];

            int j = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (j == key.Length)
                {
                    j = 0;
                }
                newByte[i] = (byte)(buffer[i] ^ Convert.ToByte(key[j]));
                j++;
            }
            return newByte;
        }

        public static string Map_ip(string ip)
        {
            try
            {
                if (Regex.IsMatch(ip, @"(^192\.168\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])$)|(^172\.([1][6-9]|[2][0-9]|[3][0-1])\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])$)|(^10\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])\.([0-9]|[0-9][0-9]|[0-2][0-5][0-5])$)", RegexOptions.None))
                {
                    return "LAN IP";
                }

                if (ip == "127.0.0.1")
                {
                    return "LocalHost";
                }

                var city = reader.City(ip);

                return city.Country.Name + " " + city.City.Name;

            }
            catch
            {
                return "Unknown";
            }

        }

        public static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }

            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num) + suf[place];
        }

        #region DeviceInfo

        public class DeviceInfo
        {
            public string Name { get; set; }
            public string DeviceId { get; set; }
            public string Description { get; set; }
            public string Manufacturer { get; set; }
            public DeviceCategory Category { get; set; }
            public string CustomCategory { get; set; }
            public string StatusCode { get; set; }
            public string HardwareId { get; set; }

            public string DriverName { get; set; }
            public string DriverFriendlyName { get; set; }
            public string DriverBuildDate { get; set; }
            public string DriverDescription { get; set; }
            public string DriverVersion { get; set; }
            public string DriverProviderName { get; set; }
            public string DriverInstallDate { get; set; }
            public string DriverSigner { get; set; }
            public string DriverInfName { get; set; }
        }

        public class DeviceCategoryGuidAttribute : Attribute
        {
            public DeviceCategoryGuidAttribute(Guid guid)
            {
                Guid = guid;
            }

            public DeviceCategoryGuidAttribute(string guid)
            {
                Guid = new Guid(guid);
            }

            public Guid Guid { get; }
        }

        public class DeviceCategoryDisplayNameAttribute : Attribute
        {
            public DeviceCategoryDisplayNameAttribute(string displayName)
            {
                DisplayName = displayName;
            }

            public string DisplayName { get; set; }
        }

        public enum DeviceCategory
        {
            [DeviceCategoryGuid("00000000-0000-0000-0000-000000000000")] None,

            //https://msdn.microsoft.com/en-us/library/ff553426%28VS.85%29.aspx
            /// <summary>
            ///     Name = Battery Devices, Class = Battery
            ///     This class includes battery devices and UPS devices.
            /// </summary>
            [DeviceCategoryDisplayName("Battery Devices")] [DeviceCategoryGuid("{72631e54-78a4-11d0-bcf7-00aa00b7b32a}")] BatteryDevices,

            /// <summary>
            ///     Name = Biometric Device, Class = Biometric
            ///     (Windows Server 2003 and later versions of Windows) This class includes all biometric-based personal identification
            ///     devices.
            /// </summary>
            [DeviceCategoryDisplayName("Biometric Device")] [DeviceCategoryGuid("{53D29EF7-377C-4D14-864B-EB3A85769359}")] BiometricDevice,

            /// <summary>
            ///     Name = Bluetooth Devices, Class = Bluetooth
            ///     (Windows XP SP1 and later versions of Windows) This class includes all Bluetooth devices.
            /// </summary>
            [DeviceCategoryDisplayName("Bluetooth Devices")] [DeviceCategoryGuid("{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}")] BluetoothDevices,

            /// <summary>
            ///     Name = CD-ROM Drives, Class = CDROM
            ///     This class includes CD-ROM drives, including SCSI CD-ROM drives. By default, the system's CD-ROM class installer
            ///     also installs a system-supplied CD audio driver and CD-ROM changer driver as Plug and Play filters.
            /// </summary>
            [DeviceCategoryDisplayName("CD-ROM Drives")] [DeviceCategoryGuid("{4d36e965-e325-11ce-bfc1-08002be10318}")] CDROMDrives,

            /// <summary>
            ///     Name = Disk Drives, Class = DiskDrive
            ///     This class includes hard disk drives. See also the HDC and SCSIAdapter classes.
            /// </summary>
            [DeviceCategoryDisplayName("Disk Drives")] [DeviceCategoryGuid("{4d36e967-e325-11ce-bfc1-08002be10318}")] DiskDrives,

            /// <summary>
            ///     Name = Display Adapters, Class = Display
            ///     This class includes video adapters. Drivers for this class include display drivers and video miniport drivers.
            /// </summary>
            [DeviceCategoryDisplayName("Display Adapters")] [DeviceCategoryGuid("{4d36e968-e325-11ce-bfc1-08002be10318}")] DisplayAdapters,

            /// <summary>
            ///     Name = Floppy Disk Controllers, Class = FDC
            ///     This class includes floppy disk drive controllers.
            /// </summary>
            [DeviceCategoryDisplayName("Floppy Disk Controllers")] [DeviceCategoryGuid("{4d36e969-e325-11ce-bfc1-08002be10318}")] FloppyDiskControllers,

            /// <summary>
            ///     Name = Global Positioning System/Global Navigation Satellite System, Class = GPS
            ///     This class includes GNSS devices that use the Universal Windows driver model introduced in Windows 10.
            /// </summary>
            [DeviceCategoryDisplayName("Global Positioning System/Global Navigation Satellite System")] [DeviceCategoryGuid("{6bdd1fc3-810f-11d0-bec7-08002be2092f}")] GlobalPositioningSystem_GlobalNavigationSatelliteSystem,

            /// <summary>
            ///     Name = Hard Disk Controllers, Class = HDC
            ///     This class includes hard disk controllers, including ATA/ATAPI controllers but not SCSI and RAID disk controllers.
            /// </summary>
            [DeviceCategoryDisplayName("Hard Disk Controllers")] [DeviceCategoryGuid("{4d36e96a-e325-11ce-bfc1-08002be10318}")] HardDiskControllers,

            /// <summary>
            ///     Name = Human Interface Devices (HID), Class = HIDClass
            ///     This class includes interactive input devices that are operated by the system-supplied HID class driver. This
            ///     includes USB devices that comply with the USB HID Standard and non-USB devices that use a HID minidriver. For more
            ///     information, see HIDClass Device Setup Class. (See also the Keyboard or Mouse classes later in this list.)
            /// </summary>
            [DeviceCategoryDisplayName("Human Interface Devices (HID)")] [DeviceCategoryGuid("{745a17a0-74d3-11d0-b6fe-00a0c90f57da}")] HumanInterfaceDevicesHID,

            /// <summary>
            ///     Name = IEEE 1284.4 Devices, Class = Dot4
            ///     This class includes devices that control the operation of multifunction IEEE 1284.4 peripheral devices.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1284.4 Devices")] [DeviceCategoryGuid("{48721b56-6795-11d2-b1a8-0080c72e74a2}")] IEEE1284_4Devices,

            /// <summary>
            ///     Name = IEEE 1284.4 Print Functions, Class = Dot4Print
            ///     This class includes Dot4 print functions. A Dot4 print function is a function on a Dot4 device and has a single
            ///     child device, which is a member of the Printer device setup class.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1284.4 Print Functions")] [DeviceCategoryGuid("{49ce6ac8-6f86-11d2-b1e5-0080c72e74a2}")] IEEE1284_4PrintFunctions,

            /// <summary>
            ///     Name = IEEE 1394 Devices That Support the 61883 Protocol, Class = 61883
            ///     This class includes IEEE 1394 devices that support the IEC-61883 protocol device class.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1394 Devices That Support the 61883 Protocol")] [DeviceCategoryGuid("{7ebefbc0-3200-11d2-b4c2-00a0C9697d07}")] IEEE1394DevicesThatSupportthe61883Protocol,

            /// <summary>
            ///     Name = IEEE 1394 Devices That Support the AVC Protocol, Class = AVC
            ///     This class includes IEEE 1394 devices that support the AVC protocol device class.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1394 Devices That Support the AVC Protocol")] [DeviceCategoryGuid("{c06ff265-ae09-48f0-812c-16753d7cba83}")] IEEE1394DevicesThatSupporttheAVCProtocol,

            /// <summary>
            ///     Name = IEEE 1394 Devices That Support the SBP2 Protocol, Class = SBP2
            ///     This class includes IEEE 1394 devices that support the SBP2 protocol device class.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1394 Devices That Support the SBP2 Protocol")] [DeviceCategoryGuid("{d48179be-ec20-11d1-b6b8-00c04fa372a7}")] IEEE1394DevicesThatSupporttheSBP2Protocol,

            /// <summary>
            ///     Name = IEEE 1394 Host Bus Controller, Class = 1394
            ///     This class includes 1394 host controllers connected on a PCI bus, but not 1394 peripherals. Drivers for this class
            ///     are system-supplied.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1394 Host Bus Controller")] [DeviceCategoryGuid("{6bdd1fc1-810f-11d0-bec7-08002be2092f}")] IEEE1394HostBusController,

            /// <summary>
            ///     Name = Imaging Device, Class = Image
            ///     This class includes still-image capture devices, digital cameras, and scanners.
            /// </summary>
            [DeviceCategoryDisplayName("Imaging Device")] [DeviceCategoryGuid("{6bdd1fc6-810f-11d0-bec7-08002be2092f}")] ImagingDevice,

            /// <summary>
            ///     Name = IrDA Devices, Class = Infrared
            ///     This class includes infrared devices. Drivers for this class include Serial-IR and Fast-IR NDIS miniports, but see
            ///     also the Network Adapter class for other NDIS network adapter miniports.
            /// </summary>
            [DeviceCategoryDisplayName("IrDA Devices")] [DeviceCategoryGuid("{6bdd1fc5-810f-11d0-bec7-08002be2092f}")] IrDADevices,

            /// <summary>
            ///     Name = Keyboard, Class = Keyboard
            ///     This class includes all keyboards. That is, it must also be specified in the (secondary) INF for an enumerated
            ///     child HID keyboard device.
            /// </summary>
            [DeviceCategoryDisplayName("Keyboard")] [DeviceCategoryGuid("{4d36e96b-e325-11ce-bfc1-08002be10318}")] Keyboard,

            /// <summary>
            ///     Name = Media Changers, Class = MediumChanger
            ///     This class includes SCSI media changer devices.
            /// </summary>
            [DeviceCategoryDisplayName("Media Changers")] [DeviceCategoryGuid("{ce5939ae-ebde-11d0-b181-0000f8753ec4}")] MediaChangers,

            /// <summary>
            ///     Name = Memory Technology Driver, Class = MTD
            ///     This class includes memory devices, such as flash memory cards.
            /// </summary>
            [DeviceCategoryDisplayName("Memory Technology Driver")] [DeviceCategoryGuid("{4d36e970-e325-11ce-bfc1-08002be10318}")] MemoryTechnologyDriver,

            /// <summary>
            ///     Name = Modem, Class = Modem
            ///     This class includes modem devices. An INF file for a device of this class specifies the features and configuration
            ///     of the device and stores this information in the registry. An INF file for a device of this class can also be used
            ///     to install device drivers for a controllerless modem or a software modem. These devices split the functionality
            ///     between the modem device and the device driver. For more information about modem INF files and Microsoft Windows
            ///     Driver Model (WDM) modem devices, see Overview of Modem INF Files and Adding WDM Modem Support.
            /// </summary>
            [DeviceCategoryDisplayName("Modem")] [DeviceCategoryGuid("{4d36e96d-e325-11ce-bfc1-08002be10318}")] Modem,

            /// <summary>
            ///     Name = Monitor, Class = Monitor
            ///     This class includes display monitors. An INF for a device of this class installs no device driver(s), but instead
            ///     specifies the features of a particular monitor to be stored in the registry for use by drivers of video adapters.
            ///     (Monitors are enumerated as the child devices of display adapters.)
            /// </summary>
            [DeviceCategoryDisplayName("Monitor")] [DeviceCategoryGuid("{4d36e96e-e325-11ce-bfc1-08002be10318}")] Monitor,

            /// <summary>
            ///     Name = Mouse, Class = Mouse
            ///     This class includes all mouse devices and other kinds of pointing devices, such as trackballs. That is, this class
            ///     must also be specified in the (secondary) INF for an enumerated child HID mouse device.
            /// </summary>
            [DeviceCategoryDisplayName("Mouse")] [DeviceCategoryGuid("{4d36e96f-e325-11ce-bfc1-08002be10318}")] Mouse,

            /// <summary>
            ///     Name = Multifunction Devices, Class = Multifunction
            ///     This class includes combo cards, such as a PCMCIA modem and netcard adapter. The driver for such a Plug and Play
            ///     multifunction device is installed under this class and enumerates the modem and netcard separately as its child
            ///     devices.
            /// </summary>
            [DeviceCategoryDisplayName("Multifunction Devices")] [DeviceCategoryGuid("{4d36e971-e325-11ce-bfc1-08002be10318}")] MultifunctionDevices,

            /// <summary>
            ///     Name = Multimedia, Class = Media
            ///     This class includes Audio and DVD multimedia devices, joystick ports, and full-motion video capture devices.
            /// </summary>
            [DeviceCategoryDisplayName("Multimedia")] [DeviceCategoryGuid("{4d36e96c-e325-11ce-bfc1-08002be10318}")] Multimedia,

            /// <summary>
            ///     Name = Multiport Serial Adapters, Class = MultiportSerial
            ///     This class includes intelligent multiport serial cards, but not peripheral devices that connect to its ports. It
            ///     does not include unintelligent (16550-type) multiport serial controllers or single-port serial controllers (see the
            ///     Ports class).
            /// </summary>
            [DeviceCategoryDisplayName("Multiport Serial Adapters")] [DeviceCategoryGuid("{50906cb8-ba12-11d1-bf5d-0000f805f530}")] MultiportSerialAdapters,

            /// <summary>
            ///     Name = Network Adapter, Class = Net
            ///     This class includes NDIS miniport drivers excluding Fast-IR miniport drivers, NDIS intermediate drivers (of virtual
            ///     adapters), and CoNDIS MCM miniport drivers.
            /// </summary>
            [DeviceCategoryDisplayName("Network Adapter")] [DeviceCategoryGuid("{4d36e972-e325-11ce-bfc1-08002be10318}")] NetworkAdapter,

            /// <summary>
            ///     Name = Network Client, Class = NetClient
            ///     This class includes network and/or print providers.
            /// </summary>
            [DeviceCategoryDisplayName("Network Client")] [DeviceCategoryGuid("{4d36e973-e325-11ce-bfc1-08002be10318}")] NetworkClient,

            /// <summary>
            ///     Name = Network Service, Class = NetService
            ///     This class includes network services, such as redirectors and servers.
            /// </summary>
            [DeviceCategoryDisplayName("Network Service")] [DeviceCategoryGuid("{4d36e974-e325-11ce-bfc1-08002be10318}")] NetworkService,

            /// <summary>
            ///     Name = Network Transport, Class = NetTrans
            ///     This class includes NDIS protocols CoNDIS stand-alone call managers, and CoNDIS clients, in addition to higher
            ///     level drivers in transport stacks.
            /// </summary>
            [DeviceCategoryDisplayName("Network Transport")] [DeviceCategoryGuid("{4d36e975-e325-11ce-bfc1-08002be10318}")] NetworkTransport,

            /// <summary>
            ///     Name = PCI SSL Accelerator, Class = SecurityAccelerator
            ///     This class includes devices that accelerate secure socket layer (SSL) cryptographic processing.
            /// </summary>
            [DeviceCategoryDisplayName("PCI SSL Accelerator")] [DeviceCategoryGuid("{268c95a1-edfe-11d3-95c3-0010dc4050a5}")] PCISSLAccelerator,

            /// <summary>
            ///     Name = PCMCIA Adapters, Class = PCMCIA
            ///     This class includes PCMCIA and CardBus host controllers, but not PCMCIA or CardBus peripherals. Drivers for this
            ///     class are system-supplied.
            /// </summary>
            [DeviceCategoryDisplayName("PCMCIA Adapters")] [DeviceCategoryGuid("{4d36e977-e325-11ce-bfc1-08002be10318}")] PCMCIAAdapters,

            /// <summary>
            ///     Name = Ports (COM & LPT ports), Class = Ports
            ///     This class includes serial and parallel port devices. See also the MultiportSerial class.
            /// </summary>
            [DeviceCategoryDisplayName("Ports (COM & LPT ports)")] [DeviceCategoryGuid("{4d36e978-e325-11ce-bfc1-08002be10318}")] PortsCOM_LPTports,

            /// <summary>
            ///     Name = Printers, Class = Printer
            ///     This class includes printers.
            /// </summary>
            [DeviceCategoryDisplayName("Printers")] [DeviceCategoryGuid("{4d36e979-e325-11ce-bfc1-08002be10318}")] Printers,

            /// <summary>
            ///     Name = Printers, Bus-specific class drivers, Class = PNPPrinters
            ///     This class includes SCSI/1394-enumerated printers. Drivers for this class provide printer communication for a
            ///     specific bus.
            /// </summary>
            [DeviceCategoryDisplayName("Printers, Bus-specific class drivers")] [DeviceCategoryGuid("{4658ee7e-f050-11d1-b6bd-00c04fa372a7}")] Printers_BusSpecificClassDrivers,

            /// <summary>
            ///     Name = Processors, Class = Processor
            ///     This class includes processor types.
            /// </summary>
            [DeviceCategoryDisplayName("Processors")] [DeviceCategoryGuid("{50127dc3-0f36-415e-a6cc-4cb3be910b65}")] Processors,

            /// <summary>
            ///     Name = SCSI and RAID Controllers, Class = SCSIAdapter
            ///     This class includes SCSI HBAs (Host Bus Adapters) and disk-array controllers.
            /// </summary>
            [DeviceCategoryDisplayName("SCSI and RAID Controllers")] [DeviceCategoryGuid("{4d36e97b-e325-11ce-bfc1-08002be10318}")] SCSIandRAIDControllers,

            /// <summary>
            ///     Name = Sensors, Class = Sensor
            ///     (Windows 7 and later versions of Windows) This class includes sensor and location devices, such as GPS devices.
            /// </summary>
            [DeviceCategoryDisplayName("Sensors")] [DeviceCategoryGuid("{5175d334-c371-4806-b3ba-71fd53c9258d}")] Sensors,

            /// <summary>
            ///     Name = Smart Card Readers, Class = SmartCardReader
            ///     This class includes smart card readers.
            /// </summary>
            [DeviceCategoryDisplayName("Smart Card Readers")] [DeviceCategoryGuid("{50dd5230-ba8a-11d1-bf5d-0000f805f530}")] SmartCardReaders,

            /// <summary>
            ///     Name = Storage Volumes, Class = Volume
            ///     This class includes storage volumes as defined by the system-supplied logical volume manager and class drivers that
            ///     create device objects to represent storage volumes, such as the system disk class driver.
            /// </summary>
            [DeviceCategoryDisplayName("Storage Volumes")] [DeviceCategoryGuid("{71a27cdd-812a-11d0-bec7-08002be2092f}")] StorageVolumes,

            /// <summary>
            ///     Name = System Devices, Class = System
            ///     This class includes HALs, system buses, system bridges, the system ACPI driver, and the system volume manager
            ///     driver.
            /// </summary>
            [DeviceCategoryDisplayName("System Devices")] [DeviceCategoryGuid("{4d36e97d-e325-11ce-bfc1-08002be10318}")] SystemDevices,

            /// <summary>
            ///     Name = Tape Drives, Class = TapeDrive
            ///     This class includes tape drives, including all tape miniclass drivers.
            /// </summary>
            [DeviceCategoryDisplayName("Tape Drives")] [DeviceCategoryGuid("{6d807884-7d21-11cf-801c-08002be10318}")] TapeDrives,

            /// <summary>
            ///     Name = USB Device, Class = USBDevice
            ///     USBDevice includes all USB devices that do not belong to another class. This class is not used for USB host
            ///     controllers and hubs.
            /// </summary>
            [DeviceCategoryDisplayName("USB Device")] [DeviceCategoryGuid("{88BAE032-5A81-49f0-BC3D-A4FF138216D6}")] USBDevice,

            /// <summary>
            ///     Name = Windows CE USB ActiveSync Devices, Class = WCEUSBS
            ///     This class includes Windows CE ActiveSync devices.
            /// </summary>
            [DeviceCategoryDisplayName("Windows CE USB ActiveSync Devices")] [DeviceCategoryGuid("{25dbce51-6c8f-4a72-8a6d-b54c2b4fc835}")] WindowsCEUSBActiveSyncDevices,

            /// <summary>
            ///     Name = Windows Portable Devices (WPD), Class = WPD
            ///     (Windows Vista and later versions of Windows) This class includes WPD devices.
            /// </summary>
            [DeviceCategoryDisplayName("Windows Portable Devices (WPD)")] [DeviceCategoryGuid("{eec5ad98-8080-425f-922a-dabf3de3f69a}")] WindowsPortableDevices_WPD,

            /// <summary>
            ///     Name = Windows SideShow, Class = SideShow
            ///     (Windows Vista and later versions of Windows) This class includes all devices that are compatible with Windows
            ///     SideShow.
            /// </summary>
            [DeviceCategoryDisplayName("Windows SideShow")] [DeviceCategoryGuid("{997b5d8d-c442-4f2e-baf3-9c8e671e9e21}")] WindowsSideShow,
            //=================== Custom IDs added by Sorzus =================== \\
            [DeviceCategoryDisplayName("Audio Endpoints")] [DeviceCategoryGuid("{c166523c-fe0c-4a94-a586-f1a80cfbbf3e}")] AudioEndpoint,
            [DeviceCategoryDisplayName("Software Devices")] [DeviceCategoryGuid("{62f9c741-b25a-46ce-b54c-9bccce08b6f2}")] SoftwareDevices,
            [DeviceCategoryDisplayName("Print Queue")] [DeviceCategoryGuid("{1ed2bbf9-11f0-4084-b21f-ad83a8e6dcdc}")] PrintQueue,
            [DeviceCategoryDisplayName("VST Jungo")] [DeviceCategoryGuid("{88f671a5-f729-47b7-a055-a50c0eb8d6d1}")] VSTJungo,
            [DeviceCategoryDisplayName("WSD Print Device")] [DeviceCategoryGuid("{c30ecea0-11ef-4ef9-b02e-6af81e6e65c0}")] WSDPrintDevice,
            [DeviceCategoryDisplayName("Storage Devices")] [DeviceCategoryGuid("{5099944a-f6b9-4057-a056-8c550228544c}")] StorageDevices,
            //=================== Custom IDs added by Sorzus =================== \\
            //https://msdn.microsoft.com/en-us/library/windows/hardware/ff553428(v=vs.85).aspx
            /// <summary>
            ///     Name = Adapter, Class = Adapter
            ///     This class is obsolete.
            /// </summary>
            [DeviceCategoryDisplayName("Adapter")] [DeviceCategoryGuid("{4d36e964-e325-11ce-bfc1-08002be10318}")] Adapter,

            /// <summary>
            ///     Name = APM, Class = APMSupport
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("APM")] [DeviceCategoryGuid("{d45b1c18-c8fa-11d1-9f77-0000f805f530}")] APM,

            /// <summary>
            ///     Name = Computer, Class = Computer
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("Computer")] [DeviceCategoryGuid("{4d36e966-e325-11ce-bfc1-08002be10318}")] Computer,

            /// <summary>
            ///     Name = Decoders, Class = Decoder
            ///     This class is reserved for future use.
            /// </summary>
            [DeviceCategoryDisplayName("Decoders")] [DeviceCategoryGuid("{6bdd1fc2-810f-11d0-bec7-08002be2092f}")] Decoders,

            /// <summary>
            ///     Name = Host-side IEEE 1394 Kernel Debugger Support, Class = 1394Debug
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("Host-side IEEE 1394 Kernel Debugger Support")] [DeviceCategoryGuid("{66f250d6-7801-4a64-b139-eea80a450b24}")] HostsideIEEE1394KernelDebuggerSupport,

            /// <summary>
            ///     Name = IEEE 1394 IP Network Enumerator, Class = Enum1394
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("IEEE 1394 IP Network Enumerator")] [DeviceCategoryGuid("{c459df55-db08-11d1-b009-00a0c9081ff6}")] IEEE1394IPNetworkEnumerator,

            /// <summary>
            ///     Name = No driver, Class = NoDriver
            ///     This class is obsolete.
            /// </summary>
            [DeviceCategoryDisplayName("No driver")] [DeviceCategoryGuid("{4d36e976-e325-11ce-bfc1-08002be10318}")] Nodriver,

            /// <summary>
            ///     Name = Non-Plug and Play Drivers, Class = LegacyDriver
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("Non-Plug and Play Drivers")] [DeviceCategoryGuid("{8ecc055d-047f-11d1-a537-0000f8753ed1}")] NonPlugandPlayDrivers,

            /// <summary>
            ///     Name = Other Devices, Class = Unknown
            ///     This class is reserved for system use. Enumerated devices for which the system cannot determine the type are
            ///     installed under this class. Do not use this class if you are unsure in which class your device belongs. Either
            ///     determine the correct device setup class or create a new class.
            /// </summary>
            [DeviceCategoryDisplayName("Other Devices")] [DeviceCategoryGuid("{4d36e97e-e325-11ce-bfc1-08002be10318}")] OtherDevices,

            /// <summary>
            ///     Name = Printer Upgrade, Class = PrinterUpgrade
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("Printer Upgrade")] [DeviceCategoryGuid("{4d36e97a-e325-11ce-bfc1-08002be10318}")] PrinterUpgrade,

            /// <summary>
            ///     Name = Sound, Class = Sound
            ///     This class is obsolete.
            /// </summary>
            [DeviceCategoryDisplayName("Sound")] [DeviceCategoryGuid("{4d36e97c-e325-11ce-bfc1-08002be10318}")] Sound,

            /// <summary>
            ///     Name = Storage Volume Snapshots, Class = VolumeSnapshot
            ///     This class is reserved for system use.
            /// </summary>
            [DeviceCategoryDisplayName("Storage Volume Snapshots")] [DeviceCategoryGuid("{533c5b84-ec70-11d2-9505-00c04F79deaf}")] StorageVolumeSnapshots,

            /// <summary>
            ///     Name = USB Bus Devices (hubs and host controllers), Class = USB
            ///     This class includes USB host controllers and USB hubs, but not USB peripherals. Drivers for this class are
            ///     system-supplied.
            /// </summary>
            [DeviceCategoryDisplayName("USB Bus Devices (hubs and host controllers)")] [DeviceCategoryGuid("{36fc9e60-c465-11cf-8056-444553540000}")] USBBusDevices_hubsandhostcontrollers
        }

        public static string StatusCodeString(uint StatusCode)
        {
            switch (StatusCode)
            {
                case 0:
                    return "Device is working properly";
                case 1:
                    return "Device is not configured correctly.";
                case 2:
                    return "Windows cannot load the driver for this device";
                case 3:
                    return "Driver for this device might be corrupted or the system may be low on memory or other resources.";
                case 4:
                    return "Device is not working properly. One of its drivers or the registry might be corrupted.";
                case 5:
                    return "Driver for the device requires a resource that Windows cannot manage.";
                case 6:
                    return "Boot configuration for the device conflicts with other devices.";
                case 7:
                    return "Cannot filter.";
                case 8:
                    return "Driver loader for the device is missing.";
                case 9:
                    return "Device is not working properly. The controlling firmware is incorrectly reporting the resources for the device.";
                case 10:
                    return "Device cannot start.";
                case 11:
                    return "Device failed.";
                case 12:
                    return "Device cannot find enough free resources to use.";
                case 13:
                    return "Windows cannot verify the device's resources.";
                case 14:
                    return "Device cannot work properly until the computer is restarted.";
                case 15:
                    return "Device is not working properly due to a possible re-enumeration problem.";
                case 16:
                    return "Windows cannot identify all of the resources that the device uses.";
                case 17:
                    return "Device is requesting an unknown resource type.";
                case 18:
                    return "Device drivers must be reinstalled.";
                case 19:
                    return "Failure using the VxD loader.";
                case 20:
                    return "Registry might be corrupted.";
                case 21:
                    return "System failure. If changing the device driver is ineffective, see the hardware documentation. Windows is removing the device.";
                case 22:
                    return "Device is disabled.";
                case 23:
                    return "System failure. If changing the device driver is ineffective, see the hardware documentation.";
                case 24:
                    return "Device is not present, not working properly, or does not have all of its drivers installed.";
                case 25:
                    return "Windows is still setting up the device.";
                case 26:
                    return "Windows is still setting up the device.";
                case 27:
                    return "Device does not have valid log configuration.";
                case 28:
                    return "Device drivers are not installed.";
                case 29:
                    return "Device is disabled. The device firmware did not provide the required resources.";
                case 30:
                    return "Device is using an IRQ resource that another device is using.";
                case 31:
                    return "Device is not working properly. Windows cannot load the required device drivers";
                default:
                    return "";
            }
        }

        #endregion

        #region Serialize

        public static RegSeekerMatch[] DeSerializeMatches(byte[] bytes)
        {
            RegSeekerMatch[] Matches = bytes.Deserialize<RegSeekerMatch[]>();
            return Matches;
        }

        public static RegSeekerMatch DeSerializeMatch(byte[] bytes)
        {
            RegSeekerMatch Match = bytes.Deserialize<RegSeekerMatch>();
            return Match;
        }

        public static RegValueData DeSerializeRegValueData(byte[] bytes)
        {
            RegValueData Value = bytes.Deserialize<RegValueData>();
            return Value;
        }

        public static byte[] Serialize(RegValueData Value)
        {
            return Value.Serialize();
        }

        #endregion
    }

    public class Binder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            String currentAssembly = Assembly.GetExecutingAssembly().FullName;
            typeName = typeName.Replace("Client.Helper.RegManager", "DcRat.Helper");
            assemblyName = currentAssembly;

            typeToDeserialize = Type.GetType($"{typeName}, {assemblyName}");
            return typeToDeserialize;
        }
    }

    public static class Serializer
    {
        public static byte[] Serialize<T>(this T @object)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, @object);
                return ms.ToArray();
            }
        }

        public static T Deserialize<T>(this byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return (T)new BinaryFormatter
                {
                    Binder = new Binder()
                }.Deserialize(ms);
            }
        }
    }
}
