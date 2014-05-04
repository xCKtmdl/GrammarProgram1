using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaron.net.SpecialObjects
{
    public class KeyValueList<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }
}
