using UnityEngine;
using UnityEngine.UI;

public class GeneralImageView : MonoBehaviour, IImageView
{
    private Image _image;
    private TapOnImageHandler _tapOnImageHandler;

    public TapOnImageHandler tapOnImageHandler => _tapOnImageHandler;
    
    public void SetImage(Sprite image)
    {
        _image.sprite = image;
    }

    private void Awake() 
    {
        _image = GetComponent<Image>();
        _tapOnImageHandler = GetComponent<TapOnImageHandler>();
    }
}
