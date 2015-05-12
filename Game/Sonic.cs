using System;
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
        public List<SDL.SDL_Rect> deathColliders;
        public List<SDL.SDL_Rect> standTexture;
        public List<SDL.SDL_Rect> walkTexture;
        public List<SDL.SDL_Rect> jumpTexture;
        public List<SDL.SDL_Rect> attackTexture;
        public SDL.SDL_Rect deathTexture;
        public SDL.SDL_Rect takingDamageTexture;
        public const int attackSpeed = 3000;
        public const int attack_animationSpeed = 60;
        public const float attackTime = 0.5f;
        public const int Sonic_damage = 2;
        public const int Sonic_deathTime = 2;
        public const int Sonic_recovery = 1;
        public float attackTimer = attackTime;
        public float recoveryTimer, animationDeath_timer;
        public int attackDirection;
        public bool isAttacked;
        public override void character_init()
        {
            standColliders = new List<SDL.SDL_Rect>();
            walkColliders = new List<SDL.SDL_Rect>();
            jumpColliders = new List<SDL.SDL_Rect>();
            attackColliders = new List<SDL.SDL_Rect>();
            deathColliders = new List<SDL.SDL_Rect>();

            standTexture = new List<SDL.SDL_Rect>();
            walkTexture = new List<SDL.SDL_Rect>();
            jumpTexture = new List<SDL.SDL_Rect>();
            attackTexture = new List<SDL.SDL_Rect>();
            attackRange = 0;
            character_id = 0;
            maxHealth = 50;
            currentHealth = maxHealth;
            //damage = 2;
            timeToRecovery = Sonic_recovery;
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

            #region deathTexture_init
            deathTexture = new SDL.SDL_Rect
            {
                x = 184,
                y = 138,
                w = 33,
                h = 40
            };
            #endregion

            standColliders.Add(new SDL.SDL_Rect
            {
                w = 30 * zoomOfTexture,
                h = 41 * zoomOfTexture
            });

            walkColliders.Add(new SDL.SDL_Rect
            {
                w = 30 * zoomOfTexture,
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

            deathColliders.Add(new SDL.SDL_Rect
            {
                w = 0,
                h = 0
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
        public override void prepareAnimation_death(ref float currentFrame)
        {
            currentClip = deathTexture;
        }
        public override void prepareAnimation_dead(ref float currentFrame)
        {
            currentClip = deathTexture;
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

        public override List<SDL.SDL_Rect> getDeathColliders()
        {
            return deathColliders;
        }
        public override List<SDL.SDL_Rect> getDeadColliders()
        {
            return deathColliders;
        }

        public override void a_press(ref float currentFrame)
        {
            currentColliders = getAttackColliders();
            animationStatus = "attack";
            damage += Sonic_damage;
            if (direction == true)
            {
                attackDirection = -1;
            }
            else
            {
                attackDirection = 1;
            }
        }
        
        public override void a_release(ref float currentFrame)
        {
            damage -= Sonic_damage;
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
            //Console.WriteLine("{0} {1}", currentHealth, animationStatus);
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
                    recoveryTimer = Sonic_recovery;
                    isAttacked = false;
                    returnToStand();
                }
            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                deathEvent(timestep);
            }
        }

        public override void deathEvent(float timestep)
        {
            if (isDead == false)
            {
                currentColliders = deathColliders;
                animationStatus = "death";
                isDead = true;
                animationDeath_timer = Sonic_deathTime;
                velocityX = 0;
                velocityY = -velocity_status.jump;
            }
            if (animationStatus == "death")
            {
                recoveryTimer -= timestep;
                if (recoveryTimer <= 0)
                {
                    animationDeath_timer -= timestep;
                    if (animationDeath_timer < 1.3f)
                    {
                        velocityY *= -1;
                    }
                    if (animationDeath_timer <= 0)
                    {
                        animationStatus = "dead";
                        velocityX = 0;
                        velocityY = 0;
                    }
                }
            }
        }

    }
}
