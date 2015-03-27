using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;


namespace Game
{
    class Picture_for_render
    {
        public int x, y, width, height, offsetX, offsetY;
        public SDL.SDL_Rect  clip;
        public SDL.SDL_Point center;
        public SDL.SDL_Rect sourcePicture;
        public double angle;
        public SDL.SDL_RendererFlip flip;
    }
}
