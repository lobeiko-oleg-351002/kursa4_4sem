using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Game;

namespace Game
{
    class Server
    {
        public const int PLAYERS_LIMIT = 7;
        public Socket sListener;
        private byte[] separator = new byte[] {4,4,4,4};
        List<PlayerDataPack.Data> playersData = new List<PlayerDataPack.Data>();
        PlayerDataPack.Data pack = new PlayerDataPack.Data();
        PlayerDataPack playerDataPack = new PlayerDataPack();
        byte[] bytes = new byte[1024];
        byte[] bytesInfo = new byte[1024];
        byte[] sendBytes = new byte[1024];
        byte[] bufBytes = new byte[1024];
        int sendBytes_length = 0;
        public void startServer()
        {

            // Устанавливаем для сокета локальную конечную точку
            //IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            //IPAddress ipAddr = ipHost.AddressList[0];
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Создаем сокет Tcp/Ip
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                // Начинаем слушать соединения
                while (true)
                {

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();

                    // Мы дождались клиента, пытающегося с нами соединиться

                    
                    int bytesRec = handler.Receive(bytes);

                    switch (bytes[0])
                    {
                        case 0:
                            getPlayerDataPack(handler,bytes,bytesRec);
                            break;
                        case 1:
                            sendPacks(handler);
                            break;

                    }
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private void getPlayerDataPack(Socket handler, byte[] bytes, int countOfBytes)
        {
           
           
            for (int i = 1; i < countOfBytes; i++)
            {
                bytesInfo[i - 1] = bytes[i];
            }

            //int countOfBytes = handler.Receive(bytesInfo);
            playerDataPack.bytesToInfo(bytesInfo);

            pack = playerDataPack.Info;
            bool newClient = true;
            int numClient = 0;
            
            for (int i = 0; i < playersData.Count; i++)
            {
                if (pack.id == playersData[i].id)
                {
                    newClient = false;
                    numClient = i;
                    break;
                }
            }

            if (newClient == true)
            {
                playersData.Add(pack);
            }
            else
            {
                playersData[numClient] = pack;
            }
        }

        private void sendAmountOfPacks()
        {
            Socket handler = sListener.Accept();
            //byte[] bytes = new byte[1024];
            bytes = BitConverter.GetBytes(playersData.Count);
            handler.Send(bytes);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

        }

        private void sendPacks(Socket handler)
        {
            //byte[] bytes = new byte[1024];
            //byte[] sendBytes = new byte[1024];
            sendBytes_length = 0;
            //byte[] bufBytes = new byte[1024];
           // bytes[0] = (byte)playersData.Count;
            //handler.Send(bytes);
            //Console.WriteLine(playersData.Count);
            for (int i = 0; i < playersData.Count; i++)
            {
                playerDataPack.Info = playersData[i];
                bytes = playerDataPack.InfoToBytes();
                
                bufBytes = bytes.Concat(separator).ToArray();
                for (int j = sendBytes_length; j < bufBytes.Length + sendBytes_length; j++)
                {
                    sendBytes[j] = bufBytes[j - sendBytes_length];
                }
                sendBytes_length += bufBytes.Length;

            }
            handler.Send(sendBytes);
        }


        static byte[] ConvertToByteArray(List<PlayerDataPack.Data> list)
        {

            Encoding encode = Encoding.ASCII;

            List<byte> listByte = new List<byte>();
            string[] ResultCollectionArray = list.Select(i => i.ToString()).ToArray<string>();

            foreach (var item in ResultCollectionArray)
            {
                foreach (byte b in encode.GetBytes(item))
                    listByte.Add(b);
                
            }

            return listByte.ToArray();

        }
        
        
    }
}
