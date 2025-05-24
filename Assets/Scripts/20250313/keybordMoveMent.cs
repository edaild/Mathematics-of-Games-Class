using TreeEditor;
using Unity.Mathematics;
using UnityEngine;

public class keybordMoveMent : MonoBehaviour
{
    float speed = 5f;
    private void Update()
    {
        //-------------------------------------------------------------------------------------------------------
        // Ű���� Input�� �޾Ƽ� X Y�� �����̴� ��ü ����
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDTS01 = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += moveDTS01;

        //-------------------------------------------------------------------------------------------------------
        // �밢�� �̵��� �ӵ��� �������� ���� �ذ�
        Vector3 moveDTS02 = new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime;
        transform.position += moveDTS02;

        //-------------------------------------------------------------------------------------------------------
        //  normalized�� ������� �ʴ� ����
        Vector3 direction = new Vector3(moveX, -moveY, 0);
        float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);

        if( magnitude > 0)
        {
            // nomalized ���� ����ȭ
            Vector3 nomalized = direction / magnitude;
            Vector3 move  = nomalized * speed * Time.deltaTime;
            transform.position += move;
        }

    }
}
