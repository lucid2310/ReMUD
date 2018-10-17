using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct ShopType
    {
        //Number As Long                 '4              '1
        //Name As String* 39          '43
        //ShopAfterName As Integer          '45
        //ShopDescriptionA As String* 52      '97
        //ShopNothing1 As Byte             '98             '5
        //ShopDescriptionB As String* 52      '150
        //ShopNothing2 As Byte             '151
        //ShopDescriptionC As String* 52      '203
        //ShopNothing3 As Byte             '204
        //ShopType As Integer          '206            '10
        //ShopMinLvL As Integer          '208
        //ShopMaxLvl As Integer          '210
        //ShopMarkUp As Integer          '212
        //ShopNothing4 As Integer          '214
        //ShopClassLimit As Byte          '215
        //ShopNothingAA As Byte             '216            '16
        //ShopItemNumber(19)      As Long             '20*4=80, 296   '36
        //ShopMax(19)             As Integer          '20*2=40, 336   '56
        //ShopNow(19)             As Integer          '40, 376        '76
        //ShopRgnTime(19)         As Integer          '40, 416        '96
        //ShopRgnNumber(19)       As Integer          '40, 456        '116
        //ShopRgnPercentage(19)   As Byte             '20, 476        '136

        public const int Size = 504;

        public int Number;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
        public char[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 53)]
        public char[] ShopDescriptionA;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 53)]
        public char[] ShopDescriptionB;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 53)]
        public char[] ShopDescriptionC;
        public short ShopIndicator;
        public short ShopMinLvL;
        public short ShopMaxLvl;
        public short ShopMarkUp;
        public short Pad_0;
        public byte ShopClassLimit;
        public byte Pad_1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] ShopItemNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] ShopMax;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] ShopNow;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] ShopRgnTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] ShopRgnNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] ShopRgnPercentage;
    }
}
