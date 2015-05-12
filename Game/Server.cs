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
        List<string> names = new List<string>();
        PlayerDataPack.Data pack = new PlayerDataPack.Data();
        PlayerDataPack playerDataPack = new PlayerDataPack();
        byte[] bytes = new byte[1024];
        byte[] bytesInfo = new byte[1024];
        Socket handler;
        int sendBytes_length = 0;
        byte countOfClients = 0;
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
                    handler = sListener.Accept();

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
                        case 2:
                            getName(handler,bytes,bytesRec);
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

        public void stopServer()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        private void getName(Socket handler, byte[] bytes, int countOfBytes)
        {
            byte[] bytesInfo = new byte[255];
            string name = Encoding.UTF8.GetString(bytes, 1, countOfBytes);
            bool newClient = true;
            StringComparer strcmp;
            for (int i = 0; i < names.Count; i++)
            {
                if (name.CompareTo(names[i]) == 0)
                {
                    newClient = false;
                    break;
                }
            }
            if (newClient == true)
            {
                names.Add(name);
                pack.id = countOfClients;
                pack.health = 50;
                pack.character_id = -1;
                playersData.Add(pack);
                countOfClients++;
            }
            sendNames(handler);
        }

        private void sendNames(Socket handler)
        {
            byte[] sendBytes = new byte[1024];
            byte[] bufBytes = new byte[1024];
            sendBytes_length = 0;
            string name;
            for (int i = 0; i < names.Count; i++)
            {
                name = names[i];
                byte[] bytes = Encoding.UTF8.GetBytes(name);

                bufBytes = bytes.Concat(separator).ToArray();
                for (int j = sendBytes_length; j < bufBytes.Length + sendBytes_length; j++)
                {
                    sendBytes[j] = bufBytes[j - sendBytes_length];
                }
                sendBytes_length += bufBytes.Length;
            }
            handler.Send(sendBytes);
        }
        private void getPlayerDataPack(Socket handler, byte[] bytes, int countOfBytes)
        {         
            for (int i = 1; i < countOfBytes; i++)
            {
                bytesInfo[i - 1] = bytes[i];
            }
            playerDataPack.bytesToInfo(bytesInfo);
            int hp;
            int id;
            pack = playerDataPack.Info;
            
            hp = playersData[pack.id].health;
            
            pack.health = hp;
            playersData[pack.id] = pack;
            takingDamage(pack);
        }

        private void takingDamage(PlayerDataPack.Data pack)
        {
            //Console.WriteLine(pack.attackedPlayer_id);
            for (int i = 0; i < playersData.Count; i++)
            {
                //Console.WriteLine("{0} {1} {2}", playersData[i].id, playersData[i].health, pack.damage);
                if (pack.attackedPlayer_id == playersData[i].id)
                {
                    PlayerDataPack.Data buf = playersData[i];
                    
                    buf.health -= pack.damage;
                    
                    playersData[i] = buf;
                    
                }
            }
        }


        private void sendPacks(Socket handler)
        {
            sendBytes_length = 0;
            byte[] sendBytes = new byte[1024];
            byte[] bufBytes = new byte[1024];
            for (int i = 0; i < playersData.Count; i++)
            {
                if (playersData[i].character_id != -1)
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
            }
            handler.Send(sendBytes);
        }


        
        
    }
}
