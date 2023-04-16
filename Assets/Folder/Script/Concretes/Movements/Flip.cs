using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyT3.Movements
{
    public class Flip : MonoBehaviour
    {

        public void FlipCharacter(float horizontal)
        {
            if (horizontal != 0)
            {


                float mathValue = Mathf.Sign(horizontal);
                if (transform.localScale.x == mathValue) return;
                transform.localScale = new Vector2(mathValue, 1f);

            }
        }
    }

}
