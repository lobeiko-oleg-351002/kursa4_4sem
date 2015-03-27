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
        public void sendPackToServer( Socket sender, PlayerDataPack export)
        {
            // Буфер для входящих данных
            
            //playerData.info = export;
            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            //IPHostEntry ipHost = Dns.GetHostEntry("192.168.0.102");
            //IPAddress ipAddr = ipHost.AddressList[0];
           // IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
           // IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            //Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            //sender.Connect(ipEndPoint);

            

            // Отправляем данные через сокет
            //byte[] bytes = new byte[128];           
            bytes = export.InfoToBytes();
            byte[] sendBytes = commandToGetPack.Concat(bytes).ToArray();

            count = sendMessage(sender, sendBytes);

            // Получаем ответ от сервера
            //int bytesRec = sender.Receive(bytes);
           // List<PlayerDataPack.Data> list = new List<PlayerDataPack.Data>();
            //list = export.bytesToListOfStruct(bytes);
            //return list;

            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
            //if (message.IndexOf("<TheEnd>") == -1)
            //    SendMessageFromSocket(port);

            //// Освобождаем сокет
            
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

            

            //int countOfPlayers = bytes[0];
            //for (int i = 0; i < countofplayers; i++)
            //{
            //    count = sender.receive(bytes);
            //    pack.bytestoinfo(bytes);
            //    datalist.add(pack.info);
            //}

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return dataList;
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

        

        public int getAmountOfPacks()
        {          
            try
            {
                //sendCommandToSendAmountOfPacks();
                //byte[] bytes = new byte[1024];
                Socket sender = initConnection();
                count = sender.Receive(bytes);
                // return BitConverter.ToInt32(bytes);
                return bytes[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
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
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, free_port);
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(ipEndPoint);
            return sender;
        }

        private int sendMessage(Socket sender, byte[] message)
        {
            return sender.Send(message);
        }
    }
}
