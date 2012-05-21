﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public abstract class Entity
    {
        protected string _name;
        protected Point _location;
        protected bool _needsRedraw = false;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Point Location
        {
            get { return _location; }
            set
            {
                _location = value;
                _needsRedraw = true;
            }
        }

        public Entity(string name, Point location)
        {
            this._name = name;
            this._location = location;
        }

        public abstract void Draw();
    }
}
