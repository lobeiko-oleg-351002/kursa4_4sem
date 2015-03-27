using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using Game;

namespace Game
{
    abstract class Prototype 
    {

        public struct Box_animationSpeed
        {
            public int stand;
            public int walk;
            public int jump;
        };

        public Box_animationSpeed animationSpeed;

        public struct Box_velocity
        {
            public int walk;
            public int jump;
        };


        public Box_velocity velocity_status;

        public List<SDL.SDL_Rect> standTexture = new List<SDL.SDL_Rect>();
        public List<SDL.SDL_Rect> walkTexture = new List<SDL.SDL_Rect>();
        public List<SDL.SDL_Rect> jumpTexture = new List<SDL.SDL_Rect>();

        public List<SDL.SDL_Rect> currentColliders = new List<SDL.SDL_Rect>();

        public int previousCollider_H;

        public string path_to_spritesheet;

        private Texture playerTexture;
        public float currentFrame;
        int current_animationSpeed;
        public string animationStatus;
        public SDL.SDL_Rect currentClip;
        Picture_for_render picture_info = new Picture_for_render();
        public const int zoomOfTexture = 2;
        public const int gameSpeed = 1000;
        public const int gravity = 3;
        public float pressingJump;
        public int positionX, positionY;
        public int velocityX, velocityY;
        public bool direction, onGround;
        public int timeratio_for_minijump;
        public string id;
        
        IntPtr renderer;

        public void player_init(IntPtr globalRenderer)
        {
            renderer = globalRenderer;
            playerTexture = new Texture();
            positionX = 100;
            positionY = 100;
            velocityX = 0;
            velocityY = 0;
            animationStatus = "stand";
            onGround = false;
            pressingJump = 0;
            current_animationSpeed = animationSpeed.stand;
            currentColliders = getStandColliders();
        }

        public void importData(PlayerDataPack.Data import)
        {
            positionX = import.positionX;
            positionY = import.positionY;
            currentFrame = import.curframe;
            switch (import.animation_status)
            {
                case 0:
                    {
                        prepareAnimation_stand(ref currentFrame);
                        currentColliders = getStandColliders();
                        break;
                    }
                case 1:
                    {
                        prepareAnimation_walk(ref currentFrame);
                        currentColliders = getWalkColliders();
                        break;
                    }
                case 2:
                    {
                        prepareAnimation_jump(ref currentFrame);
                        currentColliders = getJumpColliders();
                        break;
                    }
            }

            direction = import.direction;
            shiftColliders(currentColliders, positionX, positionY);
        }

        public void handleEvent(SDL.SDL_Event e, float timestep)
        {
            if (e.type == SDL.SDL_EventType.SDL_KEYDOWN && e.key.repeat == 0)
            {
                //Adjust the velocity
                switch (e.key.keysym.sym)
                {
                    case SDL.SDL_Keycode.SDLK_d:
                    {
                        velocityX += velocity_status.walk;
                        break;
                    }
                    case SDL.SDL_Keycode.SDLK_a:
                    {
                        velocityX -= velocity_status.walk;
                        break;
                    }
                    case SDL.SDL_Keycode.SDLK_SPACE:
                    {
                        if (onGround == true)
                        {
                            velocityY = -velocity_status.jump;
                            onGround = false;
                            pressingJump += timestep;
                        }
                        
                        break;
                    }
                };
            }
            else if (e.type == SDL.SDL_EventType.SDL_KEYUP && e.key.repeat == 0)
            {
                //Adjust the velocity
                switch( e.key.keysym.sym )
                {
                    case SDL.SDL_Keycode.SDLK_d:
                    {
                        velocityX -= velocity_status.walk;
                        break;
                    }
                    case SDL.SDL_Keycode.SDLK_a:
                    {
                        velocityX += velocity_status.walk;
                        break;
                    }
                    case SDL.SDL_Keycode.SDLK_SPACE:
                    {
                        if (velocityY < 0)
                        {
                            if (pressingJump <= timeratio_for_minijump * timestep)
                            {
                                velocityY = 0;
                                pressingJump = 0;
                            }
                        }
                        break;
                    }
                }
            }
            
        }

