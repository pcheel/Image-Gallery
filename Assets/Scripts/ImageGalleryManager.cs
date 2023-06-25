using UnityEngine;

public class ImageGalleryManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _imagePrefab;
    [SerializeField] private GameObject _sceneLoaderPrefab;
    [Header("Dependencies")]
    [SerializeField] private Transform _imagesParent;

    private IFactory _factory;
    private IImageGallery _imageGallery;
    private ScreenOrientationSetter _screenOrientationSetter;

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform);
        return factoryGO.GetComponent<IFactory>();
    }
    private void Start() 
    {
        _screenOrientationSetter = _factory.CreateScreenOrientationSetter();
        _screenOrientationSetter.SetScreenOrientation(false);
        _imageGallery = _factory.CreateImageGallery(_factory, _imagePrefab, _sceneLoaderPrefab, _imagesParent);
    }
    private void Awake() 
    {
        _factory = CreateFactory();
    }
}
