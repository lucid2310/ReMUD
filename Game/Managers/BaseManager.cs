﻿using ReMUD.Game.Structures;

namespace ReMUD.Game.Managers
{
    public abstract class BaseManager<T, K> : IManager
    {
        public const string BTRIEVE_DLL = "WBTRV32.DLL";
        public const int KEY_BUF_LEN = 255;
        public short Status = 0;
        public byte[] PositionBlock = new byte[128];
        public int RecordSize = 0;
        public char[] FileName = new char[0];
        public ContentTypes ContentType = ContentTypes.Actions;
        public ContentStorage<K> Contents = new ContentStorage<K>();

        public abstract short Initialize(string path);
        public abstract short Close();

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

        public abstract K Select(T id);

        public K BaseSelect(string id)
        {
            if(Contents.ContainsKey(id) == true)
            {
                return Contents.Get(id);
            }

            return default(K);
        }

        public K BaseSelect(int id)
        {
            if (Contents.ContainsKey(id) == true)
            {
                return Contents.Get(id);
            }

            return default(K);
        }
    }
}
