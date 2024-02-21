using ReMUD.Game.Btrieve;
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
    public class PlayerManager : BaseManager<string, PlayerType>
    {
        [DllImport(BTRIEVE_DLL, CharSet = CharSet.Ansi)]
        public static extern ushort BTRCALL(ushort operation,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] byte[] posBlk,
        [MarshalAs(UnmanagedType.Struct, SizeConst = KEY_BUF_LEN)]
        ref PlayerType dataBuffer,
        ref int dataLength,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = KEY_BUF_LEN)] char[] keyBffer,
        ushort keyLength, ushort keyNum);

        public override ushort Initialize(string path)
        {
            List<string> playerKeys = new List<string>();

            string tmpFullPath = string.Format("{0}\\{1}", path, "wccuser2.dat");

            ContentType = ContentTypes.Players;

            if (File.Exists(tmpFullPath) == true)
            {
                LogManager.Log("Loading Players from {0}", tmpFullPath);

                FileName = BtrieveUtility.ConvertFileName(tmpFullPath);

                PlayerType RecordData = new PlayerType();

                RecordSize = Marshal.SizeOf(RecordData);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BOPEN,
                        PositionBlock, ref RecordData,
                        ref RecordSize,
                        FileName, 0, 0);

                Status = BTRCALL(BtrieveTypes.BtrieveActionType.BGETFIRST, PositionBlock,
                   ref RecordData, ref RecordSize, FileName, 0, 0);

                if (Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
                {
                    Contents.Add(BtrieveUtility.ConvertToString(RecordData.Username), RecordData);
                }
                else
                {
                    if (Status == BtrieveTypes.BtrieveStatus.END_OF_FILE)
                    {
                        return BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY;
                    }

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
                        Contents.Add(BtrieveUtility.ConvertToString(RecordData.Username), RecordData);
                    }
                    else
                    { 
                        LogManager.Log("Error: {0}", Status);
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

        public override ushort Insert(PlayerType player)
        {
            Status = BTRCALL(BtrieveTypes.BtrieveActionType.BINSERT, PositionBlock,
                            ref player, ref RecordSize, player.Username, KEY_BUF_LEN, 0);

            if(Status == BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY)
            {
                LogManager.Log("Created new player {0}", player.GetUsername());
            }

            return Status;
        }


        public override ushort Delete(PlayerType player)
        {
            return BTRCALL(BtrieveTypes.BtrieveActionType.BDELETE, PositionBlock,
                                    ref player, ref RecordSize, player.Username, KEY_BUF_LEN, 0);
        }

        public override ushort Update(PlayerType player)
        {
            // update the local copy.
            Contents.Update(player.GetUsername(), player);

            return BTRCALL(BtrieveTypes.BtrieveActionType.BUPDATE, PositionBlock,
                                    ref player, ref RecordSize, player.Username, KEY_BUF_LEN, 0);
        }

        public override ushort Close()
        {
            PlayerType RecordData = new PlayerType();

            return BTRCALL(BtrieveTypes.BtrieveActionType.BCLOSE, PositionBlock, ref RecordData, ref RecordSize, FileName, 0, 0);
        }

        public override PlayerType Select(string id)
        {
            PlayerType player = new PlayerType();

            player = BaseSelect(id);

            if(player.Username == null)
            {
                return PlayerType.Initialize();
            }

            return player;
        }
    }
}
