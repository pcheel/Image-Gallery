using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IImageModel
{
    public Action<Sprite> ChangeImageAction {get;set;}
    public void LoadImage();
}
