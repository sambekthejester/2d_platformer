using System.Collections;
using System.Collections.Generic;
using UdemyT3.Inputs;
using UnityEngine;
using UdemyT3.Abstract.Inputs;
using UdemyT3.Movements;
using UdemyT3.Animation;
using UdemyT3.Combats;
using UdemyT3.Uis;
using UdemyT3.ExtensionMethods;

namespace UdemyT3.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        float _horizontal;
        float _vertical;
        bool _isJump;

        IPlayerInput _input;
        Mover _mover;
        Jump _jump;
        CharacterAnimation _characterAnimation;
        Flip _flip;
        OnGround _onGround;
        Health _health;
        Damage _damage;
        Climbing _climbing;
        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _damage = GetComponent<Damage>();
            _input = new PcInput();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _health = GetComponent<Health>();
            _climbing = GetComponent<Climbing>();
        }
        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas != null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayhealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnhealthChanged += displayhealth.WriteHealth;

            }
        }

        private void Update()
        {
            if (_health.IsDead) return;
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround &&_jump.IsJump);
            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.ClimbingAnimation(_climbing.IsClimbing);
        }

        private void FixedUpdate()
        {

            _climbing.ClimbAction(_vertical);
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }

            

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();
            if (health != null && collision.WasHitTopSide())
            {
                health.Takehit(_damage);
                _jump.JumpAction();
            }
        }


    }



}