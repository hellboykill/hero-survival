using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WE.Manager;
using WE.Unit;

    public class HeroMovement : MonoBehaviour
    {
        private MoveControl moveControl;
        public bool IsTouching
        {
            get
            {
                if (moveControl != null)
                {
                    return moveControl.bTouchMove;
                }
                return false;
            }

        }

        public void Init()
        {
            IsInitialize = true;
            moveControl = new MoveControl();
            moveControl.RegisterJoyEvent();
        }
        public void Stop()
        {
            IsInitialize = false;
            moveControl = null;
        }
        public float Angle => -moveControl.Angle;
        public Vector2 Direction => moveControl.Direction;
        public float Length => moveControl.m_JoyData.length;

        [Header("Game Object that visualize this Unit")]
        public GameObject Icon;

        bool IsInitialize;
        bool isCustomSpeed;
        float MoveSpeed => Player.Instance.MoveSpeed;
        float movespeedCustom;
        private void FixedUpdate()
        {
#if UNITY_EDITOR
            if (GamePlayManager.Instance != null)
            {
#endif
                if (IsInitialize && GamePlayManager.Instance.State == GameState.Gameplay)
                {
                    if (IsTouching)
                    {

                        transform.position += (Vector3)Direction * Time.fixedDeltaTime * MoveSpeed;
                        Icon.transform.eulerAngles = new Vector3(0, 0, Angle);
                        HeroController.Instance.UpdatePos();
                    }
                }
#if UNITY_EDITOR
            }
#endif
        }
    }