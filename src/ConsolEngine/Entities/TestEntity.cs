using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public class TestEntity : Entity, IEntityHasColor, IEntityKeyHandler
    {
        private Point _oldLocation;
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
                MConsole.DrawAt(new Point(_oldLocation.Top, _oldLocation.Left * 2), ' ', Color);
                MConsole.DrawAt(new Point(Location.Top, Location.Left*2), 'o', Color);
                _needsRedraw = false;
                _oldLocation = _location;
            }
        }

        public void HandleKey(ConsoleKeyInfo key)
        {
            var location = _location;
            switch(key.Key)
            {
                case ConsoleKey.UpArrow:
                    location.Top--;
                    break;
                case ConsoleKey.DownArrow:
                    location.Top++;
                    break;
                case ConsoleKey.LeftArrow:
                    location.Left--;
                    break;
                case ConsoleKey.RightArrow:
                    location.Left++;
                    break;
            }

            if (_world.IsFree(location))
                Location = location;
        }
    }
}