        abstract public void prepareAnimation_stand(ref float currentFrame);
        abstract public void prepareAnimation_walk(ref float currentFrame);
        abstract public void prepareAnimation_jump(ref float currentFrame);
        abstract public List<SDL.SDL_Rect> getStandColliders();
        abstract public List<SDL.SDL_Rect> getWalkColliders();
        abstract public List<SDL.SDL_Rect> getJumpColliders();

        private void move_positionX(float timestep, string[] Map, List<SDL.SDL_Rect> WallColliders)
        {
            int shiftX = (int)Math.Ceiling(velocityX * timestep / gameSpeed);
            int startPositionX = positionX;
            int shiftX_in_time;

            for (shiftX_in_time = 1; shiftX_in_time <= Math.Abs(shiftX); shiftX_in_time++)
            {
                positionX = startPositionX;
                if (velocityX > 0)
                {
                    positionX += shiftX_in_time;
                }
                else
                {
                    positionX -= shiftX_in_time;
                }

                currentColliders = shiftColliders(currentColliders, positionX, positionY);

                if (true == CollisionWithWalls(Map, WallColliders))
                {
                    if (velocityX >= 0)
                    {
                        positionX -= shiftX_in_time;
                    }
                    else
                    {
                        positionX += shiftX_in_time;
                    }

                    break;
                }
            }
        }

        private void move_positionY(float timestep, string[] Map, List<SDL.SDL_Rect> WallColliders)
        {
            onGround = false;
            velocityY += (int)(gravity * timestep);
            int shiftY = (int)Math.Ceiling(velocityY * timestep / gameSpeed);
            int startPositionY = positionY;
            int shiftY_in_time;
            for (shiftY_in_time = 1; shiftY_in_time <= Math.Abs(shiftY); shiftY_in_time++)
            {
                positionY = startPositionY;
                if (velocityY >= 0)
                {
                    positionY += shiftY_in_time;
                }
                else
                {
                    positionY -= shiftY_in_time;
                }

                currentColliders = shiftColliders(currentColliders, positionX, positionY);

                if (true == CollisionWithWalls(Map, WallColliders))
                {

                    if (velocityY >= 0)
                    {
                        positionY -= 1;
                        onGround = true;
                        velocityY = 0;
                    }
                    else
                    {
                        if (animationStatus == "jump")
                        {
                            velocityY = 0;
                        }
                        positionY += 1;
                    }
                    break;
                }
            }
        }

        public void move(float timestep, string[] Map, List<SDL.SDL_Rect> WallColliders, ref int offsetX, ref int offsetY)
        {
            if ((0 == velocityX) && (true == onGround))
            {
                if (animationStatus != "stand")
                {
                    animationStatus = "stand";
                    current_animationSpeed = animationSpeed.stand;
                    currentFrame = 0;
                    previousCollider_H = currentColliders[0].h;
                    currentColliders = getStandColliders();
                }
            }


            if  (0 != velocityX)
            {
                if (animationStatus != "walk" && onGround == true )
                {
                    animationStatus = "walk";
                    current_animationSpeed = animationSpeed.walk;
                    previousCollider_H = currentColliders[0].h;
                    currentColliders = getWalkColliders();
                    currentFrame = 0;
                }

                if (velocityX > 0)
                {
                    direction = false;
                }
                else
                {
                    direction = true;
                }
                move_positionX(timestep, Map, WallColliders);
            }

            move_positionY(timestep, Map, WallColliders);  
            if (false == onGround)
            {
                if (animationStatus != "jump")
                {
                    animationStatus = "jump";
                    previousCollider_H = currentColliders[0].h;
                    currentColliders = getJumpColliders();
                    current_animationSpeed = animationSpeed.jump;
                    currentFrame = 0;
                }
            }
            

            if ("walk" == animationStatus)
            {              
                prepareAnimation_walk(ref currentFrame);
            }
            if ("jump" == animationStatus)
            {
                prepareAnimation_jump(ref currentFrame);              
            }
            if ("stand" == animationStatus)
            {
                prepareAnimation_stand(ref currentFrame);
            }

            currentFrame = currentFrame + current_animationSpeed * timestep / (float)gameSpeed;
            if (currentColliders[0].h > previousCollider_H)
            {
                positionY = positionY - (currentColliders[0].h - previousCollider_H);
            }
            currentColliders = shiftColliders(currentColliders,positionX,positionY);
            previousCollider_H = currentColliders[0].h; 

            if ((positionX > 500) && (positionX < 1000)) offsetX = positionX - 500; 
        }

