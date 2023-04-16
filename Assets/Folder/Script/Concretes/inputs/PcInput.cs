using System.Collections;
using System.Collections.Generic;
using UdemyT3.Abstract.Inputs;
using UnityEngine;


namespace UdemyT3.Inputs
{
    public class PcInput : IPlayerInput
    {


        public float Horizontal => Input.GetAxis("Horizontal");
        public bool IsJumpButtonDown => Input.GetButtonDown("Jump");

        public float Vertical => Input.GetAxis("Vertical");
    }

}
