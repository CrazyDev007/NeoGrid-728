using System.Collections;
using Game.Presentation.Presenters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Infrastructure
{
    public class LoadingManager : MonoBehaviour
    {
        public string defaultScene;
        public static LoadingManager Instance;

        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider loadingSlider;

        private LoadingPresenter _loadingPresenter;

        private void Awake()
        {
            if (Instance != null && Instance == this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            //DontDestroyOnLoad(gameObject);
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
            operation!.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                _loadingPresenter.UpdateProgress(progress);
                loadingSlider.value = _loadingPresenter.GetProgress();
                //
                if (operation.progress >= 0.9f)
                {
                    _loadingPresenter.FinishLoading();
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
            operation!.allowSceneActivation = false;

            while (!operation.isDone)
            {
                var progress = Mathf.Clamp01(operation.progress / 0.9f);
                _loadingPresenter.UpdateProgress(progress);
                loadingSlider.value = _loadingPresenter.GetProgress();
                //
                if (operation.progress >= 0.9f)
                {
                    _loadingPresenter.FinishLoading();
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
            while (!operation!.isDone)
            {
                yield return null;
            }

            Debug.Log($"Scene '{sceneName}' unloaded.");
        }
    }
}