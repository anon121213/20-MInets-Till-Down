using UnityEngine;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TileGenerator _tileGenerator;
    
    private void Update()
    {
        if (_tileGenerator.Progress < 1)
        {
            _progressBar.fillAmount = _tileGenerator.Progress;
        }
        else if (_tileGenerator.Progress >= 1)
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}
