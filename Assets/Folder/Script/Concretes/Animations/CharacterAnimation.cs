using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyT3.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void MoveAnimation(float horizontal)
        {
            float mathValue = Mathf.Abs(horizontal);
            if (_animator.GetFloat("moveSpeed") == mathValue) return;
            _animator.SetFloat("moveSpeed", mathValue);

        }
        public void DyingAnimation()
        {
            _animator.SetTrigger("dying");
        }
        public void JumpAnimation(bool isJump)
        {
            if (_animator.GetBool("isJump") == isJump) return;
            _animator.SetBool("isJump", isJump);
        }
        public void ClimbingAnimation(bool isClimbing)
        {
            if (_animator.GetBool("isClimb") == isClimbing) return;
            _animator.SetBool("isClimb", isClimbing);
        }
    }


}
