using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingTest2
{
    public class Shot
    {
        public string Value;

        public Shot(string value = "") {
            Value = value;
        }

        public int GetValue()
        {
            if (Value.Equals("-")) return 0;
            if (Value.Equals("")) return 0;
            if (Value.Equals("X")) return 10;
            return Convert.ToInt32(Value);
        }
    }
}
