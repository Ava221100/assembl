using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Assembly_Code
{
    public class command
    {
        public string Op;
        public string A;
        public string B;
        public string C;

        public command(string op, string a, string b = null, string c = null)
        {
            Op = op;
            A = a;
            B = b;
            C = c;
        }
    }
}
