using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct ActionType
    {
        public const int Size = 1010;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] SingleToUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] SingleToRoom;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] UserToUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] UserToOtherUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] UserToRoom;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] MonsterToUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] MonsterToRoom;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] InventoryToUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] InventoryToRoom;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] FloorItemToUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 78)]
        public char[] FloorItemToRoom;

//        Public Type ActionRecType
//    Name As String * 29
//    AfterName As Byte
//    SingleToUser As String * 74
//    nothing2(2) As Integer
//    SingleToRoom As String* 74
//    nothing3(2) As Integer
//    UserToUser As String* 74
//    nothing4(2) As Integer
//    UserToOtherUser As String* 74
//    nothing5(2) As Integer
//    UserToRoom As String* 74
//    Nothing6(2) As Integer
//    MonsterToUser As String* 74
//    nothing7(2) As Integer
//    MonsterToRoom As String* 74
//    nothing8(2) As Integer
//    InventoryToUser As String* 74
//    nothing9(2) As Integer
//    InventoryToRoom As String* 74
//    nothing10(2) As Integer
//    FloorItemToUser As String* 74
//    Nothing11(2) As Integer
//    FloorItemToRoom As String* 74
//End Type
    }
}
