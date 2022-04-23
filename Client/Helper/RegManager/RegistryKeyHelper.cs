using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Client.Helper.RegManager
{
    public static class RegistryKeyHelper
    {
        private static string DEFAULT_VALUE = string.Empty;

        /// <summary>
        /// Checks if the provided value is the default value
        /// </summary>
        /// <param name="valueName">The name of the value</param>
        /// <returns>True if default value, else False</returns>
        public static bool IsDefaultValue(string valueName)
        {
            return string.IsNullOrEmpty(valueName);
        }

        /// <summary>
        /// Adds the default value to the list of values and returns them as an array. 
        /// If default value already exists this function will only return the list as an array.
        /// </summary>
        /// <param name="values">The list with the values for which the default value should be added to</param>
        /// <returns>Array with all of the values including the default value</returns>
        public static RegistrySeeker.RegValueData[] AddDefaultValue(List<RegistrySeeker.RegValueData> values)
        {
            if (!values.Any(value => IsDefaultValue(value.Name))) values.Add(GetDefaultValue());
            return values.ToArray();
        }

        /// <summary>
        /// Gets the default registry values
        /// </summary>
        /// <returns>A array with the default registry values</returns>
        public static RegistrySeeker.RegValueData[] GetDefaultValues()
        {
            return new[] {GetDefaultValue()};
        }

        public static RegistrySeeker.RegValueData CreateRegValueData(string name, RegistryValueKind kind,
            object value = null)
        {
            var newRegValue = new RegistrySeeker.RegValueData {Name = name, Kind = kind};

            if (value == null)
                newRegValue.Data = new byte[] { };
            else
                switch (newRegValue.Kind)
                {
                    case RegistryValueKind.Binary:
                        newRegValue.Data = (byte[]) value;
                        break;
                    case RegistryValueKind.MultiString:
                        newRegValue.Data = ByteConverter.GetBytes((string[]) value);
                        break;
                    case RegistryValueKind.DWord:
                        newRegValue.Data = ByteConverter.GetBytes((uint) (int) value);
                        break;
                    case RegistryValueKind.QWord:
                        newRegValue.Data = ByteConverter.GetBytes((ulong) (long) value);
                        break;
                    case RegistryValueKind.String:
                    case RegistryValueKind.ExpandString:
                        newRegValue.Data = ByteConverter.GetBytes((string) value);
                        break;
                }

            return newRegValue;
        }

        private static RegistrySeeker.RegValueData GetDefaultValue()
        {
            return CreateRegValueData(DEFAULT_VALUE, RegistryValueKind.String);
        }
    }
}