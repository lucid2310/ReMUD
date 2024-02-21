using ReMUD.Game.Btrieve;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.Utilities;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ReMUD.Game.Managers
{
    public class SpellManager : BaseManager<int, SpellType>
    {
        [DllImport(BTRIEVE_DLL, CharSet = CharSet.Ansi)]
        public static extern ushort BTRCALL(ushort operation,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] byte[] posBlk,
        [MarshalAs(UnmanagedType.Struct, SizeConst = KEY_BUF_LEN)]
        ref SpellType dataBuffer, ref int dataLength,
        [MarshalAs(UnmanagedType.AsAny, SizeConst = KEY_BUF_LEN)] object keyBffer,
        ushort keyLength, ushort keyNum);

        public override ushort Close()
        {
            SpellType RecordData = new SpellType();

            return BTRCALL(BtrieveTypes.BtrieveActionType.BCLOSE, PositionBlock, ref RecordData, ref RecordSize, FileName, 0, 0);
        }

        public override ushort Initialize(string path)
        {
            ContentType = Structures.ContentTypes.Spells;

            string tmpFullPath = string.Format("{0}\\{1}", path, "wccspel2.dat");

            if (File.Exists(tmpFullPath) == true)
            {
                LogManager.Log("Loading {0} from {1}", ContentType.ToString(), tmpFullPath);

                FileName = BtrieveUtility.ConvertFileName(tmpFullPath);

                SpellType RecordData = new SpellType();

                RecordSize = Marshal.SizeOf(RecordData);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BOPEN,
                        PositionBlock, ref RecordData,
                        ref RecordSize,
                        FileName, 0, 0);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETFIRST, PositionBlock,
                   ref RecordData, ref RecordSize, FileName, 0, 0);

                if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                {
                    Contents.Add(RecordData.Number, RecordData);
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
                        Contents.Add(RecordData.Number, RecordData);
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

        public override ushort Update(SpellType record)
        {
            ushort status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETEQUAL, PositionBlock,
                                    ref ProxyRecordData, ref RecordSize, record.Number, KEY_BUF_LEN, 0);

            status &= BTRCALL(BtrieveTypes.BtrieveActionType.BUPDATE, PositionBlock,
                                    ref record, ref RecordSize, FileName, 0, 0);

            return status;
        }

        public override ushort Reload()
        {
            ushort status = Btrieve.BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY;

            return status;
        }

        public override SpellType Select(int id)
        {
            return BaseSelect(id);
        }
    }
}
