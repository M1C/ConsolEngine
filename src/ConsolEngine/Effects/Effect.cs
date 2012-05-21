using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public abstract class Effect
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public abstract void Apply(World w);
    }
}
