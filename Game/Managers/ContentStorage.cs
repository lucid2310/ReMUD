using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Managers
{
    public class ContentStorage<T>
    {
        private Dictionary<int, T> _storageOne = new Dictionary<int, T>();
        private Dictionary<string, T> _storageTwo = new Dictionary<string, T>();

        public int Count()
        {
            return _storageOne.Count + _storageTwo.Count;
        }

        public Dictionary<int, T> Storage
        {
            get { return _storageOne;}
            set { _storageOne = value; }
        }

        public void Update(int id, T item)
        {
            if(_storageOne.ContainsKey(id) == true)
            {
                _storageOne[id] = item;
            }
        }

        public void Update(string id, T item)
        {
            if(_storageTwo.ContainsKey(id) == true)
            {
                _storageTwo[id] = item;
            }
        }

        public void Add(int id, T item)
        {
            if (_storageOne.ContainsKey(id) == false)
            {
                _storageOne.Add(id, item);
            }
        }

        public void Add(string id, T item)
        {
            if(_storageTwo.ContainsKey(id) == false)
            {
                _storageTwo.Add(id, item);
            }
        }

        public bool ContainsKey(int id)
        {
            return _storageOne.ContainsKey(id);
        }

        public bool ContainsKey(string id)
        {
            return _storageTwo.ContainsKey(id);
        }

        public T Get(int id)
        {
            if(_storageOne.ContainsKey(id) == true)
            {
                return _storageOne[id];
            }

            return default(T);
        }

        public T Get(string id)
        {
            if (_storageTwo.ContainsKey(id) == true)
            {
                return _storageTwo[id];
            }

            return default(T);
        }
    }
}
