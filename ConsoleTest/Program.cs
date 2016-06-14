using System;
using JsonParse;

namespace ConsoleTest
{
    class Program
    {
        public const string TransferNewLine = @"\n";

        static void Main(string[] args)
        {
           JsonParser jsonParser = new JsonParser();
            var handleString = jsonParser.HandleString("sdfsdf");
        }
    }
}
