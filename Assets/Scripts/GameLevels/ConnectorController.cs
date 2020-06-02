using UnityEngine;

public class ConnectorController : MonoBehaviour
{
    private GameObject[] connectors;
    private int connectorsLength;
    
    private void Awake()
    {
        connectorsLength = gameObject.transform.childCount;
        connectors = new GameObject[connectorsLength];

        for (int i = 0; i < connectorsLength; i++)
        {
            connectors[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HideConnectors();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ShowConnectors();
        }
    }

    private void HideConnectors()
    {
        for (int i = 0; i < connectorsLength; i++)
        {
            connectors[i].SetActive(false);
        }
    }

    private void ShowConnectors()
    {
        for (int i = 0; i < connectorsLength; i++)
        {
            connectors[i].SetActive(true);
        }
    }
}
