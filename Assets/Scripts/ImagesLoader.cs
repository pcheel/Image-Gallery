using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
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
    public async Task<Sprite> TryLoadImage()
    {
        _lastImageNumber++;
        UnityWebRequest req = UnityWebRequestTexture.GetTexture($"{URL}{_lastImageNumber}.jpg");
        Debug.Log(req.result);
        var asincOp = req.SendWebRequest();
        // Debug.Log(req.result);
        while (!asincOp.isDone)
        {
            await Task.Delay(1000/30);
        }

        if (req.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)req.downloadHandler).texture as Texture2D;
            return ConvertTexture2DToSprite(texture);
        }
        else
        {
            return null;
        }
    }

    private Sprite ConvertTexture2DToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), new Vector2(texture.width / 2, texture.height/2));
    }
}
