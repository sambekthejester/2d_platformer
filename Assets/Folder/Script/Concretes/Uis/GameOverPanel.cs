using System.Collections;
using System.Collections.Generic;
using UdemyT3.Managers;
using UnityEngine;

namespace UdemyT3.Uis
{
    public class GameOverPanel : MonoBehaviour
    {

        public void YesButtonClicked()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void NoButtonClicked()
        {
            GameManager.Instance.LoadMenuAndUi(2f);

        }

    }

}