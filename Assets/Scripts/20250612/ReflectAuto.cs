using JetBrains.Annotations;
using UnityEngine;

public class ReflectAuto : MonoBehaviour
{
    public Vector3 velocity = new Vector3(2f, -3f, 0f);

    public Vector3 gravity = new Vector3(0, -9.18f, 0);

    float damping = 0.9f;       // ���� ���

    void Update()
    {
        velocity += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision col)
    {
        Vector3 nomal = col.contacts[0].normal.normalized;          // �浹 ������ ���� ����

        Vector3 feflect = Vector3.Reflect(velocity, nomal);             // �ݻ� ���� ���

        velocity = feflect * damping;
    }
}
