﻿using Chronometer.Core;
using Chronometer.IO;

namespace Chronometer
{
    class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();

        }
    }
}
