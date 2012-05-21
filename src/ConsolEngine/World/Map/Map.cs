using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public class Map
    {
        private FieldType[][] _fields;

        public FieldType[][] Fields
        {
            get { return _fields; }
        }

        public Map()
        {
            _fields = new FieldType[0][];
        }

        public void Draw()
        {
            
        }
    }
}
