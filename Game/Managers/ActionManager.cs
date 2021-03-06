﻿using ReMUD.Game.Btrieve;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.Utilities;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ReMUD.Game.Managers
{
    public class ActionManager : BaseManager<string, ActionType>
    {
        [DllImport(BTRIEVE_DLL, CharSet = CharSet.Ansi)]
        public static extern short BTRCALL(ushort operation,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] byte[] posBlk,
        [MarshalAs(UnmanagedType.Struct, SizeConst = KEY_BUF_LEN)]
        ref ActionType dataBuffer,
        ref int dataLength,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] char[] keyBffer,
        ushort keyLength, ushort keyNum);

        public override short Initialize(string path)
        {
            string tmpFullPath = string.Format("{0}\\{1}", path, "wccacts2.dat");

            string absolutePath = Path.GetFullPath(tmpFullPath);

            ContentType = ContentTypes.Banks;

            if (File.Exists(tmpFullPath) == true)
            {
                LogManager.Log("Loading {0} from {1}", ContentType.ToString(), tmpFullPath);

                FileName = BtrieveUtility.ConvertFileName(tmpFullPath);

                ActionType RecordData = new ActionType();

                RecordSize = ActionType.Size;// Marshal.SizeOf(RecordData);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BOPEN,
                        PositionBlock, ref RecordData,
                        ref RecordSize,
                        FileName, 0, 0);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETFIRST, PositionBlock,
                   ref RecordData, ref RecordSize, FileName, 0, 0);

                if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                {
                    Contents.Add(BtrieveUtility.ConvertToString(RecordData.Name), RecordData);
                }
                else
                {
                    if (Status == BtrieveTypes.BtrieveStatus.END_OF_FILE)
                    {
                        return (short)BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY;
                    }

                    Console.WriteLine("Error: {0}", Status);
                }

                while (Status != BtrieveTypes.BtrieveStatus.END_OF_FILE)
                {
                    Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETNEXT, PositionBlock,
                                    ref RecordData, ref RecordSize, FileName, 0, 0);

                    if (Status == BtrieveTypes.BtrieveStatus.END_OF_FILE)
                    {
                        Status = (short)BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY;
                        break;
                    }

                    if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                    {
                        Contents.Add(BtrieveUtility.ConvertToString(RecordData.Name), RecordData);
                    }
                    else
                    {
                        Console.WriteLine("Error: {0}", Status);
                        break;
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

        public override short Close()
        {
            ActionType RecordData = new ActionType();

            return BTRCALL(BtrieveTypes.BtrieveActionType.BCLOSE, PositionBlock, ref RecordData, ref RecordSize, FileName, 0, 0);
        }

        public override ActionType Select(string id)
        {
            return BaseSelect(id);
        }
    }
}
