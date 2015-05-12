using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDL2;
using System.Threading;

namespace Game
{
    public partial class Menu : Form
    {
        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 600;
        const int map_Height = 12;
        const int map_Width = 26;
        public static int offsetX, offsetY;
        public static IntPtr globalWindow;
        public static IntPtr globalRenderer;
        public static float timestep;
        Client client;
        byte character_id;
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
            "WWWWWWWW             W    ",
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

        Server host;
        private void createServer()
        {
            host = new Server();
            host.startServer();
        }

        private void stopServer()
        {
            host.stopServer();
        }

        public bool isHost = false;
        public bool isJoin = false;
        Thread serverThread;
        public string name;
        public List<string> nameList = new List<string>();
        public string IPhost;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = true;
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            isHost = true;
            IPhost = "127.0.0.1";
            serverThread = new Thread(createServer);
            serverThread.Start();
            client = new Client(IPhost);
            refreshNameList(client);
            timer_sendNames.Start();
        }

        private void button_Back2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox5.Visible = true;
        }

        private void button_Join_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox4.Visible = true;
        }

        private void button_Back4_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox2.Visible = true;
        }

        private void button_Back3_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;
            isHost = false;
            //serverThread.Abort();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox3.Visible = true;
            IPhost = textBox_IP.Text;
            client = new Client(IPhost);
            refreshNameList(client);
            timer_sendNames.Start();
        }

        private void button_Back5_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox1.Visible = true;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox2.Visible = true;
            name = textBox_Name.Text;
        }

        private void refreshNameList(Client client)
        {
            nameList = client.namesExchange(name);
            listBox1.Items.Clear();
            for (int i = 0; i < nameList.Count; i++)
            {
                listBox1.Items.Add(nameList[i]);
            }
        
        }

        private int getID()
        {
            for(int i = 0; i < nameList.Count; i++)
            {
                if (nameList[i] == name)
                {
                    return i;
                }
            }
            return -1;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if (!init())
            {
                Console.WriteLine("Failed to initialize!\n");
            }
            else
            {
                bool quit = false;
                SDL.SDL_Event ev;

                Wall wall = new Wall();
                wall.loading(globalRenderer);

                Prototype player;
                switch(character_id)
                {
                    case 0:
                        player = new Sonic();
                        break;
                    case 1:
                        player = new Sketch();
                        break;
                    default:
                        player = new Sonic();
                        break;
                }


                player.character_init();
                player.player_init(globalRenderer);
                player.loading();

                List<PlayerDataPack.Data> import = new List<PlayerDataPack.Data>();
                List<Prototype> players = new List<Prototype>();

                player.id =  getID();

                PlayerDataPack curPack= new PlayerDataPack();

                //player.id = character_id;

                

                Timer stepTimer = new Timer();

                while (!quit)
                {
                    while(SDL.SDL_PollEvent(out ev) != 0 )
                    {
                        if (ev.type ==  SDL.SDL_EventType.SDL_QUIT)
                        {
                            quit = true;
                        }
                        if (player.animationStatus != "dead")
                        {
                            player.handleEvent(ev, timestep);
                        }
                    }



                    SDL.SDL_RenderClear(globalRenderer);


                    for (int i = 0; i < map_Height; i++)
                    {
                        for (int j = 0; j < map_Width; j++)
                        {
                            if (Map[i][j] == 'W')
                            {
                                wall.renderSurface(globalRenderer, j, i, offsetX, offsetY);
                            }
                        }
                    }
                   // if ((player.animationStatus != "death") && (player.animationStatus != "dead"))
                    //{
                    if (player.animationStatus != "dead")
                    {
                        player.move(timestep, Map, wall.Colliders, players, ref offsetX, ref offsetY);
                    }
                    //}

                    curPack.init(player);
                    client.sendDataPack(curPack);
                    import = client.getOtherPlayerPacks();
                    if (import.Count > players.Count)
                    {
                        for (int i = players.Count; i < import.Count; i++)
                        {
                            switch (import[i].character_id)
                            {
                                case 0:
                                    players.Add(new Sonic());
                                    break;
                                case 1:
                                    players.Add(new Sketch());
                                    break;
                                default:
                                    players.Add(new Sonic());
                                    break;
                            }
                            players[i].character_init();
                            players[i].player_init(globalRenderer);
                            players[i].loading();                     
                       
                        }
                    }
                    for (int i = 0; i < import.Count; i++)
                    {
                        players[i].importData(import[i]);
                        if (players[i].id == player.id)
                        {
                            player.takingDamage(timestep/1000, players[i].currentHealth);
                            //players[i].text.viewHealth(globalRenderer, players[i].currentHealth, players[i].maxHealth);
                        }
                        //Console.WriteLine(player.animationStatus);
                        player.text.viewHealth(globalRenderer, player.currentHealth, player.maxHealth);
                        players[i].render(offsetX, offsetY, timestep);
                    }
                    
                    timestep = stepTimer.getTicks();
                    //player.render(offsetX, offsetY, timestep);


                    stepTimer.start();

                    SDL.SDL_RenderPresent(globalRenderer);
                }
            }

            close();
        
        }

        private void button_Sonic_Click(object sender, EventArgs e)
        {
            character_id = 0;
        }

        private void button_Sketch_Click(object sender, EventArgs e)
        {
            character_id = 1;
        }

        private void timer_sendNames_Tick(object sender, EventArgs e)
        {
            refreshNameList(client);
        }
    }
}
