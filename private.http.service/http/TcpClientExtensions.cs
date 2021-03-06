using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace @private.http.service.http
{
    /// <summary>
    /// Provides the ReadLine extension for a TcpClient
    /// </summary>
    public static class TcpClientExtensions
    {
        /// <summary>
        /// Reads one line of data from the TcpClient
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string ReadLine(this TcpClient client)
        {
            var stream = client.GetStream();
            var data = new List<char>();
            while (true)
            {
                var thisChar = stream.ReadByte();
                if (thisChar == '\n') break;
                if (thisChar == '\r') continue;
                if (thisChar < 0)
                {
                    Thread.Sleep(0);
                    break;
                    //continue;
                }
                data.Add(Convert.ToChar(thisChar));
            }
            return string.Join(string.Empty, data);
        }
    }
}