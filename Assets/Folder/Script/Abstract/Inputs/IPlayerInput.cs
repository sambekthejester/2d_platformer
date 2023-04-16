using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyT3.Abstract.Inputs
{
    public interface IPlayerInput 
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsJumpButtonDown { get; }


    }
}
