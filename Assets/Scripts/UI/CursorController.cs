using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CursorController : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

    public Image cursor;

    private float joystickAcclerator = 13f;
    private float mouseAccelerator = 15f;

    public GameController gameController;
    public GameObject buttons;

    private Vector2 clampPosition = new Vector2(385f, 215f);

    private void Awake()
    {
        raycaster = gameObject.GetComponent<GraphicRaycaster>();
        eventSystem = gameObject.GetComponent<EventSystem>();
    }


    private void Update()
    {
        ClickControl();

        if (gameController.GetGameOver())
        {
            MovementControl();
        }
    }

    private void ClickControl()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = cursor.transform.position;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, results);

        if (Input.GetButtonDown("Fire1"))
        {
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag("Button"))
                {
                    result.gameObject.GetComponent<Button>().OnPointerClick(pointerEventData);
                }
            }
        }

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("Button"))
            {
                for (int i = 0; i < buttons.transform.childCount; i++)
                {
                    buttons.transform.GetChild(i).GetComponent<ButtonController>().SetSize("small");
                }
                result.gameObject.GetComponent<ButtonController>().SetSize("large");
            }
            else
            {
                for (int i = 0; i < buttons.transform.childCount; i++)
                {
                    buttons.transform.GetChild(i).GetComponent<ButtonController>().SetSize("small");
                }
            }
        }
    }

    private void MovementControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector2 joystickMovement = new Vector2(horizontal, vertical) * joystickAcclerator;
        Vector2 mouseMovement = new Vector2(mouseX, mouseY) * mouseAccelerator;

        cursor.GetComponent<RectTransform>().Translate(joystickMovement + mouseMovement);
        ClampMovement();
    }

    private void ClampMovement()
    {
        Vector2 cursorPosition;
        cursorPosition = cursor.GetComponent<RectTransform>().anchoredPosition;

        if (cursorPosition.x > clampPosition.x)
        {
            cursorPosition.x = clampPosition.x;
        }
        else if (cursorPosition.x < -clampPosition.x)
        {
            cursorPosition.x = -clampPosition.x;
        }

        if (cursorPosition.y > clampPosition.y)
        {
            cursorPosition.y = clampPosition.y;
        }
        else if (cursorPosition.y < -clampPosition.y)
        {
            cursorPosition.y = -clampPosition.y;
        }

        cursor.GetComponent<RectTransform>().anchoredPosition = cursorPosition;
    }

    public void HideCursor()
    {
        cursor.gameObject.SetActive(false);
    }

    public void ShowCursor()
    {
        cursor.gameObject.SetActive(true);
    }
}
