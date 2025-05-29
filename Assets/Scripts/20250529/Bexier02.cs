using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Bexier02 : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();

    List<Vector3> pointPositions = new List<Vector3>(0);

    float timeValue = 0f;


    private void Awake()
    {
        foreach (var pt in points)
        {
            if (pt != null)
                pointPositions.Add(pt.position);
        }
    }

    private void Update()
    {
        timeValue += Time.deltaTime / 2f;           // 2�� ���� �ִϸ��̼�
        transform.position = DeCasteiau(pointPositions, timeValue);

    }

    Vector3 DeCasteiau(List<Vector3> p, float t)
    {
        while (p.Count > 1)
        {
            int last = p.Count - 1;     // ������ ���� �ε���

            var next = new List<Vector3>(last);
            for (int i = 0; i < last; i++)
                next.Add(Vector3.Lerp(p[i], p[i + 1], t));
            p = next;                               // �� �ܰ� ���̱�
        }
        // count ��  1�̸� , p[0]�� ���� ���� ��� ��ġ

        return p[0];                // ���� ������ � ��ġ
    }

}
