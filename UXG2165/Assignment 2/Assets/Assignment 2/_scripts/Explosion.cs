using Assignment2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment2
{
    public class Explosion : DamagerScript
    {
        [SerializeField] private float decay = 1.0f;
        private void FixedUpdate()
        {
            if (decay > 0.0f)
            {
                decay -= Time.fixedDeltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}