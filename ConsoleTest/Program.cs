using System;
using System.Text;
using JsonParse;

namespace ConsoleTest
{
    class Program
    {
        public const string TransferNewLine = @"\n";

        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder("sdfsdf");
            var contains = str.Append("sdfsdf");
            int[] sdf = new[] {1, 3, 4, 5, 6};
            var length = sdf.Length;
            Console.WriteLine("sdfsdf");

            JsonParser jsonParser = new JsonParser();
            string inputString = "{\"UserID\":53568,\"FirstName\":\"Kat\",\"LastName\":\"Burke\",\"City\":{\"Count\":2342234,\"Name\":\"Omsk\",\"Country\":{\"Name\":\"Russia\"}}}";

            var handleString = jsonParser.HandleString(inputString);
        }
    }
}
