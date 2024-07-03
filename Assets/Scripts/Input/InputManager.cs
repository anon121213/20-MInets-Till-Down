using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _mobileinputUi;
    [SerializeField] private GameObject _aim;
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
        CheckDeviceDefault();
    }

    private void CheckDeviseYA()
    {
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

    private void CheckDeviceDefault()
    {
        if (Application.isMobilePlatform)
        {
            _player.GetComponent<MobileInput>().enabled = true;
            _aim.gameObject.SetActive(false);
            _mobileinputUi.SetActive(true);
        }
        else
        {
            _player.GetComponent<PCInput>().enabled = true;
            _mobileinputUi.SetActive(false);
        }
    }
}
