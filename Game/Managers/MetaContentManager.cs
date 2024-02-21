using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Managers
{
    public class MetaContentManager
    {
        private Dictionary<Type, IManager> _contentManagers = new Dictionary<Type, IManager>();

        public MetaContentManager()
        {
            // TODO: Fix the ActionType size.
            //_contentManagers.Add(typeof(ActionManager), new ActionManager());
         //   _contentManagers.Add(typeof(BankManager), new BankManager());
            _contentManagers.Add(typeof(ClassManager), new ClassManager());
         //   _contentManagers.Add(typeof(GangManager), new GangManager());
            //_contentManagers.Add(typeof(ItemManager), new ItemManager());
            _contentManagers.Add(typeof(MessageManager), new MessageManager());
            //_contentManagers.Add(typeof(NPCManager), new NPCManager());
            _contentManagers.Add(typeof(PlayerManager), new PlayerManager());
            _contentManagers.Add(typeof(RaceManager), new RaceManager());
          //  _contentManagers.Add(typeof(RoomManager), new RoomManager());
          //  _contentManagers.Add(typeof(ShopManager), new ShopManager());
            _contentManagers.Add(typeof(SpellManager), new SpellManager());
           // _contentManagers.Add(typeof(TextBlockManager), new TextBlockManager());
        }

        public T Select<T>()
        {
            if(_contentManagers.ContainsKey(typeof(T)) == false)
            {
                return default(T);
            }

            return (T)_contentManagers[typeof(T)];
        }

        public ushort Initialize(string path)
        {
            ushort status = 0;

            foreach(var manager in _contentManagers)
            {
                status &= manager.Value.Initialize(path);
            }

            return status;
        }
    }
}
