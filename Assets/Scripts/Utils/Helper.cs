using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WE.Support
{
    public static class Helper 
    {
        public static float getAngle(Vector3 dir)
        {
            return getAngle(dir.x, dir.z);
        }
        public static float getAngle(float x, float y)
        {
            float getAngle_angle = 90f - Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            getAngle_angle = (getAngle_angle + 360f) % 360f;
            return GetFloat2(getAngle_angle);
        }
        public static float GetFloat2(float f)
        {
            return (float)((int)(f * 100f)) / 100f;
        }
        public static float Sin(float angle)
        {
            return Mathf.Sin(angle * Mathf.Deg2Rad);
        }

        public static float Cos(float angle)
        {
            return Mathf.Cos(angle * Mathf.Deg2Rad);
        }
    }
}

