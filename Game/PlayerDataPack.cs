using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Game
{
    class PlayerDataPack
    {
        public struct Data
        {
            public byte id;
            public int positionX;
            public int positionY;
            public int animation_status;
            public bool direction;
            public int curframe;
        };

        public Data Info = new Data();

        public void init(Prototype player)
        {
            if (player.animationStatus == "stand")
            {
                Info.animation_status = 0;
            }
            if (player.animationStatus == "walk")
            {
                Info.animation_status = 1;
            }
            if (player.animationStatus == "jump")
            {
                Info.animation_status = 2;
            }
            Info.curframe = (int)player.currentFrame;
            Info.direction = player.direction;
            Info.positionX = player.positionX;
            Info.positionY = player.positionY;
            Info.id = (byte)player.id[0];

        }

        public byte[] InfoToBytes()
        {
            int size = Marshal.SizeOf(Info);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(Info, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        public void bytesToInfo(byte[] bytes)
        {
           // PlayerDataPack info = new PlayerDataPack();
            int size = Marshal.SizeOf(typeof(Data));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);
            Info = (Data)Marshal.PtrToStructure(ptr, Info.GetType());
            Marshal.FreeHGlobal(ptr);
        }

        public List<PlayerDataPack.Data> bytesToListOfStruct(byte[] bytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            List<PlayerDataPack.Data> list = new List<PlayerDataPack.Data>();
            using (Stream ms = new MemoryStream(bytes))
            {
                list = (List<PlayerDataPack.Data>)bf.Deserialize(ms);

            }
            return list;

        }
        
    }
}
