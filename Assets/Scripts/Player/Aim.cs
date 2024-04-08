using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector2 _cursorPos;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        gameObject.transform.position = GetCursorPosition();
    }

    private Vector2 GetCursorPosition()
    {
        _cursorPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        return Camera.main.ScreenToWorldPoint(_cursorPos);
    }
}
