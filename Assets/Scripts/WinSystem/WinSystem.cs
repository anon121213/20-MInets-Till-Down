using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinSystem: MonoBehaviour
{
    [SerializeField] private CountdownTimer _timer;
    [SerializeField] private TextMeshProUGUI _survive;
    [SerializeField] private TextMeshProUGUI _killStatistic;
    [SerializeField] private TextMeshProUGUI _damageStatistic;
    [SerializeField] private TextMeshProUGUI _lvl;
    [SerializeField] private TextMeshProUGUI _xpStatistic;
    [SerializeField] private TextMeshProUGUI _specialLvlPoint;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private GameObject _pauseButtons;
    [SerializeField] private GameObject _statisticGO;
    
    [Space]
    [SerializeField] private float _middlePosX;
    [SerializeField] private float _middlePosY;
    [SerializeField] private float _buttonPosY;
    [SerializeField] private float _duration;
    
    [NonSerialized] public int _kills;
    [NonSerialized] public int _xpCount;
    [NonSerialized] public int _damageCount;

    private int _playScene;
    private const int _menuScene = 0;
    private RectTransform _pauseButtonstRect;

    private void Start()
    {
        Time.timeScale = 1f;
        _pauseButtonstRect = _pauseButtons.GetComponent<RectTransform>();
        _playScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        CheckWin();
    }
    
    private void CheckWin()
    {
        if (_timer.TimeLeft <= 0)
        {
            Time.timeScale = 0;
            Staticstic();
            ShowAnimations();
        }
    }
    
    private void Staticstic()
    {
        _statisticGO.SetActive(true);
        
        _killStatistic.text = $"Simple enemy killed: {_kills}";
        _xpStatistic.text = $"Xp received: {_xpCount}";
        _damageStatistic.text = $"Damage: {_damageCount}";
        _specialLvlPoint.text = $"Special Level Point: {_playerStats.SpecialLvlPoint}";
        _lvl.text = $"Level: {_playerStats.Lvl}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(_playScene);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(_menuScene);
    }
    
    private void ShowAnimations()
    {
        _survive.rectTransform.DOAnchorPosY(_middlePosY, _duration).SetUpdate(true);
        _killStatistic.rectTransform.DOAnchorPosX(_middlePosX, _duration).SetUpdate(true);
        _damageStatistic.rectTransform.DOAnchorPosX(_middlePosX, _duration).SetUpdate(true);
        _xpStatistic.rectTransform.DOAnchorPosX(_middlePosX, _duration).SetUpdate(true);
        _specialLvlPoint.rectTransform.DOAnchorPosX(_middlePosX, _duration).SetUpdate(true);
        _lvl.rectTransform.DOAnchorPosX(_middlePosX, _duration).SetUpdate(true);
        _pauseButtonstRect.DOAnchorPosY(_buttonPosY, _duration).SetUpdate(true);
    }
}