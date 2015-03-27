using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2; 
using Game;


namespace Game
{
    class Wall
    {
        SDL.SDL_Rect currentWall;
        
  
        //private int posX, posY;
        public int width = 50;

        public List<SDL.SDL_Rect> Colliders = new List<SDL.SDL_Rect>();

        private Texture wallTexture = new Texture();
        

        public void close()    
        {
            wallTexture.free();
        }

        public void loading(IntPtr globalRenderer)
        {
            currentWall.x = 0; 
            currentWall.y = 0;
            currentWall.w = width;
            currentWall.h = width;
            Colliders.Add(new SDL.SDL_Rect
            {
                w = width,
                h = width
            });
            wallTexture.loadFromFile(globalRenderer,"walls.png");
        }
        
   

        public void renderSurface(IntPtr globalRenderer, int block_posX, int block_posY, int offsetX, int offsetY)
        {
            Picture_for_render surface = new Picture_for_render();
            surface.x = block_posX * currentWall.w;
            surface.y = block_posY * currentWall.h;
            surface.width = currentWall.w;
            surface.height = currentWall.h;
            surface.offsetX = offsetX;
            surface.offsetY = offsetY;
            surface.sourcePicture = currentWall;
            
            wallTexture.renderTexture(globalRenderer,surface);
        }
    }
}
