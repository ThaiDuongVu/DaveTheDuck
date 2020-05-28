using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject floor;
    private GameObject[] tiles;

    public int tileCount;

    private float timer;

    private void Awake()
    {
        tileCount = floor.transform.childCount;
        tiles = new GameObject[tileCount];
    }
    
    private void Start()
    {
        timer = 0f;
    }

    
    private void Update()
    {
        timer += Time.deltaTime;
    }
}
