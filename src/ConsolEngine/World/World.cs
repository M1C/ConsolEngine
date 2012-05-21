using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsolEngine
{
    public class World
    {
        private List<Entity> entities;
        private List<Effect> effects; 
        private Thread tickThread;

        public const int TickTime = 40;

        public World()
        {
            entities = new List<Entity>();
            effects = new List<Effect>();
            tickThread = new Thread(Tick);

            tickThread.Start();
        }

        private void Tick()
        {
            var stop = new Stopwatch();
            while (true)
            {
                stop.Restart();
                foreach (var effect in effects)
                {
                    effect.Apply(this);
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    foreach (var e in entities.OfType<IEntityKeyHandler>())
                    {
                        e.HandleKey(key);
                    }
                }

                Draw();
                stop.Stop();
                if (TickTime - stop.ElapsedMilliseconds > 0)
                    Thread.Sleep(TickTime - (int)stop.ElapsedMilliseconds);
            }
        }

        public static int SecondTick(int sec = 1)
        {
            return (1000 / TickTime) * sec;
        }

        public void Draw()
        {
            foreach (var entity in entities)
            {
                entity.Draw();
            }
        }

        #region Collection Methods
        public void AddEntity(Entity e)
        {
            if (entities.Any(ee => ee.Name == e.Name))
                throw new ArgumentException("Entity exists allready!", "e");
            entities.Add(e);
        }

        public void AddEffect(Effect e)
        {
            if (effects.Any(ee => ee.Name == e.Name))
                throw new ArgumentException("Effect exists allready!", "e");
            effects.Add(e);
        }
        #endregion

    }
}
