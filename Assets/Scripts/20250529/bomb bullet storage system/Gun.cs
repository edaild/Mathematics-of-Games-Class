using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public int bullectCount;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
    }
}
