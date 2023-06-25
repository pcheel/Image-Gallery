using UnityEngine;
using System;

public class GeneralImageModel : IImageModel
{
    private Sprite _image;

    public Sprite image => _image;
    public Action<Sprite> ChangeImageAction{get;set;}

    public void SetImage(Sprite image)
    {
        _image = image;
        ChangeImageAction?.Invoke(_image);
    }
}
