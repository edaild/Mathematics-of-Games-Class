using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PredictionLineRender : MonoBehaviour
{

    public Transform startPos;      //A

    public Transform endPos;        //B

    [Range(1f, 5f)] public float extend = 1.5f;

    private LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;               // 단순 직선이므로 점 2개
        lr.widthMultiplier = 0.05f;         // 두께
        lr.material = new Material(Shader.Find("Unlit/Color"))
        { 
            color = Color.red
        };
    }

    void Update()
    {
        if (!startPos || !endPos) return;
        Vector3 a = startPos.position;
        Vector3 b = endPos.position;

        Vector3 pred = Vector3.LerpUnclamped(a, b, extend);
        lr.SetPosition(0, a);
        lr.SetPosition(1, pred);
    }
}
