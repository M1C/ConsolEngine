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

        private Map()
        {
        }

        public bool IsFree(Point location)
        {
            return _fields[location.Top][location.Left] == FieldType.Empty;
        }

        public void Draw()
        {
            for (int top = 0; top < _fields.Length; top++)
            {
                for (int left = 0; left < _fields[top].Length; left++)
                {
                    switch (_fields[top][left])
                    {
                        case FieldType.Empty:
                            break;
                        case FieldType.Wall:
                            MConsole.DrawAt(new Point(top, left*2), "##");
                            break;
                    }
                }
            }
        }

        public static Map LoadFromString(string str)
        {
            var m = new Map();
            var lines = str.Split('\n').Select(l => l.Trim('\r')).ToArray();
            var maxCol = lines.Max(l => l.Length);

            m._fields = new FieldType[lines.Length][];
            for (int i = 0; i < m._fields.Length; i++)
                m._fields[i] = new FieldType[maxCol];

            for (int top = 0; top < lines.Length; top++)
            {
                for (int left = 0; left < lines[top].Length; left++)
                {
                    switch (lines[top][left])
                    {
                        case ' ':
                            m._fields[top][left] = FieldType.Empty;
                            break;
                        case '#':
                            m._fields[top][left] = FieldType.Wall;
                            break;
                    }
                }
            }

            return m;
        }
    }
}
