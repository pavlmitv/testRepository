using System;

namespace Chronometer.IO
{
    public class ConsoleReader
    {
        public string Read()
        {
            return Console.ReadLine().Trim();
        }
    }
}
