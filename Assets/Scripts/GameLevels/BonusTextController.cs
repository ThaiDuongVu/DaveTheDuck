using UnityEngine;

public class BonusTextController : MonoBehaviour
{    
    private void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
            Destroy(gameObject);
        }
    }
}
