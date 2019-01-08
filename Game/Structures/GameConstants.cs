using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReMUD.Game.Structures
{
    public class GameConstants
    {
        public const int MAX_ENERGY_LEVEL = 0x3e8;
        public const int RUNIC_MULTIPLIER = 100;
        public const int PLATINUM_MULTIPLIER = 100;
        public const int GOLD_MULTIPLIER = 10;
        public const int SILVER_MULTIPLIER = 10;
        public const int INVENTORY_MAX = 100;
        public const int KEY_MAX = 50;
        public const int WORN_MAX = 20;

        //        DATA:059A01DC off_59A01DC     dd offset aNowhere_0    ; DATA XREF: _display_user_desc+153B↑r
        //DATA:059A01DC                                         ; _display_user_desc+157B↑r...
        //DATA:059A01DC                                         ; "Nowhere"
        //DATA:059A01E0 dd offset aWorn; "Worn"
        //DATA:059A01E4 dd offset aHead; "Head"
        //DATA:059A01E8 dd offset aHands; "Hands"
        //DATA:059A01EC dd offset aFinger; "Finger"
        //DATA:059A01F0 dd offset aFeet_0; "Feet"
        //DATA:059A01F4 dd offset aArms; "Arms"
        //DATA:059A01F8 dd offset aBack; "Back"
        //DATA:059A01FC dd offset aNeck; "Neck"
        //DATA:059A0200 dd offset aLegs; "Legs"
        //DATA:059A0204 dd offset aWaist; "Waist"
        //DATA:059A0208 dd offset aTorso; "Torso"
        //DATA:059A020C dd offset aOffHand; "Off-Hand"
        //DATA:059A0210 dd offset aFinger; "Finger"
        //DATA:059A0214 dd offset aWrist; "Wrist"
        //DATA:059A0218 dd offset aEars; "Ears"
        //DATA:059A021C dd offset aWorn; "Worn"
        //DATA:059A0220 dd offset aWrist; "Wrist"
        //DATA:059A0224 dd offset aEyes; "Eyes"
        //DATA:059A0228 dd offset aFace; "Face"

        // aTheCopperFarth db 'The copper farthings look like they',27h,'ve been around forever.'
        public static string DISCONNECTED = "%s just disconnected!!!\r";

        public static string MENU_INFO = "\x1B[23;1H\x1B[24;1H\x1B[25;1H\x1B[0m\x1B[255D" +
                             "+ ----------------------------------------------------------------------------+\r" +
                             "|                                                                            |\r" +
                             "| M A J O R   M U D |\r" +
                             "| We would like to thank the users of the following boards in their |\r" +
                             "| assistance and ideas during the BETA testing phase of this program.     |\r" +
                             "| Argus Information     Gameland             Rock Garden |\r" +
                             "| Computer Source       Granola Board        The ADEPT |\r" +
                             "| Computrek             Magic Bus            The Castle |\r" +
                             "| Creative Cafe         Malum                The Imposium |\r" +
                             "| Cybercomm             Masterpiece          The Link |\r" +
                             "| Cyberspace            Metropolis           Trilogy |\r" +
                             "| Farwest               Multi - comm           Dreamscape OES |\r" +
                             "| If you wish to contact the creators of MajorMUD, please visit our |\r" +
                             "| website at http://www.majormud.com                                        |\r" +
                             "| Copyright(c) 1992 - 2001 Metropolis Inc.All Rights Reserved.          |\r" +
                             "+ ----------------------------------------------------------------------------+\r\r";


        #region Edit Character

        public static string CHAR_STR = "Strength  %d - %d\r\n";
        public static string CHAR_INT = "Intellect % d - % d\r\n";
        #endregion

    }
}
