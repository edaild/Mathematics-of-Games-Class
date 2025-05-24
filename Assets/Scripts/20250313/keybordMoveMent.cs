using TreeEditor;
using Unity.Mathematics;
using UnityEngine;

public class keybordMoveMent : MonoBehaviour
{
    float speed = 5f;
    private void Update()
    {
        //-------------------------------------------------------------------------------------------------------
        // 키보드 Input을 받아서 X Y로 움직이는 객체 생성
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDTS01 = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += moveDTS01;

        //-------------------------------------------------------------------------------------------------------
        // 대각선 이동시 속도가 빨라지는 현상 해결
        Vector3 moveDTS02 = new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime;
        transform.position += moveDTS02;

        //-------------------------------------------------------------------------------------------------------
        //  normalized를 사용하지 않는 로직
        Vector3 direction = new Vector3(moveX, -moveY, 0);
        float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);

        if( magnitude > 0)
        {
            // nomalized 백터 정규화
            Vector3 nomalized = direction / magnitude;
            Vector3 move  = nomalized * speed * Time.deltaTime;
            transform.position += move;
        }

    }
}
