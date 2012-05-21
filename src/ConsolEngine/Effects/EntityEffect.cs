using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public abstract class EntityEffect : Effect
    {
        private Entity entity;
        public Entity Entity
        {
            get { return entity; }
        }

        protected EntityEffect(Entity entity) : base()
        {
            this.entity = entity;
        }
    }
}
