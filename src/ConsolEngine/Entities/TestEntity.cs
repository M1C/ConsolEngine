using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public class TestEntity : Entity, IEntityHasColor, IEntityKeyHandler
    {
        private ConsoleColor _color;

        public ConsoleColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
                _needsRedraw = true;
            }
        }
        
        public TestEntity(string name, Point location, ConsoleColor color) : base(name, location)
        {
            this._color = color;
        }

        public override void Draw()
        {
            if (_needsRedraw)
            {
                MConsole.DrawAt(Location, 'o', Color);
                _needsRedraw = true;
            }
        }

        public void HandleKey(ConsoleKeyInfo key)
        {
            switch(key.Key)
            {
                case ConsoleKey.UpArrow:
                    _location.Top--;
                    break;
                case ConsoleKey.DownArrow:
                    _location.Top++;
                    break;
                case ConsoleKey.LeftArrow:
                    _location.Left--;
                    break;
                case ConsoleKey.RightArrow:
                    _location.Left++;
                    break;
            }
        }
    }
}
