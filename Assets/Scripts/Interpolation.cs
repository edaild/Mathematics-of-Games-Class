using UnityEngine;

public class Interpolation : MonoBehaviour
{
    public Transform startPos;

    public Transform endPos;

    [SerializeField] private float duration = 2f;       // 지속 시간
    [SerializeField] private float t = 0f;

    private void Update()
    {
        //-------------------------------------------------------------------------------

        //// 수식 사용
        //if (t < 1f)
        //{
        //    t += Time.deltaTime / duration;

        //    Vector3 a = startPos.position;
        //    Vector3 b = endPos.position;
        //    Vector3 p = (1f - t) * a + t * b;

        //    transform.position = p;
        //}

        ////-------------------------------------------------------------------------------

        //// 유니티 제공
        //t += Time.deltaTime / duration;
        //transform.position = Vector3.Lerp(startPos.position, endPos.position, t);

        ////-------------------------------------------------------------------------------

        // t를 활용하여 특정 위치를 왕복하는 적을 구현
        t = Mathf.PingPong(Time.time / duration, 1f);
        transform.position = Vector3.Lerp(startPos.position, endPos.position, t);

        //-------------------------------------------------------------------------------

        // Lerp 대신에 LerpUnclamped를 사용해도 가능
        t += Time.deltaTime / duration;

        transform.position = Vector3.LerpUnclamped(startPos.position, endPos.position, t);

        //-------------------------------------------------------------------------------
    }
}
