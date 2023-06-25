using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class ImagesLoader
{
    private int _lastImageNumber;
    private const int TASK_DELAY = 30;
    private const string URL = "http://data.ikppbb.com/test-task-unity-data/pics/";

    public ImagesLoader()
    {
        _lastImageNumber = 0;
    }
    public async Task<Sprite> TryLoadImageFromWeb()
    {
        _lastImageNumber++;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture($"{URL}{_lastImageNumber}.jpg");
        var asincOp = request.SendWebRequest();
        while (!asincOp.isDone)
        {
            await Task.Delay(TASK_DELAY);
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
            return ConvertTexture2DToSprite(texture);
        }
        else
        {
            return null;
        }
    }
    public Sprite LoadSavedImage()
    {
        byte[] imageData = System.IO.File.ReadAllBytes($"{Application.persistentDataPath}/cache.png");
        Texture2D imageTexture = new Texture2D(400,400);
        imageTexture.LoadImage(imageData);
        return ConvertTexture2DToSprite(imageTexture);
    }

    private Sprite ConvertTexture2DToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), new Vector2(texture.width / 2, texture.height/2));
    }
}
