using UnityEngine;
using System;

public interface IImageModel
{
    public Sprite image {get;}
    public Action<Sprite> ChangeImageAction {get;set;}
    public void SetImage(Sprite image);
}
