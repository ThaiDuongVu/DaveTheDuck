using UnityEngine;

public class LevitationPadController : MonoBehaviour
{
    private Animator animator;
    private float force = 1500f;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
            animator.SetTrigger("pop");
        }
    }
}
