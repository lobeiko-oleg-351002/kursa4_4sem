using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Game
{
    class Timer
    {
        private bool started, paused;
        private uint startTicks, pausedTicks;

        public Timer()
        {
            startTicks = 0;
            pausedTicks = 0;
            paused = false;
            started = false;
        }

        public void start()
        {
            //Start the timer
            started = true;

            //Unpause the timer
            paused = false;

            //Get the current clock time
            startTicks = SDL.SDL_GetTicks();
	        pausedTicks = 0;
        }

        public uint getTicks()
        {
	        //The actual timer time
	        uint time = 0;

            //If the timer is running
            if( started )
            {
                //If the timer is paused
                if( paused )
                {
                    //Return the number of ticks when the timer was paused
                    time = pausedTicks;
                }
                else
                {
                    //Return the current time minus the start time
                    time = SDL.SDL_GetTicks() - startTicks;
                }
            }

            return time;
        }
    }
}
