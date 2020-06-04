using UnityEngine;
using System.Collections;
using TMPro;

public class TileController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public Material defaultMaterial;
    private Material paintMaterial;
    public Material[] paintMaterials;

    private bool painted;

    public GameController gameController;

    private Animator animator;
    private bool popped;

    private const float minDelay = 12f;
    private const float maxDelay = 18f;

    public TextMeshPro bonusText;

    private void Awake()
    {
        meshRenderer = gameObject.transform.GetComponent<MeshRenderer>();

        if (gameController.mode.Equals("Endless"))
        {
            paintMaterial = paintMaterials[Random.Range(0, paintMaterials.Length)];
        }
        else
        {
            paintMaterial = meshRenderer.material;
        }

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

                if (gameController.mode.Equals("Endless"))
                {
                    if (gameController.GetGameStart())
                    {
                        gameController.timer += .1f;
                        gameController.score++;

                        Instantiate(bonusText.gameObject, gameObject.transform.position, bonusText.transform.rotation);
                    }
                    StartCoroutine("ResetPaint");
                }
                else
                {
                    gameController.DecreaseTile();
                }
                painted = true;
            }
        }
    }

    private void SetMaterial()
    {
        meshRenderer.material = paintMaterial;
    }

    private IEnumerator ResetPaint()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        if (!gameController.GetGameOver())
        {
            meshRenderer.material = defaultMaterial;
            paintMaterial = paintMaterials[Random.Range(0, paintMaterials.Length)];

            animator.SetTrigger("push");
            painted = false;
        }
    }
}
