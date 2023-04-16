using System.Collections;
using System.Collections.Generic;
using UdemyT3.Animation;
using UdemyT3.Combats;
using UdemyT3.ExtensionMethods;
using UdemyT3.Movements;
using UnityEngine;

namespace UdemyT3.Controllers
{
    public class EnemyController : MonoBehaviour
    {

        OnReachedEdge _onReachedEdge;
        Mover _mover;
        CharacterAnimation _characterAnimation;
        Flip _flip;
        Health _health;
        Damage _damage;

        bool _isOnEdge;
        float _direction;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _onReachedEdge = GetComponent<OnReachedEdge>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();

            _direction = 1f;

        }
        private void OnEnable()
        {
            _health.OnDead += DeadAction;
        }

        private void FixedUpdate()
        {
            if (_health.IsDead) return;

            _mover.HorizontalMove(_direction);
            _characterAnimation.MoveAnimation(_direction);

        }
        private void LateUpdate()
        {
            if (_health.IsDead) return;
            if (_onReachedEdge.ReachedEdge())
            {
                _direction *= -1;
                _flip.FlipCharacter(_direction);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();
            if (health != null && collision.WasHitLeftOrRightSide())
            {
                health.Takehit(_damage);
            }

        }

        public void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
         
        }
        private IEnumerator DeadActionAsync()
        {
            _characterAnimation.DyingAnimation();
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }
    }
}
