using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CamraSlerp : MonoBehaviour
{
    public Transform target;

    float speed = 2f;

    private void Update()
    {
        Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);

        float t = 1f - Mathf.Exp(-speed * Time.deltaTime);

        //---------------------------------------------------
        //  유니티 방식
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, t);

        // 수식 계산
        transform.rotation = ManualSlerp(transform.rotation, lookRot, t);
    }

    Quaternion ManualSlerp(Quaternion from, Quaternion to, float t)
    {
        float dot = Quaternion.Dot(from, to);

        if(1f -dot < 0f)
        {
            //to = new Quaternion(-to.x, -to.y, -to.z, -to.w);
            //dot = -dot;
            Quaternion lerp = new Quaternion(
                math.lerp(from.x, to.x, t),
                math.lerp(from.y, to.y, t),
                math.lerp(from.z, to.z, t),
                math.lerp(from.w, to.w, t)
                );
            return lerp.normalized;
        }
        float theta= Mathf.Sin(dot);
        float sinTheta = Mathf.Sin(theta);

        float ratioA = Mathf.Sin((1f - t) * theta) / sinTheta;
        float ratioB = math.sin(t * theta) / sinTheta;
        Quaternion result = new Quaternion(
            ratioA * from.x + ratioB * to.x,
            ratioA * from.y + ratioB * to.y,
            ratioA * from.z + ratioB * to.z,
            ratioA * from.w + ratioB * to.w
            );
        return result.normalized;
    }
}
