using UnityEngine;

public class Interpolation : MonoBehaviour
{
    public Transform startPos;

    public Transform endPos;

    [SerializeField] private float duration = 2f;       // ���� �ð�
    [SerializeField] private float t = 0f;

    private void Update()
    {
        //-------------------------------------------------------------------------------

        //// ���� ���
        //if (t < 1f)
        //{
        //    t += Time.deltaTime / duration;

        //    Vector3 a = startPos.position;
        //    Vector3 b = endPos.position;
        //    Vector3 p = (1f - t) * a + t * b;

        //    transform.position = p;
        //}

        ////-------------------------------------------------------------------------------

        //// ����Ƽ ����
        //t += Time.deltaTime / duration;
        //transform.position = Vector3.Lerp(startPos.position, endPos.position, t);

        ////-------------------------------------------------------------------------------

        // t�� Ȱ���Ͽ� Ư�� ��ġ�� �պ��ϴ� ���� ����
        t = Mathf.PingPong(Time.time / duration, 1f);
        transform.position = Vector3.Lerp(startPos.position, endPos.position, t);

        //-------------------------------------------------------------------------------

        // Lerp ��ſ� LerpUnclamped�� ����ص� ����
        t += Time.deltaTime / duration;

        transform.position = Vector3.LerpUnclamped(startPos.position, endPos.position, t);

        //-------------------------------------------------------------------------------
    }
}
