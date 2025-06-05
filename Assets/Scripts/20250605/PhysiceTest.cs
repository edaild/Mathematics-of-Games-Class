using UnityEngine;

public class PhysiceTest : MonoBehaviour
{
    public float forcePower = 10;
    private Rigidbody rb;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.forward * 10f, ForceMode.Force);    // 기본값
        //rb.AddForce(Vector3.forward * 10f, ForceMode.Impulse); 

    }

    private void FixedUpdate()
    {
        // space 바를 누를때
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * forcePower, ForceMode.Force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.linearVelocity.magnitude;      // 현재 속도 저장
    }
}
