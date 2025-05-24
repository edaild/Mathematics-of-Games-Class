using UnityEngine;
using UnityEngine.UI;

public class MouseMoveMent : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetposition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                targetposition = hit.point;
            }
        }
        if (targetposition != null)
        {
            transform.position += (targetposition - transform.position).normalized * speed * Time.deltaTime;
        }

    }
}
