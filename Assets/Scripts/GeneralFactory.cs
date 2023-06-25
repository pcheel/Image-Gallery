using UnityEngine;

public class GeneralFactory : MonoBehaviour, IFactory
{
    public IImageGallery CreateImageGallery(IFactory factory, GameObject imagePrefab, GameObject sceneLoaderPrefab, Transform imagesParent)
    {
        return new GeneralImageGallery(factory, imagePrefab, sceneLoaderPrefab, imagesParent);
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
    public ImagePresenter CreateImagePresenter(IImageModel imageModel, IImageView imageView, IImageGallery imageGallery)
    {
        return new ImagePresenter(imageModel, imageView, imageGallery);
    }
    public ImagesLoader CreateImagesLoader()
    {
        return new ImagesLoader();
    }
    public ImagesSaver CreateImagesSaver()
    {
        return new ImagesSaver();
    }
    public SceneLoader CreateSceneLoader(GameObject sceneLoaderPrefab, Transform parent)
    {
        GameObject sceneLoaderGO = Instantiate(sceneLoaderPrefab, parent);
        return sceneLoaderGO.GetComponent<SceneLoader>();
    }
    public ShowSceneInputHandler CreateShowSceneInputHandler()
    {
        return new ShowSceneInputHandler();
    }
    public ScreenOrientationSetter CreateScreenOrientationSetter()
    {
        return new ScreenOrientationSetter();
    }
    public ILoadingView CreateLoadingView(GameObject loadingViewPrefab, Transform parent)
    {
        GameObject loadingViewGO = Instantiate(loadingViewPrefab, parent);
        return loadingViewGO.GetComponent<ILoadingView>();
    }
}
