using System;

namespace idz1.Properties
{
    public interface IJsonSerializable
    {
        public void LoadFromJson(string path);

        public string DumpToJson();
    }
}
