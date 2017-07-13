using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : TowerBase
{
    public GameObject gunPoint;
    private List<GameObject> enemysInRange = new List<GameObject>();
    private float attackTimer = 0;

    void Start ()
    {
        //attackRange = 10;        
    }

	void Update ()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer > attackSpeed)
        {
            if(enemysInRange.Count != 0)
            {
                Fire();
                attackTimer = 0;
            }  
        }
        //UpgradeAttackRange();
    }

    void Fire()
    {
        // create different algorithms for targeting method
        GameObject target = TargetAlgorithm(0);

        RaycastHit hit;
        Vector3 dir = target.transform.position - gunPoint.transform.position;
        if (Physics.Raycast(gunPoint.transform.position, dir, out hit))
        {
            DrawLine(gunPoint.transform.position, hit.point, Color.black);
            enemysInRange.Remove(target);
            Destroy(target.gameObject);
        }
    }

    GameObject TargetAlgorithm(int value)
    {
        GameObject target;
        switch (value)
        {
            case 1:
                target = enemysInRange[0];
                return target;
            case 2:
                target = enemysInRange[0];
                return target;
            case 3:
                target = enemysInRange[0];
                return target;
            default:
                target = enemysInRange[0];
                return target;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemysInRange.Add(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        
    }
    
    // Draw a line from start to end point with a set duration, remove the line when the duration is met.
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
