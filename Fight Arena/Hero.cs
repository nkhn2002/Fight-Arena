using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_Arena
{
    class Hero
    {
        private string name;
        private int hitpoint;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Hitpoint
        {
            get { return hitpoint; }
            set { hitpoint = value; }
        }

        public Hero()
        {

        }

        public Hero(string _name, int _hitpoint)
        {
            Name = _name;
            Hitpoint = _hitpoint;
        }
    }
}
