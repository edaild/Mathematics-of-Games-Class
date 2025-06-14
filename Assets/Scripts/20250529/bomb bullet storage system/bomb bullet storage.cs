using System.Collections.Generic;
using UnityEngine;

public class bombbulletstorage : MonoBehaviour
{
    public Transform p0;            // 시작점(고정)
    public Transform p3;            // 도착점(고정)

    [Header("Random Ranges")]
    public float p1Radius = 2f;     // p0 근처에서 뽑는 반경

    public float p2Radius = 2f;     // p3 근처에서 뽑는 반경

    public float p1Height = 3f;     // p1 y축 추가 높이 (선택)

    public float p2Height = 2f;     // p2 y축 추가 높이 (선택)



    [HideInInspector] public Vector3 p1;

    [HideInInspector] public Vector3 p2;

    List<Vector3> points;

    float time = 0f;


    private void Awake()
    {
        GenerateRandomControlPoints();
        points = new List<Vector3> { p0.position, p1, p2, p3.position };
    }

    private void Update()
    {
        time += Time.deltaTime / 2f;
        transform.position = DeCastIjau(points, time);
    }

    void GenerateRandomControlPoints()
    {
        Vector2 rand1 = Random.insideUnitCircle * p1Radius;
        p1 = p0.position + new Vector3(rand1.x, 0f, rand1.y);
        p1.y += p1Height;                   // 살짝 위로 띄워 궤적 상승

        Vector2 rand2 = Random.insideUnitCircle * p2Radius;
        p2 = p3.position + new Vector3(rand2.x, 0f, rand2.y);
        p2.y += p2Height;
    }

    Vector3 DeCastIjau(List<Vector3> p, float t)
    {
        while (p.Count > 1)
        {
            int last = p.Count - 1;     // 마지막 점의 인덱스

            var next = new List<Vector3>(last);
            for (int i = 0; i < last; i++)
                next.Add(Vector3.Lerp(p[i], p[i + 1], t));
            p = next;                               // 한 단계 줄이기
        }
        // count 가  1이면 , p[0]에 님의 점이 곡선의 위치

        return p[0];                // 남은 한점이 곡선 위치
    }
}
