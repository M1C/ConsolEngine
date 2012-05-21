using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public class ColorBlinkEntityEffect : EntityEffect
    {
        private ConsoleColor _firstColor;
        private ConsoleColor _secondColor;
        private int _delay;
        private int _delayCounter;

        public ConsoleColor FirstColor
        {
            get { return _firstColor; }
        }

        public ConsoleColor SecondColor
        {
            get { return _secondColor; }
        }

        public int Delay
        {
            get { return _delay; }
        }

        public ColorBlinkEntityEffect(Entity entity, ConsoleColor firstColor, ConsoleColor secondColor, int delay)
            : base(entity)
        {
            if(!(entity is IEntityHasColor))
                throw new ArgumentException("Entity must have color!", "entity");

            this._firstColor = firstColor;
            this._secondColor = secondColor;
            this._delay = delay;
            _delayCounter = _delay;
        }

        public override void Apply(World w)
        {
            if (--_delayCounter == 0)
            {
                var entity = (IEntityHasColor)Entity;
                entity.Color = entity.Color == FirstColor ? SecondColor : FirstColor;
                _delayCounter = _delay;
            }
        }
    }
}
