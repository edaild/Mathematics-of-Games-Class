using TMPro;
using UnityEngine;

public class Camera01 : MonoBehaviour
{
    float speed = 2f;
    public Transform target;
    public UnityEngine.Camera camera;

    public Vector3 offset = new Vector3(0f, 1f, -2f);

    [SerializeField] float smothTime = 0.3f;
    [SerializeField] float maxspeed = 100f;
    Vector3 nomara_PSO;
    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        nomara_PSO = camera.transform.position;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                target = hit.transform;
                Slerp();
            }
        }

        if (Input.GetMouseButton(1))
        {
            transform.position = nomara_PSO;

        }
    }

    private void Slerp()
    {
        Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);

        float t = 1f - Mathf.Exp(-speed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, t);
    }

    private void LateUpdate()
    {
        if (!target) return;

        Vector3 desired = target.position + target.TransformDirection(offset);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desired,
            ref velocity,
            smothTime,
            maxspeed,
            Time.deltaTime);
    }
}

