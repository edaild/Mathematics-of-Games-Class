using UnityEngine;

public class Bexier : MonoBehaviour
{
    // 3�� ������
    public Transform point0;

    public Transform point1;

    public Transform point2;

    public Transform point3;

    float timeValue = 0f;

    private void Update()
    {
        timeValue += Time.deltaTime / 2f;       // 2�� ���� �ִϸ��̼�
        //transform.position = GetPointOnBezierCurve01(point0.position, point1.position, point2.position, point3.position, timeValue);

        // ������ �ڵ� ����ȭ
        transform.position = GetPointOnBezierCurve02(point0.position, point1.position, point2.position, point3.position, timeValue);
    }

    Vector3 GetPointOnBezierCurve01(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
 
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        Vector3 abc = Vector3.Lerp(ab, bc, t);

        return abc;
    }

    Vector3 GetPointOnBezierCurve02(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return Mathf.Pow(1 - t, 3) * p0
            + Mathf.Pow(1 - t, 2) * 3 * t * p1
            + Mathf.Pow(1 - t, 2) * 3 * t * p2
            + Mathf.Pow(t, 3) * p3;
    }
}
