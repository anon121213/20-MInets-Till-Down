using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _mobileinputUi;
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
        if (DeviceCheck.DeviseChecker())
        {
            _player.AddComponent<MobileInput>();
            _mobileinputUi.SetActive(true);
        }
        else
        {
            _player.AddComponent<PCInput>();
            _mobileinputUi.SetActive(false);
        }
    }
}
