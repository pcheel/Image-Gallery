using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ImagePresenter
{
    private IImageModel _imageModel;
    private IImageView _imageView;

    public ImagePresenter(IImageModel imageModel, IImageView imageView)
    {
        _imageModel = imageModel;
        _imageView = imageView;
        Enable();
        // _imageModel.LoadImage();
    }
    // public async Task<bool> TryLoadImage()
    // {
    //     return await _imageModel.LoadImage();
    // }
    public void SetImage(Sprite image)
    {
        _imageView.SetImage(image);
    }
    public void Enable()
    {
        _imageModel.ChangeImageAction += SetImage;
    }
    public void Disable()
    {
        _imageModel.ChangeImageAction -= SetImage;
    }
}
