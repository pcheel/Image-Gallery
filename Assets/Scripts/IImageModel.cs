using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public interface IImageModel
{
    public Action<Sprite> ChangeImageAction {get;set;}
    public void SetImage(Sprite image);
    // public Task<bool> LoadImage();
}
