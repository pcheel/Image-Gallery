using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GeneralImageGallery : IImageGallery
{
    private IFactory _factory;
    private ImagesLoader _imagesLoader;
    private List<ImagePresenter> _images;
    private GameObject _imagePrefab;
    private Transform _imagesParent;
    private ScrollRect _scrollRect;
    private bool _imagePoolIsEmpty;
    private const int DEFAULT_SCREEN_WIDTH = 1080;

    public GeneralImageGallery(IFactory factory, ImagesLoader imagesLoader, GameObject imagePrefab, Transform parent)
    {
        _images = new List<ImagePresenter>();
        _factory = factory;
        _imagesLoader = imagesLoader;
        _imagePrefab = imagePrefab;
        _imagesParent = parent;
        GridLayoutGroup gridLayoutGroup = parent.GetComponent<GridLayoutGroup>();
        CreateFirstPaarsImages(gridLayoutGroup);
        SearchScrollRect(_imagesParent);
        _scrollRect.onValueChanged.AddListener(CheckEndOfScroll);
    }
    public void CheckEndOfScroll(Vector2 scrollPosition)
    {
        // Debug.Log(scrollPosition);
        if (!_imagePoolIsEmpty && scrollPosition.y < 0.00f)
        {
            Debug.Log(scrollPosition);
            for (int i = 0; i < 2; i++)
            {
                CreateImage();
            }
        }
    }

    private async void CreateImage()
    {
        // if (_imagePoolIsEmpty)
        // {
        //     return;
        // }

        // _imagePoolIsEmpty = true;
        Sprite image = await _imagesLoader.TryLoadImage();
        if (image != null)
        {
            Debug.Log("not null");
            IImageModel imageModel = _factory.CreateImageModel();
            IImageView imageView = _factory.CreateImageView(_imagePrefab, _imagesParent);
            ImagePresenter imagePresenter = _factory.CreateImagePresenter(imageModel, imageView);
            imageModel.SetImage(image);
            _images.Add(imagePresenter);
            _imagePoolIsEmpty = false;
        }
        else
        {
            Debug.Log("null");
            _imagePoolIsEmpty = true;
        }
        // IImageModel imageModel = _factory.CreateImageModel(_imagesLoader);
        // IImageView imageView = _factory.CreateImageView(_imagePrefab, _imagesParent);
        // ImagePresenter imagePresenter = _factory.CreateImagePresenter(imageModel, imageView);
        // bool isCorrect = await imagePresenter.TryLoadImage();
        // Debug.Log(isCorrect);
        // _images.Add(imagePresenter);
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
