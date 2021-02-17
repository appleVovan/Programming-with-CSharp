using System;
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

        public bool UpdateRecord(string id, params KeyValuePair<string, string>[] data)
        {
            var result = false;
            for (int i = 0; i < Length; i++)
            {
                if (_records[i]["Id"] == id)
                {
                    _records[i].Update(data);  
                    return true;
                }
            }
            return result;
        }

        public void RemoveAllMatchingRecords(string key, string value)
        {
            int i=0;
            while (i < Length)
            {
                if (_records[i][key] == value)
                {
                    _records.Remove(_records[i]);
                    i--;
                }
                i++;
            }
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

        internal void Update(KeyValuePair<string, string>[] data)
        {
            foreach (var keyValue in data)
            {
                if (!_data.ContainsKey(keyValue.Key))
                {
                    _data.Add(keyValue.Key, keyValue.Value);
                }
                else
                {
                    _data[keyValue.Key] = keyValue.Value;
                }
            }
        }
    }
}
