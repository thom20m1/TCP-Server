using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Model;

namespace TCP_Server
{
    class Worker
    {
        private static List<Book> books = new List<Book>()
        {
            
            new Book("It", "Devin Mcquire", 150, 1000000000001),
            new Book("De Vises Sten", "J K Rowling", 320, 1000000000002),
            new Book("Mit Liv", "Bill Clinton", 400, 1000000000003),
            new Book("Fall of Giants", "Ken Follett", 900, 1000000000004)
        };
        public Worker()
        {

        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            
                while (true)
                {
                    TcpClient socket = server.AcceptTcpClient();

                    Task.Run(() =>
                    {
                        TcpClient tmpSocket = socket;
                        DoClient(socket);
                    });
                    
                    
                }
            
        }
        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string command = sr.ReadLine();
                string parameter = sr.ReadLine();

                if(command=="Hent Alle")
                {
                    string jsonResp = JsonConvert.SerializeObject(books);
                    sw.WriteLine(jsonResp);
                }
                else if(command == "Hent")
                {
                    string jsonResp="Der er ingen bøger med denne ISBN";
                    foreach(Book b in books)
                    {
                        if(b.ISBN13.ToString()==parameter)
                        {
                            jsonResp = JsonConvert.SerializeObject(b);
                        }
                    }
                    sw.WriteLine(jsonResp);
                }
                else if(command =="Gem")
                {
                    Book tmpBook = JsonConvert.DeserializeObject<Book>(parameter);
                    books.Add(tmpBook);
                    sw.WriteLine("");
                }
                sw.Flush();

            }
        }

    }
}
