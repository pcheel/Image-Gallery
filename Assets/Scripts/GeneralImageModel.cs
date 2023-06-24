using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class GeneralImageModel : IImageModel
{
    private Sprite _image;
    // private ImagesLoader _imagesLoader;

    public Action<Sprite> ChangeImageAction{get;set;}

    // public GeneralImageModel(Sprite image)
    // {
    //     _image = image;
    //     // ChangeImageAction?.Invoke(_image);
    // }
    public void SetImage(Sprite image)
    {
        _image = image;
        ChangeImageAction?.Invoke(_image);
    }
    // public async Task<bool> LoadImage()
    // {
    //     Sprite image = await _imagesLoader.TryLoadImage();
    //     if (image != null)
    //     {
    //         _image = image;
    //         ChangeImageAction?.Invoke(_image);
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }
}
