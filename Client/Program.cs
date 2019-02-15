using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Xml.Serialization;
using Core;

namespace Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            var port = 3000;
            var address = "127.0.0.1";
            
            var requestSerializer = new XmlSerializer(typeof(QuoteRequest));
            var responseSerializer = new XmlSerializer(typeof(QuoteResponse));
            string directoryPath = @"C:\Users\ftd-04\source\repos\dotnet-rest-controller-assignment-LucasJenkins\dotnet-io-concurrency-assignment-LucasJenkins\Files";

            // Example QuoteRequest containing symbols and fields client wishes to fetch data about
            var request = new QuoteRequest();
            Console.WriteLine("Please specify interval between 1-10, followed by 3 request, followed by 3 companies");
            
            
            foreach (var x in args)
            {
                switch (args)
                {
                    case:
                       request.
                    case:
                        break;
                    case:
                        break;
                    case:
                        break
                }
            }
            
            
            
            try
            {
                // Initialize connection to server
                var client = new TcpClient(address, port);
            
                using (var stream = client.GetStream())
                {
                    // Serialize request to server
                    requestSerializer.Serialize(stream, request);
                    
                    // Temporary hacky fix for data preventing read blocking
                    client.Client.Shutdown(SocketShutdown.Send);
                    
                    // Receive QuoteResponse from server
                    QuoteResponse response = (QuoteResponse) responseSerializer.Deserialize(stream);
                    File.WriteAllText(directoryPath,response.QuoteString);                
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}