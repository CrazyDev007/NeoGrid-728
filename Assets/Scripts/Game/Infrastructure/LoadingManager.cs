using System;
using System.Collections;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Infrastructure
{
    public class LoadingManager : MonoBehaviour, ILoadingView
    {
        public string defaultScene;
        public static LoadingManager Instance;

        public static event Action OnLoadComplete;

        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider loadingSlider;

        private ILoadingPresenter _loadingPresenter;

        private void Awake()
        {
            if (Instance != null && Instance == this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            //DontDestroyOnLoad(gameObject);
            _loadingPresenter.Initialize(this);
        }

        private void Start()
        {
            LoadSceneAdditive(defaultScene);
        }

        public string GetTextMessageView()
        {
            return "Test Message From View!";
        }

        public void LoadSceneAdditive(string sceneName)
        {
            StartCoroutine(LoadSceneAdditiveAsync(sceneName));
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

            // Example: set "MainScene" as default active scene 
            var scene = SceneManager.GetSceneByName(sceneName);
            if (scene.IsValid())
            {
                SceneManager.SetActiveScene(scene);
                Debug.Log("Active Scene set to: " + scene.name);
            }
            else
            {
                Debug.LogWarning("Scene not found or not loaded: MainScene");
            }

            OnLoadComplete?.Invoke();
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