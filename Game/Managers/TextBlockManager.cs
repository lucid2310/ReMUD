using ReMUD.Game.Btrieve;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ReMUD.Game.Managers
{
    public class TextBlockManager : BaseManager<int, Dictionary<short, TextBlockType>>
    {
        [DllImport(BTRIEVE_DLL, CharSet = CharSet.Ansi)]
        public static extern ushort BTRCALL(ushort operation,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] byte[] posBlk,
        [MarshalAs(UnmanagedType.Struct, SizeConst = KEY_BUF_LEN)]
        ref TextBlockType dataBuffer, ref int dataLength,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] char[] keyBffer,
        ushort keyLength, ushort keyNum);

        public override ushort Close()
        {
            TextBlockType RecordData = new TextBlockType();

            return BTRCALL(BtrieveTypes.BtrieveActionType.BCLOSE, PositionBlock, ref RecordData, ref RecordSize, FileName, 0, 0);
        }

        public override ushort Initialize(string path)
        {
            string tmpFullPath = string.Format("{0}\\{1}", path, "wcctext2.dat");

            ContentType = ContentTypes.TextBlocks;

            if (File.Exists(tmpFullPath) == true)
            {
                LogManager.Log("Loading {0} from {1}", ContentType.ToString(), tmpFullPath);

                FileName = BtrieveUtility.ConvertFileName(tmpFullPath);

                TextBlockType RecordData = new TextBlockType();

                RecordSize = Marshal.SizeOf(RecordData);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BOPEN,
                        PositionBlock, ref RecordData,
                        ref RecordSize,
                        FileName, 0, 0);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETFIRST, PositionBlock,
                   ref RecordData, ref RecordSize, FileName, 0, 0);

                if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                {
                    if (Contents.ContainsKey(RecordData.Number) == false)
                    {
                        Contents.Add(RecordData.Number, new Dictionary<short, TextBlockType>());                    
                    }

                    Contents.Storage[RecordData.Number].Add(RecordData.PartNum, RecordData);
                }
                else
                {
                    LogManager.Log("Error: {0}", Status);
                }

                while (Status != BtrieveTypes.BtrieveStatus.END_OF_FILE)
                {
                    Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETNEXT, PositionBlock,
                                    ref RecordData, ref RecordSize, FileName, 0, 0);

                    if (Status == BtrieveTypes.BtrieveStatus.END_OF_FILE)
                    {
                        Status = BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY;
                        break;
                    }

                    if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                    {
                        if (Contents.ContainsKey(RecordData.Number) == false)
                        {
                            Contents.Add(RecordData.Number, new Dictionary<short, TextBlockType>());
                        }

                        Contents.Storage[RecordData.Number].Add(RecordData.PartNum, RecordData);
                    }
                    else
                    {
                        LogManager.Log("Error: {0}", Status);
                    }
                }
            }
            else
            {
                LogManager.Log("Could not find file {0}", tmpFullPath);
            }

            LogManager.Log("Number of {0} loaded: {1}. Status = {2}", ContentType.ToString(), Count, BtrieveTypes.BtrieveErrorCode(Status));

            return Status;
        }

        public TextBlockType Select(int id, short partId = 0)
        {
            if (Contents.ContainsKey(id) == true)
            {
                if (Contents.Storage[id].ContainsKey(partId) == true)
                {
                    return Contents.Storage[id][partId];
                }
            }
            else
            {
                LogManager.Log("Could not find {0} id: {1}", ContentType, id);
            }

            return GetNullContent()[0];
        }

        public override Dictionary<short, TextBlockType> Select(int id)
        {
            return Contents.Storage[id];
        }
    }
}
