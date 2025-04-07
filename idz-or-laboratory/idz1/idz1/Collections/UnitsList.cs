using System;
using System.Collections.Generic;
using System.Text;
using idz1.FactoryIntefraces;

namespace idz1.Collections
{
    public class UnitList : IUnitsList
    {
        private readonly List<IUnit> _unitsList;
        private int _index;

        public UnitList(int start_index = 0)
        {
            _index = start_index;
            _unitsList = new();
        }

        public IUnit this[int index]
        {
            get => _unitsList[index];
            set => _unitsList[index] = value;
        }

        public int Length
        {
            get
            {
                return _index;
            }
        }

        public void Add(IUnit unit)
        {
            AssignId(unit);
            _unitsList.Add(unit);
        }

        private void AssignId(IUnit unit)
        {
            unit.ID = _index++;
        }

        public bool Remove(IUnit unit)
        {
            return _unitsList.Remove(unit);
        }

        public override string ToString()
        {
            // sb = ""
            StringBuilder sb = new();

            // sb = "["
            sb.Append('[');

            // sb = "[obj, ..."
            for (int i = 0; i < _unitsList.Count; i++)
            {
                sb.Append(_unitsList[i].ToString());
                if (i + 1 != _unitsList.Count)
                    sb.Append(',');
            }

            // sb = "[obj, ...]"
            sb.Append(']');

            return sb.ToString();
        }
    }
}
