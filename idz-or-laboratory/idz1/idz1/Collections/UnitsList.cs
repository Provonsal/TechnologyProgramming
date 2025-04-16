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
    public class UnitList : IUnitsList
    {
        private List<IUnit> _unitsList;
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

        public int Count
        {
            get
            {
                return _index;
            }
        }

        public bool IsReadOnly => ((ICollection<IUnit>)_unitsList).IsReadOnly;

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

        public void LoadFromJson(string jsonFilePath)
        {

            // Read the JSON file
            Unit[]? readed_units = JsonConvert.DeserializeObject<Unit[]>(File.ReadAllText(jsonFilePath));

            // Add the factories to the list
            if (readed_units is not null)
            {
                _unitsList = new(readed_units);

            } else {
                throw new System.Text.Json.JsonException("Json file is empty");
            }
        }

        public string DumpToJson() => JsonConvert.SerializeObject(_unitsList, Formatting.Indented);

        public int IndexOf(IUnit item)
        {
            return ((IList<IUnit>)_unitsList).IndexOf(item);
        }

        public void Insert(int index, IUnit item)
        {
            ((IList<IUnit>)_unitsList).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<IUnit>)_unitsList).RemoveAt(index);
        }

        public void Clear()
        {
            ((ICollection<IUnit>)_unitsList).Clear();
        }

        public bool Contains(IUnit item)
        {
            return ((ICollection<IUnit>)_unitsList).Contains(item);
        }

        public void CopyTo(IUnit[] array, int arrayIndex)
        {
            ((ICollection<IUnit>)_unitsList).CopyTo(array, arrayIndex);
        }

        public IEnumerator<IUnit> GetEnumerator()
        {
            return ((IEnumerable<IUnit>)_unitsList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_unitsList).GetEnumerator();
        }
    }
}
