using UnityEngine;

public class ImagesSaver
{
    public void SaveImage(Sprite image)
    {
        byte[] imageData = image.texture.EncodeToPNG();
        System.IO.File.WriteAllBytes($"{Application.persistentDataPath}/cache.png", imageData);
    }
}
