using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour, ILoadingView
{
    [Header("Dependencies")]
    [SerializeField] private TMP_Text _progressText;
    [SerializeField] private Image _progressBar;

    public void ChangeProgress(float progress)
    {
        _progressText.text = $"{(int)(progress * 100)}%";
        _progressBar.fillAmount = 1 - progress;
    }
}
