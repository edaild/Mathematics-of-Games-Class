using JetBrains.Annotations;
using UnityEngine;

public class BoomReflectAuto : MonoBehaviour
{
    public int boomCount;

    public Vector3 velocity = new Vector3(0f, -3f, 2f);

    public Vector3 gravity = new Vector3(0, -9.18f, 0);

    float damping = 0.9f;       // ���� ���

    void Update()
    {
        isBomb();
        velocity += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

    }



    private void OnCollisionEnter(Collision col)
    {
        Vector3 nomal = col.contacts[0].normal.normalized;          // �浹 ������ ���� ����

        Vector3 feflect = Vector3.Reflect(velocity, nomal);             // �ݻ� ���� ���

        velocity = feflect * damping;

        boomCount += 1;
    }

    void isBomb()
    {
        if(boomCount == 3)
        {
            Debug.Log("��ź�� �������ϴ�.");
            Destroy(gameObject);
        }
    }
}
