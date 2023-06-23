using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralImageView : MonoBehaviour, IImageView
{
    private Image _image;
    
    public void SetImage(Sprite image)
    {
        Debug.Log("image3");
        _image.sprite = image;
    }

    private void Awake() 
    {
        _image = GetComponent<Image>();
    }
}
