using UnityEngine;
using UnityEngine.UI;

public class ShowManager : MonoBehaviour
{
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _imagePrefab;
    [SerializeField] private GameObject _sceneLoaderPrefab;
    [SerializeField] private Button _backButton;
    [SerializeField] private Transform _imageParent;
    
    private IFactory _factory;
    private SceneLoader _sceneLoader;
    private ShowSceneInputHandler _inputHandler;
    private ScreenOrientationSetter _screenOrientationSetter;

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform.parent);
        return factoryGO.GetComponent<IFactory>();
    }
    private void CreateAndLoadGeneralImage()
    {
        IImageView imageView = _factory.CreateImageView(_imagePrefab, _imageParent);
        ImagesLoader imagesLoader = _factory.CreateImagesLoader();
        Sprite image = imagesLoader.LoadSavedImage();
        imageView.SetImage(image);
    }
    private void LoadGalleryScene()
    {
        _sceneLoader.LoadSceneAsync("Gallery");
    }
    private void Start() 
    {
        CreateAndLoadGeneralImage();
        _screenOrientationSetter = _factory.CreateScreenOrientationSetter();
        _inputHandler = _factory.CreateShowSceneInputHandler();
        _sceneLoader = _factory.CreateSceneLoader(_sceneLoaderPrefab, transform.parent);
        _backButton.onClick.AddListener(LoadGalleryScene);
        _inputHandler.GetBackKeyAction += LoadGalleryScene;
        _screenOrientationSetter.SetScreenOrientation(true);
    }
    private void Awake()
    {
        _factory = CreateFactory();
    }
    private void Update() 
    {
        _inputHandler.HandleInput();
    }
}
