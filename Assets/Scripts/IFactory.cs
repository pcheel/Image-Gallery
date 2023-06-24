using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    public IImageGallery CreateImageGallery(IFactory factory, ImagesLoader imagesLoader, GameObject imagePrefab, Transform imagesParent);
    public IImageModel CreateImageModel();
    public IImageView CreateImageView(GameObject imagePrefab, Transform parent);
    public ImagePresenter CreateImagePresenter(IImageModel imageModel, IImageView imageView);
}
