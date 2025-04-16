using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using idz1.FactoryIntefraces;
using idz1.FactoryObjects;
using idz1.Properties;
using Newtonsoft.Json;

namespace idz1.Collections
{
    public class TankList : ITankList
    {
        private List<ITank> _tanks;
        private int _index;

        public TankList(int start_index = 0)
        {
            _index = start_index;
            _tanks = new();
        }

        public ITank this[int index]
        {
            get => _tanks[index];
            set => _tanks[index] = value;
        }

        public int Count
        {
            get
            {
                return _index;
            }
        }

        public bool IsReadOnly => ((ICollection<ITank>)_tanks).IsReadOnly;

        public void Add(ITank fact)
        {
            AssignId(fact);
            _tanks.Add(fact);
        }

        private void AssignId(ITank fact)
        {
            fact.ID = _index++;
        }

        public bool Remove(ITank fact)
        {
            return _tanks.Remove(fact);
        }

        public override string ToString()
        {
            // sb = ""
            StringBuilder sb = new();

            // sb = "["
            sb.Append('[');
            
            // sb = "[obj, ..."
            for (int i = 0; i < _tanks.Count; i++)
            {
                sb.Append(_tanks[i].ToString());
                if (i + 1 != _tanks.Count)
                    sb.Append(',');
            }
            
            // sb = "[obj, ...]"
            sb.Append(']');
            
            return sb.ToString();
        }

        public void LoadFromJson(string jsonFilePath)
        {

            // Read the JSON file
            Tank[]? readed_tanks = JsonConvert.DeserializeObject<Tank[]>(File.ReadAllText(jsonFilePath));

            // Add the factories to the list
            if (readed_tanks is not null)
            {
                _tanks = new(readed_tanks);

            } else {
                throw new System.Text.Json.JsonException("Json file is empty");
            }
        }

        public string DumpToJson() => JsonConvert.SerializeObject(_tanks, Formatting.Indented);

        public int IndexOf(ITank item)
        {
            return ((IList<ITank>)_tanks).IndexOf(item);
        }

        public void Insert(int index, ITank item)
        {
            ((IList<ITank>)_tanks).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ITank>)_tanks).RemoveAt(index);
        }

        public void Clear()
        {
            ((ICollection<ITank>)_tanks).Clear();
        }

        public bool Contains(ITank item)
        {
            return ((ICollection<ITank>)_tanks).Contains(item);
        }

        public void CopyTo(ITank[] array, int arrayIndex)
        {
            ((ICollection<ITank>)_tanks).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ITank> GetEnumerator()
        {
            return ((IEnumerable<ITank>)_tanks).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_tanks).GetEnumerator();
        }
    }

}
