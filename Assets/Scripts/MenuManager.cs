using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _sceneLoaderPrefab;
    [Header("Dependencies")]
    [SerializeField] private Button _startButton;

    private IFactory _factory;
    private ScreenOrientationSetter _screenOrientationSetter;
    private SceneLoader _sceneLoader;

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform.parent);
        return factoryGO.GetComponent<IFactory>();
    }
    private void LoadGalleryScene()
    {
        _sceneLoader.LoadSceneAsync("Gallery");
    }
    private void Start() 
    {
        _screenOrientationSetter = _factory.CreateScreenOrientationSetter();
        _sceneLoader = _factory.CreateSceneLoader(_sceneLoaderPrefab, transform.parent);
        _screenOrientationSetter.SetScreenOrientation(false);
        _startButton.onClick.AddListener(LoadGalleryScene);
    }
    private void Awake() 
    {
        _factory = CreateFactory();
    }
}