        private void close()
        {
            playerTexture.free();
        }

        public void loading()
        {
            playerTexture.loadFromFile(renderer,path_to_spritesheet);
        }

        public void render(int offsetX, int offsetY, float timestep)
        {

            if (true == direction)
            {
                picture_info.flip = SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;
            }
            else
            {
                picture_info.flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE;
            }

            picture_info.sourcePicture = currentClip;

            picture_info.angle = 0;
            picture_info.height = currentClip.h*zoomOfTexture;
            picture_info.width = currentClip.w*zoomOfTexture;
            picture_info.offsetX = offsetX;
            picture_info.offsetY = offsetY;
            if (false == direction)
            {
                picture_info.x = positionX;
            }
            else
            {
                picture_info.x = currentColliders[0].x + currentColliders[0].w - picture_info.width;
            }
            picture_info.y = currentColliders[0].y + currentColliders[0].h - picture_info.height;
            

            playerTexture.renderTexture(renderer, picture_info);

        }

        private List<SDL.SDL_Rect> shiftColliders(List<SDL.SDL_Rect> colliders, int positionX, int positionY)
        {
            //The row offset
            int r = 0;
            var bufSet = colliders[0];
            //Go through the dot's collision boxes
            for( int set = 0; set < colliders.Count; set++ )
            {
                bufSet.x = positionX;
                bufSet.y = positionY + r;
                colliders[set] = bufSet ;

                //Move the row offset down the height of the collision box
                r += colliders[set].h;
            }
            return colliders;
        }

        public bool CollisionWithWalls(string[] Map, List<SDL.SDL_Rect> Colliders)
        {
            int bordX,bordY;
            var bufSet = Colliders[0];
            bordX = (int)Math.Ceiling((currentColliders[0].x + currentColliders[0].w) / (float)Colliders[0].w);
            bordY = (int)Math.Ceiling((currentColliders[0].y + currentColliders[0].h) / (float)Colliders[0].h);
            for (int i = currentColliders[0].y / Colliders[0].h; i < bordY; i++)
                for (int j = currentColliders[0].x / Colliders[0].w; j < bordX; j++)
                {
                    if (Map[i][j] == 'W')
                    {
                        bufSet.x = j * bufSet.w;
                        bufSet.y = i * bufSet.h;
                        Colliders[0] = bufSet;
                        return (checkCollision(currentColliders,Colliders));
                    }
                }
                return false;
        }

        private bool checkCollision(List<SDL.SDL_Rect> a, List<SDL.SDL_Rect> b )
        {
            //The sides of the rectangles
            int leftA, leftB;
            int rightA, rightB;
            int topA, topB;
            int bottomA, bottomB;

            int h = 0;

            //Go through the A boxes
            for( int Abox = 0; Abox < a.Count(); Abox++ )
            {
                //Calculate the sides of rect A
                leftA = a[ Abox ].x;
                rightA = a[ Abox ].x + a[ Abox ].w;
                topA = a[ Abox ].y;
                bottomA = a[ Abox ].y + a[ Abox ].h;

                //Go through the B boxes
                for( int Bbox = 0; Bbox < b.Count; Bbox++ )
                {
                    //Calculate the sides of rect B
                    leftB = b[ Bbox ].x;
                    rightB = b[ Bbox ].x + b[ Bbox ].w;
                    topB = b[ Bbox ].y;
                    bottomB = b[ Bbox ].y + b[ Bbox ].h;

                    //If no sides from A are outside of B

                    if( ( ( bottomA <= topB ) || ( topA >= bottomB ) || ( rightA <= leftB ) || ( leftA >= rightB ) ) == false )
                    {
                        //A collision is detected
                        h += b[Bbox].h;
                        //return b[Bbox].h;
                    }
                }
            }

            return true;  //return h
        }
    }
}
