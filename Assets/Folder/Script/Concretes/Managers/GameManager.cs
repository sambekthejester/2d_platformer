
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyT3.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] float delayLevelTime = 1f;
        [SerializeField] int score;
        public static GameManager Instance { get; private set; }
        public event System.Action<bool> OnSceneChange;
        public event System.Action<int> OnScoreChanged;


        private void Awake()
        {
            SingletonThisGameObject();
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };
            OnSceneChange?.Invoke(false);

        }
        public void ExitGame()
        {
            Debug.Log("EXIT GAME");
            Application.Quit();
        }
        public void LoadMenuAndUi(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));

        }
        private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

            OnSceneChange?.Invoke(true);

        }

        public void IncreaseScore(int score = 0)
        {
            this.score += score;
            OnScoreChanged?.Invoke(this.score);
        }
    }

}