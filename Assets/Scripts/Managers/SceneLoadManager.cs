using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class SceneLoadManager : MonoBehaviour
    {
        public string defaultScene;

        public UnityEvent OnSceneLoaded;
        public static SceneLoadManager Instance { get; private set; }

        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider loadingSlider;

        private void Awake()
        {
            if (Instance != null && Instance == this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSceneAdditive(defaultScene);
        }

        public void LoadSceneByName(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            loadingScreen.SetActive(true);
            loadingSlider.value = 0;

            var operation = SceneManager.LoadSceneAsync(sceneName);

            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingSlider.value = progress;
                Debug.Log($"Loading progress: {progress * 100}%");
                if (operation.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(1f);
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }

            loadingScreen.SetActive(false);
            Debug.Log($"Scene '{sceneName}' loaded successfully.");
        }


        public void LoadSceneAdditive(string sceneName)
        {
            StartCoroutine(LoadSceneAdditiveAsync(sceneName));
        }

        private IEnumerator LoadSceneAdditiveAsync(string sceneName)
        {
            loadingScreen.SetActive(true);
            loadingSlider.value = 0;

            var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                loadingSlider.value = progress;
                Debug.Log($"Loading progress: {progress * 100}%");
                if (operation.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(1f);
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }

            loadingScreen.SetActive(false);
            Debug.Log($"Scene '{sceneName}' loaded additively.");
        }

        public void UnloadScene(string sceneName)
        {
            StartCoroutine(UnloadSceneAsync(sceneName));
        }

        private IEnumerator UnloadSceneAsync(string sceneName)
        {
            var operation = SceneManager.UnloadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                yield return null;
            }

            Debug.Log($"Scene '{sceneName}' unloaded.");
        }
    }
}