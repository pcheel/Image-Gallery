using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralImageGallery : IImageGallery
{
    private GameObject _imagePrefab;
    private IFactory _factory;
    private ImagesSaver _imagesSaver;
    private ImagesLoader _imagesLoader;
    private SceneLoader _sceneLoader;
    private ScrollRect _scrollRect;
    private List<ImagePresenter> _images;
    private Transform _imagesParent;
    private bool _imagePoolIsEmpty;
    private const int DEFAULT_SCREEN_WIDTH = 1080;

    public GeneralImageGallery(IFactory factory, GameObject imagePrefab, GameObject sceneLoaderPrefab, Transform parent)
    {
        _images = new List<ImagePresenter>();
        _factory = factory;
        _imagesLoader = _factory.CreateImagesLoader();
        _imagesSaver = _factory.CreateImagesSaver();
        _sceneLoader = _factory.CreateSceneLoader(sceneLoaderPrefab, parent.parent);
        _imagePrefab = imagePrefab;
        _imagesParent = parent;
        GridLayoutGroup gridLayoutGroup = parent.GetComponent<GridLayoutGroup>();
        CreateFirstPaarsImages(gridLayoutGroup);
        SearchScrollRect(_imagesParent);
        _scrollRect.onValueChanged.AddListener(CheckEndOfScroll);
        
    }
    public void CheckEndOfScroll(Vector2 scrollPosition)
    {
        if (!_imagePoolIsEmpty && scrollPosition.y < 0.00f)
        {
            for (int i = 0; i < 2; i++)
            {
                CreateImage();
            }
            _imagePoolIsEmpty = true;
        }
    }
    public void SaveImageAndLoadShowScene(Sprite image)
    {
        _imagesSaver.SaveImage(image);
        _sceneLoader.LoadSceneAsync("Show");
    }

    private async void CreateImage()
    {
        Sprite image = await _imagesLoader.TryLoadImageFromWeb();
        if (image != null)
        {
            IImageModel imageModel = _factory.CreateImageModel();
            IImageView imageView = _factory.CreateImageView(_imagePrefab, _imagesParent);
            ImagePresenter imagePresenter = _factory.CreateImagePresenter(imageModel, imageView, this);
            imageModel.SetImage(image);
            _images.Add(imagePresenter);
            _imagePoolIsEmpty = false;
        }
        else
        {
            _imagePoolIsEmpty = true;
        }
    }
    private void CreateFirstPaarsImages(GridLayoutGroup gridLayoutGroup)
    {
        int imagePaarsCount = CalculateImagePaarsCount(gridLayoutGroup);
        for (int j = 0; j < imagePaarsCount; j++)
        {
            CreateImage();
        }

    }
    private int CalculateImagePaarsCount(GridLayoutGroup gridLayoutGroup)
    {
        float newScreenAspectRation = (float)Screen.width / DEFAULT_SCREEN_WIDTH;
        return 2 * Mathf.CeilToInt((Screen.height - gridLayoutGroup.padding.top * newScreenAspectRation)/(newScreenAspectRation * (gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y)));
    }
    private void SearchScrollRect(Transform transform)
    {
        ScrollRect scrollRect = transform.GetComponent<ScrollRect>();
        if (scrollRect == null)
        {
            SearchScrollRect(transform.parent);
        }
        else
        {
            _scrollRect = scrollRect;
        }
    }
}
