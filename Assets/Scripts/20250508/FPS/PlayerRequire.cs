using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerRequire : MonoBehaviour
{
    [SerializeField] LayerMask EnmyLayer;
    public Transform player;
    public Transform enemytarget;
    public UnityEngine.Camera camera;

    [Range(1f, 5f)] public float extend = 1.5f;

    private LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;                   // 단순 직선이므로 점2개
        lr.widthMultiplier = 0.05f;             // 두께
        lr.material = new Material(Shader.Find("Unlit/Color"))
        {
            color = Color.red
        };
    }

    private void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                enemytarget = hit.transform;

                Vector3 a = player.position;
                Vector3 b = enemytarget.position;
                Vector3 pred = Vector3.LerpUnclamped(a, b, extend);
                lr.SetPosition(0, a);
                lr.SetPosition(1, pred);

            }
        }
    }
}
