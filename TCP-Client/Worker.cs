using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace TCP_Client
{
    class Worker
    {
        public Worker()
        {

        }

        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 4646))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string command = Console.ReadLine();
                string parameter = Console.ReadLine();
                sw.WriteLine(command);
                sw.WriteLine(parameter);
                sw.Flush();

                string strRes = sr.ReadLine();
                Console.WriteLine(strRes);
            }
        }
    }
}
