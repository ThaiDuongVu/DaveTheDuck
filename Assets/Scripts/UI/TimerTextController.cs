using UnityEngine;
using TMPro;

public class TimerTextController : MonoBehaviour
{
    public GameController gameController;
    private Animator animator;

    private TextMeshProUGUI text;

    public Color32 countDownColor;
    public Color32 timerColor;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        AnimationControl();
    }

    private void AnimationControl()
    {
        if (gameController.GetGameStart())
        {
            SetColor(timerColor);
            if (!gameController.GetGameOver())
            {
                text.text = ((int)gameController.GetTimer()).ToString();
            }
            else
            {
                animator.SetTrigger("gameOver");
            }
        }
        else
        {
            SetColor(countDownColor);
            text.text = ((int)gameController.GetCountDown()).ToString();
        }
    }

    private void SetColor(Color32 color)
    {
        text.color = color;
    }
}
