using UnityEngine;
using TMPro;

public class CountdownTimer: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    private float _timeLeft = 10f;

    public float TimeLeft
    {
        get { return _timeLeft; }
        set { _timeLeft = Mathf.Clamp(value, 0, float.MaxValue); }
    }
    
    private void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var minutes = Mathf.FloorToInt(_timeLeft / 60F);
            var seconds = Mathf.FloorToInt(_timeLeft - minutes * 60);
            countdownText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
        else
        {
            countdownText.text = "00:00";
        }
    }
}