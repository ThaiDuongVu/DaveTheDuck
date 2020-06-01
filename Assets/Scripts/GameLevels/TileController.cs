using UnityEngine;

public class TileController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public Material defaultMaterial;
    private Material paintMaterial;

    private bool painted;

    public GameController gameController;

    private Animator animator;
    private bool popped;

    private void Awake()
    {
        meshRenderer = gameObject.transform.GetComponent<MeshRenderer>();
        paintMaterial = meshRenderer.material;

        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        painted = false;
        meshRenderer.material = defaultMaterial;

        popped = false;
    }
    
    private void Update()
    {
        if (!popped)
        {
            if (gameController.GetGameOver())
            {
                animator.speed = Random.Range(0.6f, 1f);
                animator.SetTrigger("pop");
                
                popped = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!painted)
            {
                animator.SetTrigger("pop");
                SetMaterial();

                painted = true;
            }
        }
    }

    private void SetMaterial()
    {
        meshRenderer.material = paintMaterial;
        gameController.DecreaseTile();
    }
}
