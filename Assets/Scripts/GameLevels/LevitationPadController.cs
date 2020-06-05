using UnityEngine;

public class LevitationPadController : MonoBehaviour
{
    private Animator animator;
    private float force = 1600f;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().mass = 2f;
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
            other.gameObject.GetComponent<Rigidbody>().mass = 5f;
            
            animator.SetTrigger("pop");

            Camera.main.transform.parent.GetComponent<CameraShake>().Shake();
        }
    }
}
