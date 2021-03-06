﻿using ReMUD.Game.Btrieve;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Managers
{
    public class RoomManager : BaseManager<int, Dictionary<int, RoomType>>
    {
        [DllImport(BTRIEVE_DLL, CharSet = CharSet.Ansi)]
        public static extern short BTRCALL(ushort operation,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] byte[] posBlk,
        [MarshalAs(UnmanagedType.Struct, SizeConst = KEY_BUF_LEN)]
        ref RoomType dataBuffer, ref int dataLength,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] char[] keyBffer,
        ushort keyLength, ushort keyNum);

        private int _numberOfRooms;
        private int _numberOfMaps;

        public override short Close()
        {
            RoomType RecordData = new RoomType();

            return BTRCALL(BtrieveTypes.BtrieveActionType.BCLOSE, PositionBlock, ref RecordData, ref RecordSize, FileName, 0, 0);
        }

        public override short Initialize(string path)
        {
            string tmpFullPath = string.Format("{0}\\{1}", path, "wccmp002.dat");

            ContentType = Structures.ContentTypes.Rooms;

            if (File.Exists(tmpFullPath) == true)
            {
                LogManager.Log("Loading {0} from {1}", ContentType.ToString(), tmpFullPath);

                FileName = BtrieveUtility.ConvertFileName(tmpFullPath);

                RoomType RecordData = new RoomType();

                RecordSize = Marshal.SizeOf(RecordData);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BOPEN,
                        PositionBlock, ref RecordData,
                        ref RecordSize,
                        FileName, 0, 0);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETFIRST, PositionBlock,
                   ref RecordData, ref RecordSize, FileName, 0, 0);

                if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                {
                    if (Contents.ContainsKey(RecordData.MapNumber) == false)
                    {
                        Contents.Add(RecordData.MapNumber, new Dictionary<int, RoomType>());
                        _numberOfMaps++;
                    }

                    Contents.Storage[RecordData.MapNumber].Add(RecordData.RoomNumber, RecordData);

                    _numberOfRooms++;
                }
                else
                {
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
                        if (Contents.ContainsKey(RecordData.MapNumber) == false)
                        {
                            Contents.Add(RecordData.MapNumber, new Dictionary<int, RoomType>());
                            _numberOfMaps++;
                        }

                        Contents.Storage[RecordData.MapNumber].Add(RecordData.RoomNumber, RecordData);

                        _numberOfRooms++;
                    }
                    else
                    {
                        Console.WriteLine("Error: {0}", Status);
                    }
                }
            }
            else
            {
                LogManager.Log("Could not find file {0}", tmpFullPath);
            }

            LogManager.Log("Number of Maps/Rooms loaded: {0}/{1}. Status = {2}", _numberOfMaps, _numberOfRooms, BtrieveTypes.BtrieveErrorCode(Status));

            return Status;
        }

        public override Dictionary<int, RoomType> Select(int id)
        {
            throw new NotImplementedException();
        }
    }
}
