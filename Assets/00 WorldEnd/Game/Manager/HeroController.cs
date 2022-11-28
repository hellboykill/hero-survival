using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WE.Manager
{
    public class HeroController : MonoBehaviour
    {
        public Transform playerBody;


        public static HeroController Instance;

        private void Awake()
        {
            Instance = this;
        }


        public void UpdatePos()
        {

        }

    }

}

