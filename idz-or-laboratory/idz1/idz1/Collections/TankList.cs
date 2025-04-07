using System;
using System.Collections.Generic;
using System.Text;
using idz1.FactoryIntefraces;

namespace idz1.Collections
{
    public class TankList : ITankList
    {
        private readonly List<ITank> _tanks;
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

        public int Length
        {
            get
            {
                return _index;
            }
        }

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
    }

}
