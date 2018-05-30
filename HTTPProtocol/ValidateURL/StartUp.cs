using System;
using System.Net;
using System.Text;

namespace ValidateURL
{
    class StartUp
    {
        static void Main()
        {
            var stringToDecode = Console.ReadLine();
            var decodedResult = WebUtility.UrlDecode(stringToDecode);

            try
            {
                var parsedUrl = new Uri(decodedResult);
                
                if (string.IsNullOrWhiteSpace(parsedUrl.Scheme) ||
                    string.IsNullOrWhiteSpace(parsedUrl.Host) ||
                    string.IsNullOrWhiteSpace(parsedUrl.LocalPath))
                {
                    throw new ArgumentException("Invalid URL");
                }

                if ((parsedUrl.Scheme == "https" && parsedUrl.Port != 443) || (parsedUrl.Scheme == "http" && parsedUrl.Port != 80))
                {
                    throw new ArgumentException("Invalid URL");
                }

                var builder = new StringBuilder();
                builder
                    .AppendLine($"Protocol: {parsedUrl.Scheme}")
                    .AppendLine($"Host: {parsedUrl.Host}")
                    .AppendLine($"Port: {parsedUrl.Port}")
                    .AppendLine($"Path: {parsedUrl.LocalPath}");


                if (!string.IsNullOrWhiteSpace(parsedUrl.Query))
                {
                    builder.AppendLine($"Query: {parsedUrl.Query.Substring(1)}");
                }

                if (!string.IsNullOrWhiteSpace(parsedUrl.Fragment))
                {
                    builder.AppendLine($"Fragment: {parsedUrl.Fragment.Substring(1)}");
                }

                Console.WriteLine(builder.ToString().Trim());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
