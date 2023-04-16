
using System.Collections;
using System.Collections.Generic;
using UdemyT3.Managers;
using UnityEngine;

namespace UdemyT3.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gamePlayObject;
        [SerializeField] GameOverPanel gameOverPanel;
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
            if (!isActive == gamePlayObject.activeSelf) return;
            gamePlayObject.SetActive(!isActive);

        }
        public void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }

    


}