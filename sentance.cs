using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_prog
{
    class sentance
    {
        public string word;
        public long weight;
        public List<sentance> SubNodes;  
        public sentance()
        {
            weight = 0;
            word = "";
            SubNodes = new List<sentance>();
        }
        public sentance(string s)
        {
            weight = 0;
            word = s;
            SubNodes = new List<sentance>();
        }
        public sentance(string s, long w)
        {
            weight = w;
            word = s;
            SubNodes = new List<sentance>();
        }
    
    }
}
