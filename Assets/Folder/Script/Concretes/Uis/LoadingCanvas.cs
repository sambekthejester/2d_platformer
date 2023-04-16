using System.Collections;
using System.Collections.Generic;
using UdemyT3.Managers;
using UnityEngine;

namespace UdemyT3.Uis
{
    public class LoadingCanvas : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.LoadMenuAndUi(3f);
        }



    }
}
