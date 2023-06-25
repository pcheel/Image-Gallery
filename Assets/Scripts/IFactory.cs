using UnityEngine;

public interface IFactory
{
    public IImageGallery CreateImageGallery(IFactory factory, GameObject imagePrefab, GameObject sceneLoaderPrefab, Transform imagesParent);
    public IImageModel CreateImageModel();
    public IImageView CreateImageView(GameObject imagePrefab, Transform parent);
    public ImagePresenter CreateImagePresenter(IImageModel imageModel, IImageView imageView, IImageGallery imageGallery);
    public ImagesLoader CreateImagesLoader();
    public ImagesSaver CreateImagesSaver();
    public SceneLoader CreateSceneLoader(GameObject sceneLoaderPrefab, Transform parent);
    public ShowSceneInputHandler CreateShowSceneInputHandler();
    public ScreenOrientationSetter CreateScreenOrientationSetter();
    public ILoadingView CreateLoadingView(GameObject loadingViewPrefab, Transform parent);
}