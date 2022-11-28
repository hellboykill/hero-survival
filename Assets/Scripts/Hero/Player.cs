using Data.Storage;
using Data.User;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;
using WE.Manager;

namespace WE.Unit
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        private void Awake()
        {
            Instance = this;
        }

        float currentHp;

        public float CurrentHp => currentHp;

        [SerializeField]
        private float heroBaseSpeed = 5;
        [SerializeField]
        private LayerMask runableGround;
        private Rigidbody2D rigidbodyHero;
        private Animator animRunning;
        private MoveControl moveController;
       private SpriteRenderer spriteHero;

        public HpBarPlayer hpBar;


        private UserInfo playerData;
        public UserInfo PlayerData => playerData;

        private Vector3 tempVector3;

        private float currentPostion;
        public float Angle => moveController.Angle;
        public Vector3 DirectionUnit => moveController.Direction;
        public float Length => moveController.m_JoyData.length;
       

        public PlayerStats playerStats;
        public float MoveSpeed => playerStats.MovespeedAttribute.Value;
        public float AttackDamage => playerStats.AttackAttribute.Value;

        public float MaxHp => playerStats.HpAttribute.Value;
        public float ExpBonus => playerStats.Exp_Increase.Value;
        public float CoinBonus => playerStats.Reward_Increase.Value;
        public int CurrentMap => playerData.currentWave;

        public EHeroType CurrentHero => currentHero;
        EHeroType currentHero;

        public System.Action OnHpChange;


        public bool IsImortal => isImortal;
        bool isImortal;

        float cachedPercentHp;
        bool dieing;

        bool isGetRevieSkill;
        public bool IsGetRevieSkill => isGetRevieSkill;

        public bool IsAlive => !dieing;
        public int RevivalCount => revivalCount;
        int revivalCount = 0;
  

        void Start()
        {
            rigidbodyHero = GetComponent<Rigidbody2D>();
            spriteHero = GetComponent<SpriteRenderer>();
           animRunning = GetComponent<Animator>();
            currentPostion = transform.position.x;
            moveController = new MoveControl();
            moveController.RegisterJoyEvent();

            Debug.Log("runing test");
        }

            
        

        public void Init()
        {
            LoadData();
            hpBar.Despawn();

        }

        public void StartGame()
        {
            isGetRevieSkill = false;
            revivalCount = 0;
            isImortal = false;
            dieing = false;
            currentHp = MaxHp;
       //     tankMovement.Init();
            hpBar.Init();
        }

        public void LoadData()
        {
            playerData = new UserInfo();
            playerStats = new PlayerStats();

            currentHero = EHeroType.Blue;

        }

        void Update()
        {
            UpdateSpriteHero();
            Move();
        }

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

        private void UpdateSpriteHero()
        {     
              spriteHero.flipX = transform.position.x <= currentPostion ? true : false;
              currentPostion = transform.position.x;
        }


        public void Move()
        {

            if (IsTouching)
            {
                Move(DirectionUnit);
                animRunning.SetBool("running", true);
            }
            else animRunning.SetBool("running", false);

        }
        public virtual void Move(Vector3 direction)
        {
            
            tempVector3 = transform.position;
            tempVector3 += heroBaseSpeed * Time.deltaTime * direction;
           // this.transform.eulerAngles = new Vector3(0f, Angle, 0f);
            transform.position = tempVector3;
        }
        public void TakeDamage()
        {
            
        }

        public void FindNearestEnemy()
        {
           // GameCombatController.Instance.EnemyOnFieldList
        }

        public void UpdateMaxHp()
        {
          
        }
        public void AutoRecovery()
        {
        }
        public void RecoverHp(float value)
        {
           
        }
    }
    
}