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
    public class FactoryList : IFactoryList
    {
        private List<IFactory> _factories;
        private int _index;

        public FactoryList(int start_index = 0)
        {
            _index = start_index;
            _factories = new();
        }

        public IFactory this[int index]
        {
            get => _factories[index];
            set => _factories[index] = value;
        }

        public int Count
        {
            get
            {
                return _index;
            }
        }

        public bool IsReadOnly => ((ICollection<IFactory>)_factories).IsReadOnly;

        public void Add(IFactory factory)
        {
            AssignId(factory);
            _factories.Add(factory);
        }

        private void AssignId(IFactory factory)
        {
            factory.ID = _index++;
        }

        public bool Remove(IFactory factory)
        {
            return _factories.Remove(factory);
        }

        public override string ToString()
        {
            // sb = ""
            StringBuilder sb = new();

            // sb = "["
            sb.Append('[');

            // sb = "[obj, ..."
            for (int i = 0; i < _factories.Count; i++)
            {
                sb.Append(_factories[i].ToString());
                if (i + 1 != _factories.Count)
                    sb.Append(", ");
            }

            // sb = "[obj, ...]"
            sb.Append(']');

            return sb.ToString();
        }

        /// Function that read factories from json file and add them to the list
        public void LoadFromJson(string jsonFilePath)
        {

            // Read the JSON file
            Factory[]? readed_factories = JsonConvert.DeserializeObject<Factory[]>(File.ReadAllText(jsonFilePath));

            // Add the factories to the list
            if (readed_factories is not null)
            {
                foreach (var item in readed_factories)
                {
                    Add(item);
                }

            } else {
                throw new System.Text.Json.JsonException("Json file is empty");
            }
        }

        public string DumpToJson() => JsonConvert.SerializeObject(_factories, Formatting.Indented);

        public int IndexOf(IFactory item)
        {
            return ((IList<IFactory>)_factories).IndexOf(item);
        }

        public void Insert(int index, IFactory item)
        {
            ((IList<IFactory>)_factories).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<IFactory>)_factories).RemoveAt(index);
        }

        public void Clear()
        {
            ((ICollection<IFactory>)_factories).Clear();
        }

        public bool Contains(IFactory item)
        {
            return ((ICollection<IFactory>)_factories).Contains(item);
        }

        public void CopyTo(IFactory[] array, int arrayIndex)
        {
            ((ICollection<IFactory>)_factories).CopyTo(array, arrayIndex);
        }

        public IEnumerator<IFactory> GetEnumerator()
        {
            return ((IEnumerable<IFactory>)_factories).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_factories).GetEnumerator();
        }
    }
}