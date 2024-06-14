using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private const string SceneClosing = nameof(SceneClosing);
    private const string SceneOpening = nameof(SceneOpening);
    
    [SerializeField] private TextMeshProUGUI _progressProc;
    [SerializeField] private Image _progressBar;
    
    private static SceneLoader _instance;
    private static bool _shouldPlayOpeningAnimation = false;

    private Animator _animator;
    private AsyncOperation _loadSceneOperation;

    public static void SwitchScene(int sceneId)
    {
        _instance._animator.SetTrigger(SceneClosing);
        
        _instance._loadSceneOperation = SceneManager.LoadSceneAsync(sceneId);
        _instance._loadSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        _instance = this;

        _animator = GetComponent<Animator>();
        
        if (_shouldPlayOpeningAnimation) _animator.SetTrigger(SceneOpening);
    }

    private void Update()
    {
        if (_loadSceneOperation != null)
        {
            print(_loadSceneOperation.progress * 100);
            _progressProc.text = Mathf.RoundToInt(_loadSceneOperation.progress * 100) + "%";
            _progressBar.fillAmount = _loadSceneOperation.progress;
        }
    }

    public void OnAnimationOver()
    {
        _shouldPlayOpeningAnimation = true;
        
        if (_loadSceneOperation != null)
        {
            _loadSceneOperation.allowSceneActivation = true;
        }
    }
}