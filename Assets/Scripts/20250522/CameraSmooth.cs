using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f,1f,-2f);

    [SerializeField] float smothTime = 0.3f;
    [SerializeField] float maxspeed = 100f;

    Vector3 velocity = Vector3.zero;

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
