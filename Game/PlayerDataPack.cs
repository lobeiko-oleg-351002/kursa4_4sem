using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SDL2;

namespace Game
{
    class PlayerDataPack
    {
        public struct Data
        {
            public int character_id;
            public int id;
            public int positionX;
            public int positionY;
            public int animation_status;
            public bool direction;
            public int curframe;
            public int attackedPlayer_id;
            public int damage;
            public int health;
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
            if (player.animationStatus == "attack")
            {
                Info.animation_status = 3;
            }
            if (player.animationStatus == "takingDamage")
            {
                Info.animation_status = 4;
            }
            if (player.animationStatus == "death")
            {
                Info.animation_status = 5;
            }
            if (player.animationStatus == "dead")
            {
                Info.animation_status = 6;
            }
            Info.curframe = (int)player.currentFrame;
            Info.direction = player.direction;
            Info.positionX = player.positionX;
            Info.positionY = player.positionY;
            Info.character_id = player.character_id;
            Info.id = player.id;
            Info.damage = player.damage;
            Info.attackedPlayer_id = player.attackedPlayer_id;
            //Console.WriteLine(player.attackedPlayer_id);
           // Info.health = player.currentHealth;
            //Console.WriteLine(player.currentHealth);


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
            int size = Marshal.SizeOf(typeof(Data));
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);
            Info = (Data)Marshal.PtrToStructure(ptr, Info.GetType());
            Marshal.FreeHGlobal(ptr);
        }
        
    }
}
