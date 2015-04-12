﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using SDL2;

namespace Game
{
    class Sonic : Prototype
    {
        public List<SDL.SDL_Rect> standColliders ;
        public List<SDL.SDL_Rect> walkColliders ;
        public List<SDL.SDL_Rect> jumpColliders ;
        public List<SDL.SDL_Rect> attackColliders;
        public List<SDL.SDL_Rect> standTexture;
        public List<SDL.SDL_Rect> walkTexture;
        public List<SDL.SDL_Rect> jumpTexture;
        public List<SDL.SDL_Rect> attackTexture;
        public SDL.SDL_Rect takingDamageTexture;
        public const int attackSpeed = 3000;
        public const int attack_animationSpeed = 60;
        public const int attackTime = 1;
        public float attackTimer = attackTime;
        public float recoveryTimer;
        public int attackDirection;
        public bool isAttacked;
        public override void character_init()
        {
            standColliders = new List<SDL.SDL_Rect>();
            walkColliders = new List<SDL.SDL_Rect>();
            jumpColliders = new List<SDL.SDL_Rect>();
            attackColliders = new List<SDL.SDL_Rect>();

            standTexture = new List<SDL.SDL_Rect>();
            walkTexture = new List<SDL.SDL_Rect>();
            jumpTexture = new List<SDL.SDL_Rect>();
            attackTexture = new List<SDL.SDL_Rect>();

            character_id = 0;
            currentHealth = 100;
            maxHealth = 100;
            damage = 2;
            timeToRecovery = 1f;
            recoveryTimer = timeToRecovery;
            isAttacked = false;

            path_to_spritesheet = "sonic.png";

            animationSpeed.stand = 2;
            animationSpeed.walk = 15;
            animationSpeed.jump = 20;

            velocity_status.walk = 300;
            velocity_status.jump = 1500;



            #region standTexture_init
            standTexture.Add(new SDL.SDL_Rect
            {
                x = 0,
                y = 2,
                w = 31,
                h = 41
            });
            

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 32,
                y = 2,
                w = 32,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 62,
                y = 2,
                w = 32,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 95,
                y = 2,
                w = 32,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 128,
                y = 2,
                w = 32,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 161,
                y = 2,
                w = 32,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 205,
                y = 2,
                w = 34,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 240,
                y = 2,
                w = 34,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 275,
                y = 2,
                w = 35,
                h = 41
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 311,
                y = 2,
                w = 38,
                h = 41
            });
            #endregion

