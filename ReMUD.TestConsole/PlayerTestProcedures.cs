using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.SupportTypes;

namespace ReMUD.TestConsole
{

    public class PlayerTestProcedures
    {
        private Game.GameManager GameManager = new Game.GameManager();

        public void Setup()
        { 
            GameManager._init__wccmmud(@"C:\WGSERV");
        }

        public void PlayerStructure_TC03()
        {
            // PlayerType playerType = GameManager.ContentManager.Select<PlayerManager>().Select("Sysop");

            int id = GameManager.ContentManager.UserContentManager.GetUserId("Sysop");

            PlayerType player = GameManager.ContentManager.Select<PlayerManager>().Select("Sysop");

            GameManager.ContentManager.Select<PlayerManager>().Delete(player);

        }

        public void PlayerStructure_TC02()
        {
            PlayerType playerType = GameManager.ContentManager.Select<PlayerManager>().Select("Sysop");

            playerType.AbilityId[0] = AbilityTypes.FindTraps;

         
            bool hasAbility = GameManager._user_has_ability(playerType, AbilityTypes.FindTraps);

        }

        public void PlayerStructure_TC01()
        {
            //PlayerType playerType = ContentManager.Select("test_player");

            ////playerType.Stat.Agility = 10;
            ////playerType.Stat.Charm = 11;
            ////playerType.Stat.Health = 12;
            ////playerType.Stat.Intellect = 13;
            ////playerType.Stat.Strength = 14;
            ////playerType.Stat.WillPower = 15;

            ////playerType.Stat.MaxAgility = 20;
            ////playerType.Stat.MaxCharm = 21;
            ////playerType.Stat.MaxHealth = 22;
            ////playerType.Stat.MaxIntellect = 23;
            ////playerType.Stat.MaxStrength = 24;
            ////playerType.Stat.MaxWillPower = 25;

            ////playerType.HealthVitals.Current = 1000;
            ////playerType.HealthVitals.Maximum = 2000;

            ////for (int i = 0; i < playerType.Inventory.Item.Length; i++)
            ////{
            ////    playerType.Inventory.SetItemInformation(i, InventoryType.ITEM_TYPE, 9, -1);
            ////}

            ////for (int i = 0; i < playerType.Inventory.Key.Length; i++)
            ////{
            ////    playerType.Inventory.SetItemInformation(i, InventoryType.KEY_TYPE, 172, 10);
            ////}

            //ContentManager.Save(playerType);
        }

        public void Cleanup()
        {
            
        }
    }
}
