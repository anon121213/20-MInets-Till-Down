using UnityEngine;

public class Aim : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        Cursor.visible = false;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _rectTransform.position = GetCursorPosition();
    }

    private Vector2 GetCursorPosition()
    {
        var _cursorPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return Camera.main.ScreenToWorldPoint(_cursorPos);
    }
}
