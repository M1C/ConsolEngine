using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public static class MConsole
    {
        private static List<DrawJob> _jobs;

        private struct DrawJob
        {
            public string Text;
            public int Lenght
            {
                get { return Text.Length; }
            }
            public Point Location;
            public ConsoleColor FrontColor;
            public ConsoleColor BackColor;

            public void Do()
            {
                
            }
        }

        static MConsole()
        {
            _jobs = new List<DrawJob>(1000);
        }

        public static void FireBatch()
        {
            SortJobs();

            foreach (var job in _jobs)
            {
                job.Do();
            }
        }

        private static void SortJobs()
        {
            var colors = _jobs.Select(j => j.FrontColor).Distinct();
            var jobs = colors.SelectMany(c => _jobs.Where(j => j.FrontColor == c).OrderBy(j => j.BackColor)).ToArray();

            _jobs.Clear();
            _jobs.AddRange(jobs);
        }

        public static void DrawAt(Point loc, object o, ConsoleColor fColor = ConsoleColor.White, ConsoleColor bColor = ConsoleColor.Black)
        {
            _jobs.Add(new DrawJob
                          {
                              Text = o.ToString(),
                              Location = loc,
                              BackColor = bColor,
                              FrontColor = fColor
                          });
        }
    }
}
