using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;


namespace SelectServer {

    class ClientState {
        public Socket socket;
        public byte[] readBuff = new byte[1024];
    }

    class MainClass {
        static Socket listenfd;
        static Dictionary<Socket, ClientState> clients = new Dictionary<Socket, ClientState>();
        static void Main(string[] args) {

            listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAdr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEp = new IPEndPoint(ipAdr, 8888);
            listenfd.Bind(ipEp);

            listenfd.Listen(0);
            Console.WriteLine("[服务器]启动成功!");

            List<Socket> checkRead = new List<Socket>();

            while (true) {
                checkRead.Clear();
                checkRead.Add(listenfd);
                foreach (var item in clients.Values) {
                    checkRead.Add(item.socket);
                }

                Socket.Select(checkRead, null, null, 1000);

                foreach (var item in checkRead) {
                    if (item == listenfd) {
                        ReadListenfd(item);
                    } else {
                        ReadClientfd(item);
                    }
                }
            }
        }

        private static void ReadListenfd(Socket item) {
            Console.WriteLine("Accept");
            Socket clientfd = item.Accept();
            ClientState state = new ClientState();
            state.socket = clientfd;
            clients.Add(clientfd, state);
        }

        private static bool ReadClientfd(Socket clientfd) {
            ClientState state = clients[clientfd];

            int count = 0;

            try {
                count = clientfd.Receive(state.readBuff);
            } catch (SocketException se) {

                clientfd.Close();
                clients.Remove(clientfd);
                Console.WriteLine("Receive SocketException"+se.ToString());
                return false;

            }

            if (count == 0) {
                clientfd.Close();
                clients.Remove(clientfd);
                Console.WriteLine("Socket Close");
                return false;
            }

            string recvStr = System.Text.Encoding.UTF8.GetString(state.readBuff, 0, count);
            string[] splits = recvStr.Split('|');
            Console.WriteLine("Receive" + recvStr);
            string msgName = splits[0];
            string msgArgs = splits[1];
            string funName = "Msg" + msgName;
            MethodInfo mi = typeof(MsgHandler).GetMethod(funName);
            object[] o = { state, msgArgs };
            mi.Invoke(null, o);

            //string sendStr = recvStr;
            //byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(sendStr);
            //foreach (var item in clients.Values) {
            //    item.socket.Send(sendBytes);
            //}

            return true;
        }
    }
}
