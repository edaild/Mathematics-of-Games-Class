using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Editor;

public class Player : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform sponPoint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToSpawn, sponPoint.position, Quaternion.identity);
        }
    }

}
