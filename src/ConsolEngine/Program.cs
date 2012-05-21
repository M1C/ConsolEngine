using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mapStr =
@"######
#    #
#    #
#    #
#    #
#    #
######";
            Console.CursorVisible = false;

            var w = new World();
            w.Map = Map.LoadFromString(mapStr);
            var ent = new TestEntity("test1", new Point(2, 2), ConsoleColor.Red);
            var eff = new ColorBlinkEntityEffect(ent, ent.Color, ConsoleColor.Blue, World.SecondTick(5));

            w.AddEntity(ent);
            w.AddEffect(eff);

            w.Start();
        }
    }
}
