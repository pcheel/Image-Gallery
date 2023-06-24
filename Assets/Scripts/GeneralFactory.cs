using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFactory : MonoBehaviour, IFactory
{
    public IImageGallery CreateImageGallery(IFactory factory, ImagesLoader imagesLoader, GameObject imagePrefab, Transform imagesParent)
    {
        return new GeneralImageGallery(factory, imagesLoader, imagePrefab, imagesParent);
    }
    public IImageModel CreateImageModel()
    {
        return new GeneralImageModel();
    }
    public IImageView CreateImageView(GameObject imagePrefab, Transform parent)
    {
        GameObject imageGO = Instantiate(imagePrefab, parent);
        return imageGO.GetComponent<IImageView>();
    }
    public ImagePresenter CreateImagePresenter(IImageModel imageModel, IImageView imageView)
    {
        return new ImagePresenter(imageModel, imageView);
    }
}
