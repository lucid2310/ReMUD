using ReMUD.Game.Structures;

namespace ReMUD.Game.Managers
{
    public abstract class BaseManager<T, K> : IManager
    {
        public const string BTRIEVE_DLL = "WBTRV32.DLL";
        public const int KEY_BUF_LEN = 255;
        public ushort Status = 0;
        public byte[] PositionBlock = new byte[128];
        public int RecordSize = 0;
        public char[] FileName = new char[0];
        public ContentTypes ContentType = ContentTypes.Actions;
        public ContentStorage<K> Contents = new ContentStorage<K>();
        protected SpellType ProxyRecordData = new SpellType();

        public abstract ushort Initialize(string path);
        public abstract ushort Close();
        public abstract K Select(T id);
        public virtual ushort Reload() { return Btrieve.BtrieveTypes.BtrieveStatus.I_O_ERROR; }

        public virtual ushort Update(K record) { return Btrieve.BtrieveTypes.BtrieveStatus.I_O_ERROR; }
        public virtual ushort Delete(K record) { return Btrieve.BtrieveTypes.BtrieveStatus.I_O_ERROR; }
        public virtual ushort Insert(K record) { return Btrieve.BtrieveTypes.BtrieveStatus.I_O_ERROR; }

        public K GetNullContent()
        {
            return default(K);
        }

        public int Count
        {
            get
            {
                return Contents.Count();
            }
        }

        protected K BaseSelect(string id)
        {
            if(Contents.ContainsKey(id) == true)
            {
                return Contents.Get(id);
            }

            return default(K);
        }

        protected K BaseSelect(int id)
        {
            if (Contents.ContainsKey(id) == true)
            {
                return Contents.Get(id);
            }

            return default(K);
        }
    }
}
