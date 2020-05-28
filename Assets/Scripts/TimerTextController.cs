using UnityEngine;
using TMPro;

public class TimerTextController : MonoBehaviour
{
    public GameController gameController;
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    private void Update()
    {
        AnimationControl();
    }

    private void AnimationControl()
    {
        if (!gameController.GetGameOver())
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = ((int) gameController.GetTimer()).ToString();
        }
        else
        {
            animator.SetTrigger("gameOver");
        }
    }
}
