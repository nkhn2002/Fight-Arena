using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_Arena
{
    class Attack
    {
        private int attack;

        public int AttackR
        {
            get { return attack; }
            set { attack = value; }
        }

        public Attack()
        {

        }

        public Attack(int _attack)
        {
            AttackR = _attack;
        }

        // Get the attack damange (or range) 
        public int GetRange(Attack attack)
        {
            int range = attack.AttackR;
            return range;
        }
    }
}
