using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text.Json;

namespace Dane
{
    internal class Logger
    {
        private static List<Orb> orbs;
        private Stopwatch stopWatch = new Stopwatch();

        public Logger(List<Orb> orbs)
        {
            orbs = orbs;
            Thread t = new Thread(() =>
            {
                stopWatch.Start();
                while (true)
                {
                    if (stopWatch.ElapsedMilliseconds >= 5)
                    {
                        stopWatch.Restart();
                        using (StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\orbLog.txt", true))
                        {
                            string stamp = ($"So anyway, I started logging... {DateTime.Now:R}");
                            foreach (Orb orb in orbs)
                            {
                                streamWriter.WriteLine(stamp + JsonSerializer.Serialize(orb));
                            }
                            
                        }
                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        public void stop()
        {
            stopWatch.Reset();
            stopWatch.Stop();
        }
    }
}
