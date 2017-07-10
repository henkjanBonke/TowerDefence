using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : MonoBehaviour
{
    public GameObject gunPoint;

    void Start ()
    {
        //attackRange = 10;
    }

	void Update ()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        RaycastHit hit;
        Vector3 dir = other.transform.position - gunPoint.transform.position;
        if (Physics.Raycast(gunPoint.transform.position, dir, out hit))
        {
            DrawLine(gunPoint.transform.position, hit.point, Color.black);
            //Destroy(other.gameObject);
        }
    }
    
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        //lr.StartColor(Color.black);
        lr.SetColors(color, color);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }  
}
