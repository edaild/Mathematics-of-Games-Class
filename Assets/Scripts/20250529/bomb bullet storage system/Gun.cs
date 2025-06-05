using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public int bullectCount;
    public float rotationSpeed = 1; 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < bullectCount; i++)
            {
                GameObject newObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
