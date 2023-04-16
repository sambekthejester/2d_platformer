using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyT3.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage;

        public int HitDamage => damage;
        public void HitTarget(Health health)
        {

            health.Takehit(this);

        }



    }


}