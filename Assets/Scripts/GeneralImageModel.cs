using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralImageModel : IImageModel
{
    private Sprite _image;
    private ImagesLoader _imagesLoader;

    public Action<Sprite> ChangeImageAction{get;set;}

    public GeneralImageModel(ImagesLoader imagesLoader)
    {
        _imagesLoader = imagesLoader;
    }
    public async void LoadImage()
    {
        // Debug.Log("load");
        _image = await _imagesLoader.TryLoadImage();
        Debug.Log("load2");
        ChangeImageAction?.Invoke(_image);
    }
}
