using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Game
{
    class Program
    {
        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 600;
        const int map_Height = 12;
        const int map_Width = 26;
        public static int offsetX, offsetY;
        public static IntPtr globalWindow;
        public static IntPtr globalRenderer;
        public static float timestep;
        static string[] Map = new string[map_Height]
        {
            "  WWWWWWWWWWWWWW          ",
            "          W               ",
            "          W               ",
            "          W               ",
            "          W               ",
            "          W               ",
            "    WWWWWWW               ",
            "                          ",
            "                          ",
            "                          ",
            "WWWWWWWW                  ",
            "WWWWWWWWWWWWWWWWWWWWWWWWWW",
        };

        public static bool init()
        {
            //Initialization flag
            bool success = true;

            //Initialize SDL
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine("SDL could not initialize! SDL Error: %s\n", SDL.SDL_GetError());
                success = false;
            }
            else
            {
                //Set texture filtering to linear
                if (SDL.SDL_SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "1") == SDL.SDL_bool.SDL_FALSE)
                {
                    Console.WriteLine("Warning: Linear texture filtering not enabled!");
                }

                //Create window
                globalWindow = SDL.SDL_CreateWindow("Game", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
                if (globalWindow == null)
                {
                    Console.WriteLine("Window could not be created! SDL Error: %s\n", SDL.SDL_GetError());
                    success = false;
                }
                else
                {
                    //Create vsynced renderer for window

                    globalRenderer = SDL.SDL_CreateRenderer(globalWindow, -1, (uint)(SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC)); //missed Rendererflags
                    if (globalRenderer == null)
                    {
                        Console.WriteLine("Renderer could not be created! SDL Error: %s\n", SDL.SDL_GetError());
                        success = false;
                    }
                    else
                    {
                        //Initialize renderer color
                        SDL.SDL_SetRenderDrawColor(globalRenderer, 0xFF, 0xFF, 0xFF, 0xFF);

                        //Initialize PNG loading
                        SDL_image.IMG_InitFlags imgFlags = SDL_image.IMG_InitFlags.IMG_INIT_PNG;
                        //if ((SDL_image.IMG_Init(imgFlags) == 0) & (imgFlags) )
                        //{
                        //    Console.WriteLine("SDL_image could not initialize! SDL_image Error: %s\n");
                        //    success = false;
                        //}
                    }
                }
            }

            return success;
        }

        public static void close()
        {
            //Free loaded images
            //Destroy window
            SDL.SDL_DestroyRenderer(globalRenderer);
            SDL.SDL_DestroyWindow(globalWindow);
            globalWindow = IntPtr.Zero;
            globalRenderer = IntPtr.Zero;

            //Quit SDL subsystems
            SDL_image.IMG_Quit();
            SDL.SDL_Quit();
        }

        public static IntPtr loadTexture(string path)
        {
	        //The final texture
	        IntPtr newTexture = IntPtr.Zero;

	        //Load image at specified path

            IntPtr loadedSurface = SDL_image.IMG_Load(path);
	        if( loadedSurface == IntPtr.Zero )
	        {
		        Console.WriteLine( "Unable to load image %s! SDL_image Error: %s\n", path );
	        }
	        else
	        {
		        //Create texture from surface pixels
                newTexture = SDL.SDL_CreateTextureFromSurface( globalRenderer, loadedSurface );
		        if( newTexture == IntPtr.Zero )
		        {
			       Console.WriteLine( "Unable to create texture from %s! SDL Error: %s\n", path, SDL.SDL_GetError());
		        }

		        //Get rid of old loaded surface
		        SDL.SDL_FreeSurface( loadedSurface );
	        }

	        return newTexture;
        }

        static void Main(string[] args)
        {
            if (!init())
            {
                Console.WriteLine("Failed to initialize!\n");
            }
            else
            {
                bool quit = false;
                SDL.SDL_Event e;

                Wall wall = new Wall();
                wall.loading(globalRenderer);


                string input;
                
                
                
                
                //choose Sonic
                Sonic player = new Sonic();
                //.......

                Sonic enemy = new Sonic();
                enemy.character_init();
                enemy.player_init(globalRenderer);
                enemy.loading();

                player.character_init();
                player.player_init(globalRenderer);
                player.loading();

                List<PlayerDataPack.Data> import = new List<PlayerDataPack.Data>();

                PlayerDataPack curPack= new PlayerDataPack();

                input = Console.ReadLine();
                if (input == "host")
                {
                    Server host = new Server();
                    host.startServer();
                    
                }
                player.id = input;

                Client client = new Client();

                Timer stepTimer = new Timer();

                while (!quit)
                {
                    while(SDL.SDL_PollEvent(out e) != 0 )
                    {
                        if (e.type ==  SDL.SDL_EventType.SDL_QUIT)
                        {
                            quit = true;
                        }
                        player.handleEvent(e,timestep);
                    }

                    timestep = stepTimer.getTicks();

                    player.move(timestep, Map, wall.Colliders, ref offsetX, ref offsetY );

                    stepTimer.start();

                    SDL.SDL_RenderClear(globalRenderer);


                    for (int i = 0; i < map_Height; i++)
                    {
                        for (int j = 0; j < map_Width; j++)
                        {
                            if (Map[i][j] == 'W') wall.renderSurface(globalRenderer, j, i, offsetX, offsetY);
                        }
                    }

                    curPack.init(player);
                    //import = client.exchangeData(curPack);
                    client.sendDataPack(curPack);
                    import = client.getOtherPlayerPacks();
                   // Console.WriteLine(import.Count);
                    for (int i = 0; i < import.Count; i++)
                    {
                        enemy.importData(import[i]);
                        //Console.WriteLine(i);
                        //Console.WriteLine(import[i].id);
                        //if (import[0].id == import[1].id) Console.WriteLine("asdf");
                        enemy.render(offsetX, offsetY, timestep);
                    }                                        

                    //player.render(offsetX,offsetY, timestep);
                    SDL.SDL_RenderPresent(globalRenderer);
                }
            }

            close();
        }
    }
}
