using System.Collections.Generic;

namespace AR.ProgrammingWithCSharp.CMS.DataAccessLayer
{
    public class InMemoryStorage
    {
        private readonly List<Record> _records = new List<Record>();

        public Record this[int index]
        {
            get
            {
                return _records[index];
            }
        }

        public int Length
        {
            get
            {
                return _records.Count;
            }
        }

        public bool AddRecord(params KeyValuePair<string, string>[] data)
        {
            if (data == null || data.Length == 0)
            {
                return false;
            }
            _records.Add(new Record(data));
            return true;
        }
    }

    public class Record
    {
        private readonly Dictionary<string, string> _data = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                if (_data.ContainsKey(key))
                {
                    return _data[key];
                }
                else
                {
                    return "";
                }
            }
        }

        internal Record(KeyValuePair<string, string>[] data)
        {
            foreach (var keyValue in data)
            {
                if (!_data.ContainsKey(keyValue.Key))
                {
                    _data.Add(keyValue.Key, keyValue.Value);
                }
            }
        }
    }
}
