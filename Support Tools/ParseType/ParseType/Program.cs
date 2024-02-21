using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseType
{
    class Program
    {
        static Dictionary<string, int> DataTypeLength = new Dictionary<string, int>();

        private static string[] MatchDataType(string line)
        {
            long level = 16;

            level = (level & 0xfffffff1) >> 1;

            string[] results = new string[2];

            string[] splitLine = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if(splitLine.Length != 3)
            {

            }

            foreach (var type in DataTypeLength)
            {
                if (splitLine[1].Equals(type.Key) == true)
                {
                    results[0] = type.Value.ToString();
                    results[1] = type.Key;
                    break;
                }
            }

            return results;
        }

        static void Main(string[] args)
        {
            DataTypeLength.Add("char[]", 1);
            DataTypeLength.Add("char", 1);
            DataTypeLength.Add("int[]", 4);
            DataTypeLength.Add("int", 4);
            DataTypeLength.Add("short[]", 2);
            DataTypeLength.Add("short", 2);         
            DataTypeLength.Add("byte[]", 1);
            DataTypeLength.Add("byte", 1);

            List<DataType> dataTypes = new List<DataType>();
            int fieldSize = 0;
            string dataType = "";

            // VBRecordParser.Parse(@"C:\Temp\UserRecType.txt");
            //return;

            string pathToType = @"C:\Projects\GIT\ReMUD\Game\Structures\ItemType.cs";

            string[] fileContents = File.ReadAllLines(pathToType);
            bool startParsing = false;

            for(int i =0; i < fileContents.Length; i++)
            {
                fieldSize = 0;
                dataType = "";

                if(fileContents[i].Contains("//<start>"))
                {
                    startParsing = true;
                    continue;
                }

                if(fileContents[i].Contains("//<stop>") == true)
                {
                    break;
                }

                if (startParsing == true)
                {
                    if(fileContents[i].Contains("//") == true)
                    {
                        continue;
                    }

                    if (fileContents[i].Contains("MarshalAs") == true)
                    {
                        int sizeStartIndex = fileContents[i].IndexOf("SizeConst");
                        int sizeStopIndex = fileContents[i].IndexOf(")");

                        string sizeConst = fileContents[i].Substring(sizeStartIndex, sizeStopIndex - sizeStartIndex).Replace("SizeConst = ", "");

                        string[] typeResults = MatchDataType(fileContents[i+ 1]);

                        dataType = typeResults[1];
                        fieldSize = int.Parse(typeResults[0]);

                        for (int subIndex = 0; subIndex < int.Parse(sizeConst); subIndex++)
                        {
                            dataTypes.Add(new DataType()
                            {
                                Name = fileContents[i + 1].Replace(string.Format("public {0}", dataType), "").Replace(";", "").Trim() + "[" + subIndex + "]",
                                Size = fieldSize,
                                Type = dataType
                            });
                        }

                        i++;
                    }
                    else
                    {

                        if(fileContents[i].Contains("Offset_5F6") == true)
                        {

                        }

                        string[] typeResults = MatchDataType(fileContents[i]);

                        dataType = typeResults[1];
                        fieldSize = int.Parse(typeResults[0]);

                        dataTypes.Add(new DataType()
                        {
                            Name = fileContents[i].Replace(string.Format("public {0} ", dataType), "").Replace(";", "").Trim(),
                            Size = fieldSize,
                            Type = dataType
                        });
                    }
                }
            }

            List<string> output = new List<string>();

            int offSet = 0;

            for(int i = 0; i < dataTypes.Count; i++)
            {
                output.Add(string.Format("{0},{1},{2},0x{3}", dataTypes[i].Name, dataTypes[i].Size, offSet, offSet.ToString("X")));
                offSet += dataTypes[i].Size;
            }

            FileInfo fileInfo = new FileInfo(pathToType);


            File.WriteAllLines(string.Format(@"C:\Temp\{0}.txt", fileInfo.Name), output);
        }
    }
}
