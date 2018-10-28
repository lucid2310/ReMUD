using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseType
{
    public static class VBRecordParser
    {
        public static void Parse(string path)
        {
            Dictionary<string, int> DataTypeLength = new Dictionary<string, int>();

            DataTypeLength.Add("varchar", 1);
            DataTypeLength.Add("int", 4);
            DataTypeLength.Add("smallint", 2);
            DataTypeLength.Add("tinyint", 1);

            List<DataType> dataTypes = new List<DataType>();
            int fieldSize = 0;
            string dataType = "";

            string[] fileContents = File.ReadAllLines(path);
            bool startParsing = false;

            for (int i = 0; i < fileContents.Length; i++)
            {

                string[] splitDataType = fileContents[i].Split(' ');

                    string[] splitVariable = fileContents[i].Trim().Split(new string[] { " As " }, StringSplitOptions.RemoveEmptyEntries);

                    if (fileContents[i].Contains("(") == true && fileContents[i].Contains(")") == true)
                    {
                        int sizeStartIndex = fileContents[i].IndexOf("(") + 1;
                        int sizeStopIndex = fileContents[i].IndexOf(")");

                        string sizeConst = fileContents[i].Substring(sizeStartIndex, sizeStopIndex - sizeStartIndex);

                        foreach (var type in DataTypeLength)
                        {
                            if (fileContents[i + 1].Contains(type.Key) == true)
                            {
                                fieldSize = type.Value;
                                dataType = type.Key;
                                break;
                            }
                        }

                        dataTypes.Add(new DataType()
                        {
                            Name = fileContents[i].Replace(string.Format(" As {0} * {1}", dataType, sizeConst), "").Replace(";", "").Trim(),
                            Size = fieldSize * (int.Parse(sizeConst) + 1),
                            Type = dataType
                        });
                    }
                    else if(fileContents[i].Contains(" * ") == true)
                    {
                        int sizeStartIndex = fileContents[i].IndexOf("*") + 1;
                        int sizeStopIndex = fileContents[i].Length;

                        string sizeConst = fileContents[i].Substring(sizeStartIndex, sizeStopIndex - sizeStartIndex).Trim();

                        foreach (var type in DataTypeLength)
                        {
                            if (fileContents[i + 1].Contains(type.Key) == true)
                            {
                                fieldSize = type.Value;
                                dataType = type.Key;
                                break;
                            }
                        }

                        dataTypes.Add(new DataType()
                        {
                            Name = fileContents[i].Replace(string.Format(" As {0} * {1}", dataType, sizeConst), "").Replace(";", "").Trim(),
                            Size = fieldSize * (int.Parse(sizeConst) + 1),
                            Type = dataType
                        });
                    }
                    else
                    {
                        foreach (var type in DataTypeLength)
                        {
                            if (fileContents[i].Contains(type.Key) == true)
                            {
                                fieldSize = type.Value;
                                dataType = type.Key;
                                break;
                            }
                        }

                        dataTypes.Add(new DataType()
                        {
                            Name = fileContents[i].Replace(string.Format(" As {0}", dataType), "").Replace(";", "").Trim(),
                            Size = fieldSize,
                            Type = dataType
                        });
                    
                }
            }

            List<string> output = new List<string>();

            int offSet = 0;

            for (int i = 0; i < dataTypes.Count; i++)
            {
                output.Add(string.Format("{0},{1},{2},0x{3}", dataTypes[i].Name, dataTypes[i].Size, offSet, offSet.ToString("X")));
                offSet += dataTypes[i].Size;
            }


            File.WriteAllLines(@"C:\Temp\OutputStructvb.txt", output);
        }
    }
}
