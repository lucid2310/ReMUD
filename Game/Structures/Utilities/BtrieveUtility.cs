using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures.Utilities
{
    public class BtrieveUtility
    {
        private static Dictionary<int, byte> _mapTiny = new Dictionary<int, byte>();
        private static Dictionary<byte, string> _letters = new Dictionary<byte, string>();

        static BtrieveUtility()
        {

            _mapTiny.Add(8364, 128);
            _mapTiny.Add(8218, 130);
            _mapTiny.Add(402, 131);
            _mapTiny.Add(8222, 132);
            _mapTiny.Add(8230, 133);
            _mapTiny.Add(8224, 134);
            _mapTiny.Add(8225, 135);
            _mapTiny.Add(710, 136);
            _mapTiny.Add(8240, 137);
            _mapTiny.Add(352, 138);
            _mapTiny.Add(8249, 139);
            _mapTiny.Add(338, 140);
            _mapTiny.Add(381, 142);
            _mapTiny.Add(8216, 145);
            _mapTiny.Add(8217, 146);
            _mapTiny.Add(8220, 147);
            _mapTiny.Add(8221, 148);
            _mapTiny.Add(8226, 149);
            _mapTiny.Add(8211, 150);
            _mapTiny.Add(8212, 151);
            _mapTiny.Add(732, 152);
            _mapTiny.Add(8482, 153);
            _mapTiny.Add(353, 154);
            _mapTiny.Add(8250, 155);
            _mapTiny.Add(339, 156);
            _mapTiny.Add(382, 158);
            _mapTiny.Add(376, 159);
        }

        public static byte GetDecode(int value)
        {
            return _mapTiny[value];
        }

        public static char[] ConvertFileName(string iFileName)
        {
            char[] fileTempName = iFileName.ToCharArray();

            char[] fileName = new char[fileTempName.Length + 1];

            for (int i = 0; i < fileTempName.Length; i++)
            {
                fileName[i] = fileTempName[i];
            }

            return fileName;
        }

        public static string GetName(string name)
        {
            int nameEnd = name.IndexOf("\0");

            if (nameEnd != -1)
            {
                name = name.Substring(0, nameEnd);
            }

            return name.Replace("'", "''");
        }

        public static char[] GetKeyName(string name, int size)
        {
            char[] tmpName = new char[size];

            for(int i = 0; i < name.Length; i++)
            {
                tmpName[i] = name[i];
            }

            return tmpName;
        }

        public static string ConvertToString(char[] inputData)
        {
            string results = string.Empty;

            if (inputData != null)
            {
                for (int i = 0; i < inputData.Length; i++)
                {
                    if (inputData[i] != '\0')
                    {
                        results += inputData[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return results;
        }

        public static string ConvertIntArrayToStringArray(byte[] data)
        {
            List<string> tmpOutput = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {
                tmpOutput.Add(data[i].ToString());
            }

            return "{" + string.Join(",", tmpOutput) + "}";
        }

        public static string ConvertIntArrayToStringArray(short[] data)
        {
            List<string> tmpOutput = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {
                tmpOutput.Add(data[i].ToString());
            }

            return "{" + string.Join(",", tmpOutput) + "}";
        }

        public static string ConvertIntArrayToStringArray(int[] data)
        {
            List<string> tmpOutput = new List<string>();

            for(int i = 0; i < data.Length; i++)
            {
                tmpOutput.Add(data[i].ToString());
            }

            return "{" + string.Join(",", tmpOutput) + "}";
        }

        /// <summary>
        /// Deserialize a byte array into a structure.
        /// The structure to deserialize into must have primative data types.
        /// </summary>
        /// <typeparam name="T">Class Type Input</typeparam>
        /// <param name="data">Raw byte[] to deserialize.</param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] data) where T : new()
        {
            T targetStruct = new T();
            int size = Marshal.SizeOf(targetStruct);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(data, 0, ptr, size);

            targetStruct = (T)Marshal.PtrToStructure(ptr, targetStruct.GetType());
            Marshal.FreeHGlobal(ptr);

            return targetStruct;
        }

        /// <summary>
        /// Serialize a structure into a byte array,
        /// the structure must have primative data types.
        /// </summary>
        /// <typeparam name="T">Type  to deserialize into a byte[]</typeparam>
        /// <param name="structure">Actual structure to serialize.</param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T structure)
        {
            int size = Marshal.SizeOf(structure);
            byte[] data = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(structure, ptr, true);
            Marshal.Copy(ptr, data, 0, size);
            Marshal.FreeHGlobal(ptr);

            return data;

        }
    }
}
