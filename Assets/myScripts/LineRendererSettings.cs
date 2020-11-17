using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderer : MonoBehaviour
{
    [SerializeField]
    LineRenderer rend;
    Vector3[] points;
    public LayerMask layerMask;

    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];

        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 20);

       // rend.SetPositions(points);
        rend.enabled = true;

    }


    public void AlignLineRenderer(LineRenderer rend)
    {
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);
        }
        //rend.SetPosition(points);
    }

    private void Update()
    {
        AlignLineRenderer(rend);
    }
}
