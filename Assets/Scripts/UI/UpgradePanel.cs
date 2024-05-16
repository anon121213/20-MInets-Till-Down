using UnityEngine;
using DG.Tweening;

public class UpgradePanel: MonoBehaviour
{
    [SerializeField] private float _topPosY, _middlePosY;
    [SerializeField] private float _duration;
    [SerializeField] private RectTransform _panelTransform;
    
    public void OpenPanel()
    {
        gameObject.SetActive(true);
        _panelTransform.DOAnchorPosY(_middlePosY, _duration).SetUpdate(true);
        Time.timeScale = 0f;
    }

    public async void ClousePanel()
    {
        await _panelTransform.DOAnchorPosY(_topPosY, _duration).SetUpdate(true).AsyncWaitForCompletion();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
