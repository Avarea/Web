using System;
using System.Net;

namespace URLDecode
{
    class StartUp
    {
        static void Main()
        {
            var stringToDecode = Console.ReadLine();
            var result = WebUtility.UrlDecode(stringToDecode);

            Console.WriteLine(result);
        }
    }
}
