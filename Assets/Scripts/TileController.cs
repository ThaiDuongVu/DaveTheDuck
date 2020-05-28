using UnityEngine;

public class TileController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private Material startMaterial;
    public Material paintMaterial;

    private bool painted;

    private void Awake()
    {
        meshRenderer = gameObject.transform.GetComponent<MeshRenderer>();
        startMaterial = meshRenderer.material;
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
                SetMaterial(paintMaterial);
            }
        }
    }

    private void SetMaterial(Material material)
    {
        meshRenderer.material = material;
        painted = true;
    }
}
