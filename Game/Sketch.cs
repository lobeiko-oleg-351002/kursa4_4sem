using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Game
{
    class Sketch : Prototype
    {
        public List<SDL.SDL_Rect> standColliders;
        public List<SDL.SDL_Rect> walkColliders;
        public List<SDL.SDL_Rect> jumpColliders;
        public List<SDL.SDL_Rect> attackColliders;
        public List<SDL.SDL_Rect> deathColliders;
        public List<SDL.SDL_Rect> standTexture;
        public List<SDL.SDL_Rect> walkTexture;
        public List<SDL.SDL_Rect> jumpTexture;
        public List<SDL.SDL_Rect> jump_in_action_Texture;
        public List<SDL.SDL_Rect> riseTexture;
        public List<SDL.SDL_Rect> attackTexture_hands;
        public List<SDL.SDL_Rect> deathTexture;
        public SDL.SDL_Rect takingDamageTexture;
        public const int attackSpeed = 3000;
        public const float attackTime = 10f;
        public const int Sketch_damage = 5;
        public const int Sketch_deathTime = 1;
        public const int Sketch_recovery = 1;
        public float attackTimer = attackTime;
        public float recoveryTimer, animationDeath_timer;
        public int attackDirection;
        public bool isAttacked, jumping, walking, attacking;

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
            attackTexture_hands = new List<SDL.SDL_Rect>();
            riseTexture = new List<SDL.SDL_Rect>();
            jump_in_action_Texture = new List<SDL.SDL_Rect>();
            deathTexture = new List<SDL.SDL_Rect>();
            attackRange = 50;
            character_id = 1;
            maxHealth = 50;
            currentHealth = maxHealth;
            //damage = 2;
            timeToRecovery = Sketch_recovery;
            recoveryTimer = timeToRecovery;
            isAttacked = false;

            path_to_spritesheet = "sketch.png";

            animationSpeed.stand = 8;
            animationSpeed.walk = 15;
            animationSpeed.jump = 15;
            animationSpeed.attack = 13;

            velocity_status.walk = 300;
            velocity_status.jump = 900;



            #region standTexture_init
            standTexture.Add(new SDL.SDL_Rect
            {
                x = 295,
                y = 19,
                w = 53,
                h = 68
            });


            standTexture.Add(new SDL.SDL_Rect
            {
                x = 363,
                y = 16,
                w = 51,
                h = 71
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 423,
                y = 15,
                w = 52,
                h = 72
            });

            standTexture.Add(new SDL.SDL_Rect
            {
                x = 491,
                y = 16,
                w = 51,
                h = 71
            });
            #endregion

            #region riseTexture_init
            riseTexture.Add(new SDL.SDL_Rect
            {
                x = 605,
                y = 1114,
                w = 53,
                h = 40
            });


            riseTexture.Add(new SDL.SDL_Rect
            {
                x = 672,
                y = 1109,
                w = 51,
                h = 45
            });

            riseTexture.Add(new SDL.SDL_Rect
            {
                x = 731,
                y = 1099,
                w = 51,
                h = 55
            });
            #endregion

            #region walkTexture_init
            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 237,
                y = 110,
                w = 52,
                h = 70
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 299,
                y = 110,
                w = 49,
                h = 70
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 367,
                y = 107,
                w = 52,
                h = 73
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 436,
                y = 105,
                w = 53,
                h = 75
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 508,
                y = 107,
                w = 58,
                h = 73
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 587,
                y = 111,
                w = 54,
                h = 69
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 658,
                y = 108,
                w = 53,
                h = 72
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 727,
                y = 109,
                w = 49,
                h = 71
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 795,
                y = 104,
                w = 63,
                h = 76
            });

            walkTexture.Add(new SDL.SDL_Rect
            {
                x = 877,
                y = 107,
                w = 65,
                h = 73
            });
            #endregion

            #region jumpTexture_init
            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 23,
                y = 1105,
                w = 51,
                h = 62
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 91,
                y = 1057,
                w = 61,
                h = 101
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 171,
                y = 1070,
                w = 63,
                h = 101
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 249,
                y = 1079,
                w = 62,
                h = 101
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 321,
                y = 1088,
                w = 61,
                h = 101
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 393,
                y = 1078,
                w = 60,
                h = 101
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 468,
                y = 1076,
                w = 62,
                h = 101
            });

            jumpTexture.Add(new SDL.SDL_Rect
            {
                x = 539,
                y = 1070,
                w = 55,
                h = 101
            });

            #endregion

            #region attackTexture_hands_init
            attackTexture_hands.Add(new SDL.SDL_Rect
            {
                x = 10,
                y = 217,
                w = 63,
                h = 61
            });

            attackTexture_hands.Add(new SDL.SDL_Rect
            {
                x = 81,
                y = 215,
                w = 98,
                h = 63
            });

            attackTexture_hands.Add(new SDL.SDL_Rect
            {
                x = 184,
                y = 214,
                w = 66,
                h = 64
            });

            attackTexture_hands.Add(new SDL.SDL_Rect
            {
                x = 265,
                y = 217,
                w = 62,
                h = 61
            });

            attackTexture_hands.Add(new SDL.SDL_Rect
            {
                x = 333,
                y = 220,
                w = 92,
                h = 58
            });

            attackTexture_hands.Add(new SDL.SDL_Rect
            {
                x = 430,
                y = 217,
                w = 66,
                h = 61
            });
            #endregion

            #region takingDamageTexture_init
            takingDamageTexture = new SDL.SDL_Rect
            {
                x = 24,
                y = 2740,
                w = 68,
                h = 71
            };
            #endregion

            #region deathTexture_init
            deathTexture.Add(new SDL.SDL_Rect
            {
                x = 109,
                y = 2750,
                w = 69,
                h = 63
            });

            deathTexture.Add(new SDL.SDL_Rect
            {
                x = 200,
                y = 2750,
                w = 78,
                h = 63
            });

            deathTexture.Add(new SDL.SDL_Rect
            {
                x = 297,
                y = 2750,
                w = 69,
                h = 63
            });

            deathTexture.Add(new SDL.SDL_Rect
            {
                x = 379,
                y = 2750,
                w = 91,
                h = 63
            });

            deathTexture.Add(new SDL.SDL_Rect
            {
                x = 481,
                y = 2750,
                w = 88,
                h = 63
            });

            deathTexture.Add(new SDL.SDL_Rect
            {
                x = 576,
                y = 2750,
                w = 84,
                h = 63
            });
            #endregion

            #region jump_in_action_Texture_init
            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 20,
                y = 1286,
                w = 51,
                h = 67
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 88,
                y = 1299,
                w = 61,
                h = 54
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 171,
                y = 1268,
                w = 62,
                h = 85
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 251,
                y = 1267,
                w = 85,
                h = 86
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 350,
                y = 1271,
                w = 64,
                h = 74
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 430,
                y = 1277,
                w = 57,
                h = 76
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 500,
                y = 1270,
                w = 57,
                h = 83
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 573,
                y = 1273,
                w = 56,
                h = 80
            });

            jump_in_action_Texture.Add(new SDL.SDL_Rect
            {
                x = 651,
                y = 1268,
                w = 54,
                h = 85
            });
            #endregion

            standColliders.Add(new SDL.SDL_Rect
            {
                w = 49 * zoomOfTexture,
                h = 68 * zoomOfTexture
            });

            walkColliders.Add(new SDL.SDL_Rect
            {
                w = 49 * zoomOfTexture,
                h = 68 * zoomOfTexture
            });

            attackColliders.Add(new SDL.SDL_Rect
            {
                w = 49 * zoomOfTexture,
                h = 68 * zoomOfTexture
            });

            jumpColliders.Add(new SDL.SDL_Rect
            {
                w = 49 * zoomOfTexture,
                h = 68 * zoomOfTexture
            });

            deathColliders.Add(new SDL.SDL_Rect
            {
                w = 100 * zoomOfTexture,
                h = 30 * zoomOfTexture
            });

            timeratio_for_minijump = 0;

        }

        public override void prepareAnimation_stand(ref float currentFrame)
        {
            walking = false;
            if (jumping == true)
            {
                currentClip = riseTexture[(int)currentFrame];
            }
            else
            {
                if ((int)currentFrame >= standTexture.Count)
                {
                    currentFrame = 0;
                }
                currentClip = standTexture[(int)currentFrame];
            }
            if (((int)currentFrame >= riseTexture.Count-1) && (jumping == true))
            {
                jumping = false;
                currentFrame = 0;
            }
        }


        public override void prepareAnimation_takingDamage(ref float currentFrame)
        {
            currentClip = takingDamageTexture;
        }
        public override void prepareAnimation_death(ref float currentFrame)
        {
            if ((int)currentFrame >= deathTexture.Count)
            {
                currentFrame = 5;
            }
            currentClip = deathTexture[(int)currentFrame];
        }
        public override void prepareAnimation_dead(ref float currentFrame)
        {
            currentClip = deathTexture[3];
        }

        public override void prepareAnimation_walk(ref float currentFrame)
        {
            jumping = false;
            walking = true;
            if ((int)currentFrame >= walkTexture.Count)
            {
                currentFrame = 0;
            }
            currentClip = walkTexture[(int)currentFrame];
        }

        public override void prepareAnimation_jump(ref float currentFrame)
        {
           // if (((int)currentFrame >= jumpTexture.Count) )
            jumping = true;
            if (walking == true)
            {
                if ((int)currentFrame >= jump_in_action_Texture.Count)
                {
                    currentFrame = jumpTexture.Count - 1;
                }
                currentClip = jump_in_action_Texture[(int)currentFrame];
            }
            else
            {
                if ((velocityY > 0) && ((int)currentFrame == 0))
                {
                    currentFrame = jumpTexture.Count - 2;
                }
                if ((int)currentFrame >= jumpTexture.Count)
                {
                    currentFrame = jumpTexture.Count - 1;
                }
                currentClip = jumpTexture[(int)currentFrame];
            }
        }

        public override void prepareAnimation_attack(ref float currentFrame)
        {
            if ((int)currentFrame >= attackTexture_hands.Count)
            {
                currentFrame = 0;
            }
            currentClip = attackTexture_hands[(int)currentFrame];
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
            return attackColliders;
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
            if (animationStatus != "jump")
            {
                current_animationSpeed = animationSpeed.attack;
                currentColliders = getAttackColliders();
                animationStatus = "attack";
                damage += Sketch_damage;
                if (direction == true)
                {
                    attackDirection = -1;
                }
                else
                {
                    attackDirection = 1;
                }
            }
        }

        public override void a_release(ref float currentFrame)
        {
            damage -= Sketch_damage;
            if (animationStatus != "jump")
            {
                returnToStand();
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
            if ((attackTimer <= 0) || (animationStatus != "attack"))
            {
                attackTimer = attackTime;
                returnToStand();
            }
            velocityX = 0;
            velocityY = 0;
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
                    recoveryTimer = Sketch_recovery;
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
                animationDeath_timer = Sketch_deathTime;
                velocityX = 0;
                velocityY = 0;
                //velocityY = -velocity_status.jump;
            }
            if (animationStatus == "death")
            {
                recoveryTimer -= timestep;
                if (recoveryTimer <= 0)
                {
                    animationDeath_timer -= timestep;

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
