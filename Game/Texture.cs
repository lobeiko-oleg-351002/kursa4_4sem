using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using Game;
using System.Runtime.InteropServices;

namespace Game
{
    class Texture
    {
        public IntPtr currentTexture;

        public void free()
        {
            if (currentTexture != IntPtr.Zero)
            {
                SDL.SDL_DestroyTexture(currentTexture);
                currentTexture = IntPtr.Zero;
            }
        }

        public void loadFromFile(IntPtr globalRenderer, string path )
        {
	        //Get rid of preexisting texture
	        free();

	        //The final texture
	        IntPtr newTexture = IntPtr.Zero;
            
	        //Load image at specified path
	        IntPtr loadedSurface = SDL_image.IMG_Load(path);
            SDL.SDL_PixelFormat pixelformat = new SDL.SDL_PixelFormat() ;//damn it
            pixelformat.palette = loadedSurface;//too
            pixelformat.format = SDL.SDL_PIXELFORMAT_UNKNOWN;//too
            IntPtr pointer_pixelformat = Marshal.AllocHGlobal(Marshal.SizeOf(pixelformat.format));//too
	        if (loadedSurface == IntPtr.Zero)
	        {
		        Console.WriteLine( "Unable to load image {0}! SDL_image Error: \n", path);
	        }
	        else
            {
		        //Color key image
                //IntPtr optimizedImage = SDL(loadedSurface);
                //SDL.SDL_SetColorKey(loadedSurface, 1, SDL.SDL_MapRGB(loadedSurface, 0, 0xFF, 0xFF));//SDL.SDL_bool.SDL_TRUE against 1
                //SDL.SDL_MapRGB(loadedSurface, 0, 0xFF, 0xFF);
		        //Create texture from surface pixels
                newTexture = SDL.SDL_CreateTextureFromSurface( globalRenderer, loadedSurface );

		        if( newTexture == IntPtr.Zero )
		        {
			        Console.WriteLine( "Unable to create texture from %s! SDL Error: %s\n", path, SDL.SDL_GetError() );
		        }
		        //Get rid of old loaded surface
		        SDL.SDL_FreeSurface( loadedSurface );
	        }

	        //Return success
	        currentTexture = newTexture;
            newTexture = IntPtr.Zero;
        }

        public void renderTexture(IntPtr globalRenderer, Picture_for_render picture )
        {
	        //Set rendering space and render to screen

	        SDL.SDL_Rect renderQuad = new SDL.SDL_Rect();
            
            renderQuad.x = picture.x - picture.offsetX;
            renderQuad.y = picture.y - picture.offsetY;
            renderQuad.w = picture.width;
            renderQuad.h = picture.height;
            
	        //Render to screen
	        SDL.SDL_RenderCopyEx(globalRenderer, currentTexture, ref picture.sourcePicture, ref renderQuad, picture.angle, ref picture.center, picture.flip ); //pict - рендерируемая картинка
        }

    }
}
