using Unity.VisualScripting;
using UnityEngine;

public class Playerbool : MonoBehaviour
{
    public Transform cameraoffect;
    public Transform playerBool01;
    public Transform playerBool02;

    public Vector3 tunplayer01PO;
    public Vector3 tunplayer02PO;

    public float forcePower = 10;
    public float MaxPower = 20;
    public int score = 0;
    private Rigidbody rb;
    [SerializeField] float speed;

    private void Start()
    {
        tunplayer01PO = playerBool01.position;
        tunplayer02PO = playerBool02.position;
        Debug.Log("플레이어 1번 턴 입니다.");
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(forcePower < MaxPower)
            {
                forcePower++;
            } 
        }
        else
        {
            forcePower = 10;
        }
       
    }

  

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                rb = hit.collider.attachedRigidbody;

                if(rb != null)
                { 
                    rb.AddForce(Vector3.forward * forcePower, ForceMode.Impulse);
                    SaveBoolPoint();
                }
            }
        }
    }

    void SaveBoolPoint()
    {
         tunplayer01PO = playerBool01.position;
         tunplayer02PO = playerBool02.position;
    }
}
