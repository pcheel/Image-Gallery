using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageGalleryManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _imagePrefab;
    [SerializeField] private Sprite _image;
    [Header("Dependencies")]
    [SerializeField] private Transform _imagesParent;

    private IFactory _factory;
    private IImageGallery _imageGallery;

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform);
        return factoryGO.GetComponent<IFactory>();
    }
    private void Start() 
    {
        _imageGallery = _factory.CreateImageGallery(_factory, new ImagesLoader(), _imagePrefab, _imagesParent);
        // for (int i = 0; i < 8; i++)
        // {
        //     _imageGallery.CreateImage();
        // }
    }
    private void Awake() 
    {
        _factory = CreateFactory();
        // Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        // Screen.autorotateToPortrait = false;
        // Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
