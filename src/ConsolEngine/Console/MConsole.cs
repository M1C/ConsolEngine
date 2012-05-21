using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public static class MConsole
    {
        private static Point _location;
        private static ConsoleColor _fColor;
        private static ConsoleColor _bColor;

        public static ConsoleColor ForegroundColor
        {
            get { return _fColor; }
            set
            {
                if (value != _fColor)
                {
                    _fColor = value;
                    Console.ForegroundColor = _fColor;
                }
            }
        }

        public static ConsoleColor BackgroundColor
        {
            get { return _bColor; }
            set
            {
                if (value != _bColor)
                {
                    _bColor = value;
                    Console.BackgroundColor = _bColor;
                }
            }
        }

        public static Point CursorLocation
        {
            get { return _location; }
            set
            {
                if (value.Left != _location.Left)
                    Console.CursorLeft = value.Left;
                if (value.Top != _location.Top)
                    Console.CursorTop = value.Top;

                _location = value;
            }
        }

        private static List<DrawJob> _jobs;

        private struct DrawJob
        {
            public string Text;
            public int Lenght
            {
                get { return Text.Length; }
            }
            public Point Location;
            public ConsoleColor ForeColor;
            public ConsoleColor BackColor;

            public void Do()
            {
                CursorLocation = Location;
                Console.Write(Text);
                Console.CursorLeft -= Lenght;
            }
        }

        static MConsole()
        {
            _jobs = new List<DrawJob>(1000);
        }

        public static void FireBatch()
        {
            var jobs = SortJobs();

            foreach (var jj in jobs)
            {
                ForegroundColor = jj.Key;
                foreach (var job in jj.Value)
                {
                    BackgroundColor = job.BackColor;
                    job.Do();
                }
            }
        }

        private static Dictionary<ConsoleColor, DrawJob[]> SortJobs()
        {
            var colors = _jobs.Select(j => j.ForeColor).Distinct();
            var jobs = colors.ToDictionary(c => c,
                                           c => _jobs.Where(j => j.ForeColor == c).ToArray());
            _jobs.Clear();
            return jobs;
        }

        public static void DrawAt(Point loc, object o, ConsoleColor fColor = ConsoleColor.White, ConsoleColor bColor = ConsoleColor.Black)
        {
            _jobs.Add(new DrawJob
                          {
                              Text = o.ToString(),
                              Location = loc,
                              BackColor = bColor,
                              ForeColor = fColor
                          });
        }
    }
}
