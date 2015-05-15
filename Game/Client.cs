using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace Game
{
    class Client
    {
        public PlayerDataPack.Data manager = new PlayerDataPack.Data();
        const int free_port = 11000;
        byte[] commandToGetPack = new byte[] { 0 };
        byte[] bytes = new byte[128]; 
        int count;
        byte[] subBytes = new byte[128];
        string IPhost;

        public Client(string IPhost)
        {
            this.IPhost = IPhost;
        }
        public void sendPackToServer( Socket sender, PlayerDataPack export)
        {
            // Отправляем данные через сокет
            //byte[] bytes = new byte[128];           
            bytes = export.InfoToBytes();
            byte[] sendBytes = commandToGetPack.Concat(bytes).ToArray();

            count = sendMessage(sender, sendBytes);
            
        }



        public List<PlayerDataPack.Data> getOtherPlayerPacks()
        {
            Socket sender = initConnection();
            sendCommandToSendAmountOfPacks(sender);
            byte[] bytes = new byte[1024];
            List<PlayerDataPack.Data> dataList = new List<PlayerDataPack.Data>();
            PlayerDataPack pack = new PlayerDataPack();
            // int count;
            count = sender.Receive(bytes);
            byte[] subBytes = new byte[1024];
            int subBytes_length = -1;

            for (int i = 0; i < count; i++)
            {
                int j;
                for (j = i; i <= i + 3; j++)
                {
                    if (bytes[j] != 4)              // разделитель - 4 4 4 4
                    {
                        break;
                    }
                }
                if (j != i + 4)
                {
                    subBytes_length++;
                    subBytes[subBytes_length] = bytes[i];
                }
                else
                {
                    i = i + 3;
                    pack.bytesToInfo(subBytes);
                    dataList.Add(pack.Info);

                    subBytes = new byte[1024];
                    subBytes_length = -1;
                }
            }
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return dataList;
        }

        public List<string> getOtherPlayerNames(Socket sender)
        {
            //Socket sender = initConnection();
            //sendCommandToSendAmountOfPacks(sender);
            byte[] bytes = new byte[1024];
            List<string> nameList = new List<string>();
            string name;
           // int count;
            count = sender.Receive(bytes);
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            byte[] subBytes = new byte[1024];
            int subBytes_length = -1;

            for (int i = 0; i < count; i++)
            {
                int j;
                for (j = i; i <= i + 3; j++)
                {
                    if (bytes[j] != 4)              // разделитель - 4 4 4 4
                    {
                        break;
                    }                  
                }
                if (j != i + 4)
                {
                    subBytes_length++;
                    subBytes[subBytes_length] = bytes[i];
                }
                else
                {
                    i = i + 3;
                    byte[] bufBytes = new byte[subBytes_length+1];
                    for (int k = 0; k < subBytes_length; k++)
                    {
                        bufBytes[k] = subBytes[k];
                    }
                    name = Encoding.Unicode.GetString(bufBytes);
                    nameList.Add(name);

                    subBytes = new byte[1024];
                    subBytes_length = -1;
                }
            }
            return nameList;
        }

        public void sendDataPack(PlayerDataPack export)
        {
            try
            {
                Socket sender = initConnection();
               // sendCommandToGetPack(sender);
                sendPackToServer(sender,export);
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

       

        public void sendCommandToSendAmountOfPacks(Socket sender)
        {
            byte[] bytes = new byte[1];
            bytes[0] = 1;
            count = sendMessage(sender, bytes);
        }

        public void sendCommandToSendPacks()
        {
            Socket sender = initConnection();
            byte[] bytes = new byte[2];
            bytes[0] = 2;
            count = sendMessage(sender, bytes);
            //// Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }

        private void sendCommandToGetPack(Socket sender)
        {
            byte[] bytes = new byte[1];
            bytes[0] = 0;
            count = sendMessage(sender, bytes);
        }


        private Socket initConnection()
        {
            IPAddress ipAddr = IPAddress.Parse(IPhost);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, free_port);
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(ipEndPoint);
            return sender;
        }

        public List<string> namesExchange(string name)
        { 
            byte[] msg = Encoding.Unicode.GetBytes(name);
            Socket sender = initConnection();
            byte[] command = new byte[1];
            command[0] = 2;
            msg = command.Concat(msg).ToArray();
            sender.Send(msg);
            return getOtherPlayerNames(sender);

        }

        private int sendMessage(Socket sender, byte[] message)
        {
            return sender.Send(message);
        }
    }
}
