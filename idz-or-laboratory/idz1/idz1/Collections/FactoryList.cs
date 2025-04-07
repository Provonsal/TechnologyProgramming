using System.Collections.Generic;
using System.Text;
using idz1.FactoryIntefraces;

namespace idz1.Collections
{
    public class FactoryList : IFactoryList
    {
        private readonly List<IFactory> _factories;
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

        public int Length
        {
            get
            {
                return _index;
            }
        }

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
                    sb.Append(',');
            }
            
            // sb = "[obj, ...]"
            sb.Append(']');
            
            return sb.ToString();
        }
    }

}