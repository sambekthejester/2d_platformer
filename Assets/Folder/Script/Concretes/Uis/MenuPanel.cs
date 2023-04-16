using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyT3.Managers;

namespace UdemyT3.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        

        public void StartButtonClicked()
        {
            GameManager.Instance.LoadScene(1);
        }
        public void ExitButtonClicked()
        {
            GameManager.Instance.ExitGame();
        }

    }
}
