using UnityEngine;

public interface IImageView
{
    public TapOnImageHandler tapOnImageHandler{get;}
    public void SetImage(Sprite image);
}
