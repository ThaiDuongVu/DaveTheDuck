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

    private float movementSpeedMultiplier = 10f;
    public GameController gameController;

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
        if (Input.GetButtonDown("Fire1"))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = cursor.transform.position;

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag("Button"))
                {
                    result.gameObject.GetComponent<Button>().OnPointerClick(pointerEventData);
                }
            }
        }
    }

    private void MovementControl()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        cursor.GetComponent<RectTransform>().Translate(movement * movementSpeedMultiplier);
    }
}
