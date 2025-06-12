using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Editor;

public class Player : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
        }
    }

}
