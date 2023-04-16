
using System.Collections;
using System.Collections.Generic;
using UdemyT3.Managers;
using UnityEngine;

namespace UdemyT3.Uis
{
    public class MenuCanvas : MonoBehaviour
    {

        [SerializeField] MenuPanel menuPanel;
        private void OnEnable()
        {
            GameManager.Instance.OnSceneChange += HandleSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChange -= HandleSceneChanged;
        }

        private void HandleSceneChanged(bool isActive)
        {
            if (isActive == menuPanel.gameObject.activeSelf) return;
            menuPanel.gameObject.SetActive(isActive);


        }
    }


}
