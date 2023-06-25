using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _loadingViewPrefab;
    [SerializeField] private GameObject _sceneLoaderPrefab;
    [SerializeField] private Transform _loadingViewParent;

    private IFactory _factory;
    private SceneLoader _sceneLoader;

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform.parent);
        return factoryGO.GetComponent<IFactory>();
    }
    private void Start() 
    {
        _sceneLoader = _factory.CreateSceneLoader(_sceneLoaderPrefab, transform.parent);
        ILoadingView loadingView = _factory.CreateLoadingView(_loadingViewPrefab, _loadingViewParent);
        ScreenOrientationSetter screenOrientationSetter = _factory.CreateScreenOrientationSetter();
        _sceneLoader.ChangeProgressAction += loadingView.ChangeProgress;
        screenOrientationSetter.SetScreenOrientation(false);
        _sceneLoader.LoadNextScene();
    }
    private void Awake() 
    {
        _factory = CreateFactory();
    }
}
