using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_Arena
{
    class Defence
    {
        private int defence;

        public int DefenceR
        {
            get { return defence; }
            set { defence = value; }
        }

        public Defence()
        {

        }

        public Defence(int _defence)
        {
            DefenceR = _defence;
        }

        // Get the defence (or defence range) 
        public int GetRange(Defence defence)
        {
            int range = defence.DefenceR;
            return range;
        }
    }
}
