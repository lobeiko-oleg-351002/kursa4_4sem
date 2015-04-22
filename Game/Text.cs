using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Game
{
    class Text
    {
        Texture text = new Texture();
        Picture_for_render picture = new Picture_for_render();
        public void viewHealth(IntPtr renderer, int currentHealth, int maxHealth)
        {
            if (SDL_ttf.TTF_Init() < 0)
            {
                Console.WriteLine("Error with ttf");
            }
            else
            {
                //SDL.SDL_RenderClear(renderer);
               // Console.WriteLine("{0}/{1}",currentHealth, maxHealth);
                IntPtr font = SDL_ttf.TTF_OpenFont("arial.ttf", 24);
                string error = SDL.SDL_GetError();
                SDL.SDL_Color color = new SDL.SDL_Color();
                color.r = 0;
                color.g = 0;
                color.b = 255;
                string HP = Convert.ToString(currentHealth) + "/" + Convert.ToString(maxHealth);
                IntPtr surface = SDL_ttf.TTF_RenderText_Solid(font, HP, color);
                text.currentTexture = SDL.SDL_CreateTextureFromSurface(renderer, surface);

                int textWidth = 10;
                int textHeight = 10;
                uint format = 0;
                int access = 0;
                SDL.SDL_QueryTexture(text.currentTexture, out format, out access, out textWidth, out textHeight);
                picture.x = 10;
                picture.y = 10;
                picture.width = 100;
                picture.height = 100;
                picture.sourcePicture.x = 0;
                picture.sourcePicture.y = 0;
                picture.sourcePicture.w = 100;
                picture.sourcePicture.h = 100;
                text.renderTexture(renderer, picture);


                SDL.SDL_DestroyTexture(text.currentTexture);
                SDL.SDL_FreeSurface(surface);
                SDL_ttf.TTF_CloseFont(font);
            }
        }
    }
}
