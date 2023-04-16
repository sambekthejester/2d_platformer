using System.Collections;
using System.Collections.Generic;
using UdemyT3.Combats;
using UdemyT3.ExtensionMethods;
using UnityEngine;

namespace UdemyT3.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        Damage _damage;
        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();

            if (health != null)
            {
                health.Takehit(_damage);

            }
        }

    }
}
