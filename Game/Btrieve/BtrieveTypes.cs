namespace ReMUD.Game.Btrieve
{
    public class BtrieveTypes
    {
        public class BtrieveActionType
        {
            public const ushort BOPEN = 0;
            public const ushort BCLOSE = 1;
            public const ushort BINSERT = 2;
            public const ushort BUPDATE = 3;
            public const ushort BDELETE = 4;
            public const ushort BGETEQUAL = 5;
            public const ushort BGETNEXT = 6;
            public const ushort BGETPREVIOUS = 7;
            public const ushort BGETGREATER = 8;
            public const ushort BGETGREATEROREQUAL = 9;
            public const ushort BGETFIRST = 12;
            public const ushort BGETLAST = 13;
            public const ushort BCREATE = 14;
            public const ushort BSTAT = 15;
            public const ushort BBEGINTRANS = 19;
            public const ushort BTRANSSEND = 20;
            public const ushort BABORTTRANS = 21;
            public const ushort BGETPOSITION = 22;
            public const ushort BGETRECORD = 23;
            public const ushort BSTOP = 25;
            public const ushort BVERSION = 26;
            public const ushort BRESET = 28;
            public const ushort BGETNEXTEXTENDED = 36;
            public const ushort BGETKEY = 50;

            public const ushort KEY_BUF_LEN = 255;
        }

        public class BtrieveStatus
        {
            public const ushort COMPLETE_SUCCESSFULLY = 0;
            public const ushort INVALID_PARAMETER = 1;
            public const ushort I_O_ERROR = 2;
            public const ushort FILE_NOT_OPEN = 3;
            public const ushort CANNOT_FIND_KEY = 4;
            public const ushort DUPLICATE_KEY = 5;
            public const ushort KEY_PARAMETER_INVALID = 6;
            public const ushort END_OF_FILE = 9;
            public const ushort DATA_BUFFER_PARAMETER = 22;
        }

        public static string BtrieveErrorCode(short nStatus)
        {
            string btrieveErrorCode = nStatus.ToString();

            switch (nStatus)
            {
                case 0:
                    btrieveErrorCode = "Completed Successfully";
                    break;
                case 1:
                    btrieveErrorCode = "Invalid Operation (1)";
                    break;
                case 2:
                    btrieveErrorCode = "Disk I/O Error (2)";
                    break;
                case 3:
                    btrieveErrorCode = "File Not Open (3)";
                    break;
                case 4:
                    btrieveErrorCode = "Record Not Found (4)";
                    break;
                case 5:
                    btrieveErrorCode = "Duplicate Record (5)";
                    break;
                case 6:
                    btrieveErrorCode = "Invalid Record Number (6)";
                    break;
                case 7:
                    btrieveErrorCode = "Different Record Number (7)";
                    break;
                case 8:
                    btrieveErrorCode = "Invalid Positioning (8)";
                    break;
                case 9:
                    btrieveErrorCode = "End-Of-File (9)";
                    break;
                case 10:
                    btrieveErrorCode = "Modifiable Index Value Error (10)";
                    break;
                case 11:
                    btrieveErrorCode = "Invalid Location (11)";
                    break;
                case 12:
                    btrieveErrorCode = "File Not Found (12)";
                    break;
                case 13:
                    btrieveErrorCode = "Extended File Error (13)";
                    break;
                case 14:
                    btrieveErrorCode = "Pre-Image Open Error (14)";
                    break;
                //case 15
                //    btrieveErrorCode = "Pre-Image I/O Error  (15)"
                //case 17
                //    btrieveErrorCode = "Close Error (17)"
                //case 18
                //    btrieveErrorCode = "Disk Full (18)"
                //case 19
                //    btrieveErrorCode = "Unrecoverable Error (19)"
                case 20:
                    btrieveErrorCode = "Record Manager Inactive (20)";
                    break;
                //case 21
                //    btrieveErrorCode = "Index Buffer Too Short (21)"
                case 22:
                    btrieveErrorCode = "Data Buffer Length (22)";
                    break;
                //case 23
                //    btrieveErrorCode = "Position Block Length (23)"
                //case 24
                //    btrieveErrorCode = "Page Size Error (24)"
                //case 25
                //    btrieveErrorCode = "Create I/O Error (25)"
                //case 26
                //    btrieveErrorCode = "Number of Keys (26)"
                //case 27
                //    btrieveErrorCode = "Invalid Key Position (27)"
                //case 28
                //    btrieveErrorCode = "Invalid Record Length (28)"
                //case 29
                //    btrieveErrorCode = "Invalid Record Length (29)"
                //case 30
                //    btrieveErrorCode = "Not A Btrieve File (30)"
                //case 35
                //    btrieveErrorCode = "Directory Error (35), Go to File --> Settings and set your Datfile Path"
                //case 36
                //    btrieveErrorCode = "TransactiOn Error (36)"
                //case 37
                //    btrieveErrorCode = "Transaction Is Active (37)"
                //case 38
                //    btrieveErrorCode = "Transaction Control File I/O Error (38)"
                //case 39
                //    btrieveErrorCode = "End/Abort TransactiOn Error (39)"
                //case 40
                //    btrieveErrorCode = "Transaction Max Files (40)"
                //case 41
                //    btrieveErrorCode = "Operation Not Allowed (41)"
                //case 43
                //    btrieveErrorCode = "Invalid Record Access (43)"
                //case 44
                //    btrieveErrorCode = "Null Index Path (44)"
                //case 46
                //    btrieveErrorCode = "Access To File Denied (46)"
                //case 51
                //    btrieveErrorCode = "Invalid Owner (51)"
                //case 52
                //    btrieveErrorCode = "Error Writing Cache (52)"
                //case 54
                //    btrieveErrorCode = "Variable Page Error During a Step Direct operation (54)"
                //case 55
                //    btrieveErrorCode = "Autoincrement Error (55)"
                //case 58
                //    btrieveErrorCode = "Compression Buffer Too Short (58)"
                //case 66
                //    btrieveErrorCode = "Maximum Number of Open Databases Exceeded (66)"
                //case 67
                //    btrieveErrorCode = "Rl Could Not Open SQL Data Dictionaries (67)"
                //case 68
                //    btrieveErrorCode = "Rl Cascades Too Deeply (68)"
                //case 69
                //    btrieveErrorCode = "Rl Cascade Error (69)"
                //case 71
                //    btrieveErrorCode = "Rl Definitions Violation (71)"
                //case 72
                //    btrieveErrorCode = "Rl Referenced File Could Not Be Opnend (72)"
                //case 73
                //    btrieveErrorCode = "Rl Definition Out Of Sync (73)"
                //case 76
                //    btrieveErrorCode = "Rl Referenced File Conflict (76)"
                //case 77
                //    btrieveErrorCode = "Wait Error (77)"
                //case 78
                //    btrieveErrorCode = "Deadlock Detected (78)"
                //case 79
                //    btrieveErrorCode = "Programming Error (79)"
                //case 80
                //    btrieveErrorCode = "Conflict (80)"
                //case 81
                //    btrieveErrorCode = "Lock Error (81)"
                //case 82
                //    btrieveErrorCode = "Lost Position (82)"
                //case 83
                //    btrieveErrorCode = "Read Outside Transaction (83)"
                case 84:
                    btrieveErrorCode = "Record In Use (84)";
                    break;
                //case 85
                //    btrieveErrorCode = "File In Use (85)"
                //case 86
                //    btrieveErrorCode = "File Table Full"
                //case 87
                //    btrieveErrorCode = "Handle Table Full"
                //case 88
                //    btrieveErrorCode = "Incompatible Mode Error"
                //case 90
                //    btrieveErrorCode = "Redirected Device Table Full"
                //case 91
                //    btrieveErrorCode = "Server Error"
                //case 92
                //    btrieveErrorCode = "Transaction Table Full"
                //case 93
                //    btrieveErrorCode = "Incompatible Lock Type"
                //case 94
                //    btrieveErrorCode = "PermissiOn Error"
                //case 95
                //    btrieveErrorCode = "Session No Longer Valid"
                //case 96
                //    btrieveErrorCode = "Communications Environment Error"
                //case 97
                //    btrieveErrorCode = "Data Message Too Small"
                //case 98
                //    btrieveErrorCode = "Internal TransactiOn Error"
                //case 100
                //    btrieveErrorCode = "No Cache Buffers Available"
                //case 101
                //    btrieveErrorCode = "No OS Memory Availabl"
                //case 102
                //    btrieveErrorCode = "Not Enough Stack space"
                //case 1001
                //    btrieveErrorCode = "Lock Option Out Of Range"
                //case 1002
                //    btrieveErrorCode = "Memory AllocatiOn Error"
                //case 1003
                //    btrieveErrorCode = "Memory Option Too Small"
                //case 1004
                //    btrieveErrorCode = "Page Size Option Out Of Range"
                //case 1005
                //    btrieveErrorCode = "Invalid Pre-Image Drive Option"
                //case 1007
                //    btrieveErrorCode = "Files Option Out of Range"
                //case 1008
                //    btrieveErrorCode = "Invalid Initialization Option"
                //case 1009
                //    btrieveErrorCode = "Invalid Transaction File Open"
                //case 1011
                //    btrieveErrorCode = "Compression Buffer Out Of Range"
                //case 1013
                //    btrieveErrorCode = "Task Table Full"
                //case 1014
                //    btrieveErrorCode = "Stop Warning"
                //case 1015
                //    btrieveErrorCode = "Invalid Pointer"
                //case 1016
                //    btrieveErrorCode = "Already Initialized"
                //case 2001
                //    btrieveErrorCode = "Insufficient Memory"
                //case 2003
                //    btrieveErrorCode = "No Local Access Allowed"
                //case 2006
                //    btrieveErrorCode = "No Available SPX Connection"
                //case 2007
                //    btrieveErrorCode = "Invalid Parameter"
                //case Else
                //    btrieveErrorCode = "Unknown BTRIEVE Error, #" & nStatus
                //    }


            }
            return btrieveErrorCode;

        }
    }
}
