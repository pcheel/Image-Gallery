using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public Action<float> ChangeProgressAction;

    private AsyncOperation _asyncOperation;
    private bool _countingTime;
    private float _currentTimeCountAfterStartSceneLoading;
    private const string NEXT_SCENE_KEY = "NextSceneName";
    private const float MIN_LOADING_TIME = 2f;


    public void LoadSceneAsync(string sceneName)
    {
        PlayerPrefs.SetString(NEXT_SCENE_KEY, sceneName);
        SceneManager.LoadScene("LoadingScene");
    }
    public void LoadNextScene()
    {
        string nextSceneName;
        if (PlayerPrefs.HasKey(NEXT_SCENE_KEY))
        {
            nextSceneName = PlayerPrefs.GetString(NEXT_SCENE_KEY);
            _countingTime = true;
            _currentTimeCountAfterStartSceneLoading = 0f;
            _asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
            _asyncOperation.allowSceneActivation = false;
        }
    }

    private void Update()
    {
        if (_countingTime)
        {
            CheckEndOfLoading();
        }
    }
    private void CheckEndOfLoading()
    {
        _currentTimeCountAfterStartSceneLoading += Time.deltaTime;
        float progress = Mathf.Min(_currentTimeCountAfterStartSceneLoading / MIN_LOADING_TIME, _asyncOperation.progress);
        ChangeProgressAction?.Invoke(progress * 1.1f);
        if (progress == 0.9f)
        {
            _asyncOperation.allowSceneActivation = true;
        }
    }
}
