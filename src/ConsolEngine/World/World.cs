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
        private List<Entity> _entities;
        private List<Effect> _effects;
        private Thread _tickThread;
        private Map _map;

        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }

        public const int TickTime = 40;

        public World()
        {
            _entities = new List<Entity>();
            _effects = new List<Effect>();
            _tickThread = new Thread(Tick);
        }

        public void Start()
        {
            _tickThread.Start();
        }

        public bool IsFree(Point location)
        {
            return _map.IsFree(location) && _entities.Where(e => e.Collides).All(e => e.Location != location);
        }

        private void Tick()
        {
            var stop = new Stopwatch();
            while (true)
            {
                stop.Restart();
                foreach (var effect in _effects)
                {
                    effect.Apply(this);
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    foreach (var e in _entities.OfType<IEntityKeyHandler>())
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
            _map.Draw();
            foreach (var entity in _entities)
            {
                entity.Draw();
            }
            MConsole.FireBatch();
        }

        #region Collection Methods
        public void AddEntity(Entity e)
        {
            if (_entities.Any(ee => ee.Name == e.Name))
                throw new ArgumentException("Entity exists allready!", "e");
            _entities.Add(e);
            e.World = this;
        }

        public void AddEffect(Effect e)
        {
            if (_effects.Any(ee => ee.Name == e.Name))
                throw new ArgumentException("Effect exists allready!", "e");
            _effects.Add(e);
        }
        #endregion

    }
}
