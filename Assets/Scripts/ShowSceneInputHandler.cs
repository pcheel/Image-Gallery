using UnityEngine;
using System;

public class ShowSceneInputHandler
{
    public Action GetBackKeyAction;

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GetBackKeyAction?.Invoke();
        }
    }
}
