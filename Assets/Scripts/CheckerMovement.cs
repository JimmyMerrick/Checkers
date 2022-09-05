using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerMovement : MonoBehaviour
{
public GameObject Sprite;

private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        Sprite = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Pressed();
    }

    void OnMouseDown() {
        isPressed = true;
    }

    void OnMouseUp() {
        isPressed = false;
    }

    void Pressed() {
        if (isPressed) {
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }
    }
}
