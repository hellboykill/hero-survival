using Data.Storage;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;

namespace Platformer.Hero
{

    public class HeroController : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        private float heroBaseSpeed = 5;
        [SerializeField]
        private LayerMask runableGround;

        public MovementJoyStick movementJoyStick;
        private Rigidbody2D rigidbodyHero;
        private Animator animRunning;
        private SpriteRenderer spriteHero;

        private float currentPostion;
        void Start()
        {
            rigidbodyHero = GetComponent<Rigidbody2D>();
            spriteHero = GetComponent<SpriteRenderer>();
            animRunning = GetComponent<Animator>();
            currentPostion = transform.position.x;
        }

        // Update is called once per frame
        void Update()
        {
            //  spriteHero.flipX = (dirX > 0f) ? true : false;
           // Debug.Log(Input.mousePosition.x);
           // Debug.Log(Input.mousePosition.x > transform.position.x);
       //     Debug.Log(dirX > 0f);

            UpdateSpriteHero();
            UpdateHeroPosition();
        }

        private void UpdateSpriteHero()
        {
            if (Input.GetMouseButtonDown(0))
            {            
                spriteHero.flipX = Input.mousePosition.x > currentPostion ? true : false;
                currentPostion = Input.mousePosition.x;
            }
        }

        private void UpdateHeroPosition()
        {
            if (movementJoyStick.joystickVec.y != 0)
            {
                rigidbodyHero.velocity = new Vector2(movementJoyStick.joystickVec.x * heroBaseSpeed, movementJoyStick.joystickVec.y * heroBaseSpeed);
                animRunning.SetBool("running", true);
            }
            else
            {
                rigidbodyHero.velocity = Vector2.zero;
                animRunning.SetBool("running", false);
            }
        }
        public void TakeDamage()
        {
            
        }
        public void FindNearestEnemy()
        {
           // GameCombatController.Instance.EnemyOnFieldList
        }
    }
    
}