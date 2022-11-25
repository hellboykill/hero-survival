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

        private MoveControl moveController;
        private Rigidbody2D rigidbodyHero;
        private Animator animRunning;
        private SpriteRenderer spriteHero;
        
        private float currentPostion;

        public bool IsTouching
        {
            get
            {
                if (moveController != null)
                {
                    return moveController.bTouchMove;
                }
                return false;
            }

        }
        void Start()
        {
            rigidbodyHero = GetComponent<Rigidbody2D>();
            spriteHero = GetComponent<SpriteRenderer>();
            animRunning = GetComponent<Animator>();
            currentPostion = transform.position.x;
            moveController = new MoveControl();
            moveController.RegisterJoyEvent();
        }

        public float Angle => moveController.Angle;
        public Vector3 DirectionUnit => moveController.Direction;
        public float Length => moveController.m_JoyData.length;
        // Update is called once per frame
        void Update()
        {
            //  spriteHero.flipX = (dirX > 0f) ? true : false;
           // Debug.Log(Input.mousePosition.x);
           // Debug.Log(Input.mousePosition.x > transform.position.x);
       //     Debug.Log(dirX > 0f);

            UpdateSpriteHero();
            //UpdateHeroPosition();
            Move();
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
            //if (moveController.joystickVec.y != 0)
            //{
            //    rigidbodyHero.velocity = new Vector2(movementJoyStick.joystickVec.x * heroBaseSpeed, movementJoyStick.joystickVec.y * heroBaseSpeed);
            //    animRunning.SetBool("running", true);
            //}
            //else
            //{
            //    rigidbodyHero.velocity = Vector2.zero;
            //    animRunning.SetBool("running", false);
            //    }
        }
        private Vector3 tempVector3;

        public void Move()
        {

            if (IsTouching)
            {
                Move(DirectionUnit);
            }

        }
        public virtual void Move(Vector3 direction)
        {
            
            tempVector3 = transform.position;
            tempVector3 += heroBaseSpeed * Time.deltaTime * direction;
            //this.transform.eulerAngles = new Vector3(0f, Angle, 0f);
            transform.position = tempVector3;
        }
        public void TakeDamage()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
        }

        public void FindNearestEnemy()
        {
           // GameCombatController.Instance.EnemyOnFieldList
        }
    }
    
}