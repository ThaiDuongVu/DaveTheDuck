using UnityEngine;

public class TileController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private Material defaultMaterial;
    public Material paintMaterial;

    private bool painted;

    public GameController gameController;

    private void Awake()
    {
        meshRenderer = gameObject.transform.GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }

    private void Start()
    {
        painted = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!painted)
            {
                SetMaterial();
            }
        }
    }

    private void SetMaterial()
    {
        meshRenderer.material = paintMaterial;
        gameController.DecreaseTile();
        painted = true;
    }
}
