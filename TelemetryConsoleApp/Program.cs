using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Api;
using Telemetry.Data;
using Telemetry.Exceptions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.telemetryapp.com/flows/dashboard_graph_1/data");
            byte[] authBytes = Encoding.UTF8.GetBytes("a6a8c3fc67927398e5f28e0e03d3d68a7:");  // API Token, don't forget the colon
            httpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(authBytes));
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" +
                  "\"title\": \"Title 1\"," +
                  "\"bars\": [" +
                    "{" +
                      "\"color\": \"navy\"," +
                      "\"label\": \"Label 1\"," +
                      "\"value\": 32" +
                    "}," +
                    "{" +
                      "\"color\": \"navy\"," +
                      "\"label\": \"Label 2\"," +
                      "\"value\": 64" +
                    "}," +
                    "{" +
                      "\"color\": \"purple\"," +
                      "\"label\": \"Label 3\"," +
                      "\"value\": 78" +
                    "}" +
                  "]" +
                "}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }

    }
}