            #region walkTexture_init
            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 420,
                y = 2,
                w = 39,
                h = 41
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 460,
                y = 2,
                w = 39,
                h = 41
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 500,
                y = 2,
                w = 26,
                h = 41
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 527,
                y = 2,
                w = 28,
                h = 41
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 556,
                y = 2,
                w = 37,
                h = 41
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 1,
                y = 51,
                w = 38,
                h = 37
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 40,
                y = 51,
                w = 26,
                h = 37
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 67,
                y = 49,
                w = 26,
                h = 39
            });
            #endregion

            #region jumpTexture_init
            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 518,
                y = 105,
                w = 30,
                h = 30
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 549,
                y = 105,
                w = 30,
                h = 30
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 1,
                y = 147,
                w = 30,
                h = 30
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 33,
                y = 147,
                w = 30,
                h = 30
            });
            
            #endregion

            #region attackTexture_init
            attackTexture.Add(new SDL.SDL_Rect
            {
                x = 281,
                y = 108,
                w = 30,
                h = 27
            });

            attackTexture.Add(new SDL.SDL_Rect
            {
                x = 312,
                y = 108,
                w = 30,
                h = 27
            });

            attackTexture.Add(new SDL.SDL_Rect
            {
                x = 342,
                y = 108,
                w = 30,
                h = 27
            });

            attackTexture.Add(new SDL.SDL_Rect
            {
                x = 372,
                y = 108,
                w = 30,
                h = 27
            });

            attackTexture.Add(new SDL.SDL_Rect
            {
                x = 402,
                y = 108,
                w = 30,
                h = 27
            });

            attackTexture.Add(new SDL.SDL_Rect
            {
                x = 432,
                y = 108,
                w = 30,
                h = 27
            });
            #endregion

            #region takingDamageTexture_init
            takingDamageTexture = new SDL.SDL_Rect
            {
                x = 40,
                y = 236,
                w = 39,
                h = 31
            };
            #endregion

            standColliders.Add(new SDL.SDL_Rect
            {
                w = 31 * zoomOfTexture,
                h = 41 * zoomOfTexture
            });

            walkColliders.Add(new SDL.SDL_Rect
            {
                w = 31 * zoomOfTexture,
                h = 41 * zoomOfTexture
            });

            attackColliders.Add(new SDL.SDL_Rect
            {
                w = 30 * zoomOfTexture,
                h = 27 * zoomOfTexture
            });

            jumpColliders.Add(new SDL.SDL_Rect
            {
                w = 30 * zoomOfTexture,
                h = 30 * zoomOfTexture
            });

            timeratio_for_minijump = 1000;

        }

        public override void prepareAnimation_stand(ref float currentFrame)
        {
            if (currentFrame < 10)
            {
                currentClip = standTexture[0];
            }
            else 
                if (currentFrame < 13)
                {
                    currentClip = standTexture[2 + 12 - (int)currentFrame];
                }
                else
                    {
                        currentClip = standTexture[4 - (int)currentFrame % 2];
                    }
        }


        public override void prepareAnimation_takingDamage(ref float currentFrame)
        {
            currentClip = takingDamageTexture;
        }

        public override void prepareAnimation_walk(ref float currentFrame)
        {
            if ((int)currentFrame >= walkTexture.Count)
            {
                currentFrame = 0;
            }
            currentClip = walkTexture[(int)currentFrame];
        }

        public override void prepareAnimation_jump(ref float currentFrame)
        {
            if ((int)currentFrame >= jumpTexture.Count)
            {
                currentFrame = 0;
            }
            currentClip = jumpTexture[(int)currentFrame];
        }

        public override void prepareAnimation_attack(ref float currentFrame)
        {
            if ((int)currentFrame >= jumpTexture.Count)
            {
                currentFrame = 0;
            }
            currentClip = jumpTexture[(int)currentFrame];
        }

        public override List<SDL.SDL_Rect> getStandColliders()
        {
            return standColliders;
        }

        public override List<SDL.SDL_Rect> getWalkColliders()
        {
            return walkColliders;
        }

        public override List<SDL.SDL_Rect> getJumpColliders()
        {
            return jumpColliders;
        }

        public override List<SDL.SDL_Rect> getAttackColliders()
        {
            return jumpColliders;
        }

        public override void a_press(ref float currentFrame)
        {
            currentColliders = getAttackColliders();
            animationStatus = "attack";
            if (direction == true)
            {
                attackDirection = -1;
            }
            else
            {
                attackDirection = 1;
            }
        }

        private void returnToStand()
        {
            animationStatus = "stand";
            velocityX = hidden_velocityX;
            current_animationSpeed = animationSpeed.stand;
            currentColliders = getStandColliders();
        }
        public override void isAttacking(float timestep)
        {
            attackTimer -= timestep;
            if (attackTimer <= 0)
            {
                attackTimer = attackTime;
                returnToStand();
            }
            else
            {
                velocityX = attackDirection * (int)(attackSpeed * attackTimer / attackTime);
                current_animationSpeed = (int)(attack_animationSpeed *  attackTimer / attackTime);
                
            }
        }

        public override void takingDamage(float timestep, int newHealth)
        {
            if (newHealth < currentHealth)
            {
                if (isAttacked == false)
                {
                    animationStatus = "takingDamage";
                    //prepareAnimation_takingDamage();
                    velocityX *= -1;
                    isAttacked = true;
                    currentHealth = newHealth;
                }
            }
            if (animationStatus == "takingDamage")
            {
                recoveryTimer -= timestep;
                if (recoveryTimer <= 0)
                {
                    recoveryTimer = timeToRecovery;
                    isAttacked = false;
                    returnToStand();
                }
            }
        }
    }
}
