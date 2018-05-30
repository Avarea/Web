using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestParser
{
    class StartUp
    {
        private static string HttpsResponseHeader = "HTTP/1.1 {0}\nContent-Lenght: {1}\nContent-Type: text/plain\n{2}";

        private static Dictionary<int, string> StatusTestByResponseCode = new Dictionary<int, string>()
        {
            {200, "OK"},
            {404, "Not Found" }
        };

        static void Main()
        {
            var pathByMethods = new Dictionary<string, List<string>>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                var splitInput = input.Substring(1).Split('/');
                var method = splitInput[1];
                var path = splitInput[0];

                if (!pathByMethods.ContainsKey(method))
                {
                    pathByMethods.Add(method, new List<string>() {path});
                }
                else
                {
                    pathByMethods[method].Add(path);
                }
                input = Console.ReadLine();
            }

            var request = Console.ReadLine();
            var requestSplit = request.Split();
            var requestMethod = requestSplit[0].ToLower();
            var requestPath = requestSplit[1].Substring(1);
            var response = string.Empty;

            var responsePath = pathByMethods.ContainsKey(requestMethod)? pathByMethods[requestMethod].FirstOrDefault(p => p.ToLower() == requestPath) : string.Empty;

            if (string.IsNullOrEmpty(responsePath))
            {
                var responseStatusCode = $"{StatusTestByResponseCode.Keys.FirstOrDefault(k => k == 404)} {StatusTestByResponseCode[404]}";
                response = string.Format(
                    HttpsResponseHeader,
                    responseStatusCode,
                    StatusTestByResponseCode[404].Length,
                    StatusTestByResponseCode[404]);
            }
            else
            {
                var responseStatusCode = $"{StatusTestByResponseCode.Keys.FirstOrDefault(k => k == 200)} {StatusTestByResponseCode[200]}";
                response = string.Format(
                    HttpsResponseHeader,
                    responseStatusCode,
                    StatusTestByResponseCode[200].Length,
                    StatusTestByResponseCode[200]);
            }

            Console.WriteLine(response);
        }
    }
}
