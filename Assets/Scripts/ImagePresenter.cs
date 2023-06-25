using UnityEngine;

public class ImagePresenter
{
    private IImageModel _imageModel;
    private IImageView _imageView;
    private IImageGallery _imageGallery;

    public ImagePresenter(IImageModel imageModel, IImageView imageView, IImageGallery imageGallery)
    {
        _imageModel = imageModel;
        _imageView = imageView;
        _imageGallery = imageGallery;
        Enable();
    }
    public void SetImage(Sprite image)
    {
        _imageView.SetImage(image);
    }
    public void TapOnImage()
    {
        _imageGallery.SaveImageAndLoadShowScene(_imageModel.image);
    }
    public void Enable()
    {
        _imageModel.ChangeImageAction += SetImage;
        if (_imageView.tapOnImageHandler != null)
        {
            _imageView.tapOnImageHandler.TapOnImageAction += TapOnImage;
        }
    }
    public void Disable()
    {
        _imageModel.ChangeImageAction -= SetImage;
        if (_imageView.tapOnImageHandler != null)
        {
            _imageView.tapOnImageHandler.TapOnImageAction -= TapOnImage;
        }
    }
}
