using UnityEngine;

public class CameraOffect : MonoBehaviour
{
    public Transform target;            // 당구판 중심

    private float yaw = 0;

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        yaw += input * 100 * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0, 5, -7);
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
