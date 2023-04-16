using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyT3.Abstract.Inputs;

 namespace UdemyT3.Inputs
{
    public class MobileInput : IPlayerInput
    {

        public float Horizontal => Input.GetAxis("Horizontal");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");
        public float Vertical => Input.GetAxis("Vertical");
       
    }

}
