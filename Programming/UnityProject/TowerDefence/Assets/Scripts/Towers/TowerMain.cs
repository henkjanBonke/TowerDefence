using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMain : TowerBase
{
    public GameObject gunPoint;
    private List<GameObject> enemysInRange = new List<GameObject>();
    private float attackTimer = 0;
    MeshRenderer mr;

    void Start ()
    {
        // set the MeshRenderer
        mr = transform.GetComponentInChildren<MeshRenderer>();      
    }

	void Update ()
    {
        attackTimer += Time.deltaTime;
        // check if enemysInRange is still up to date
        for(int i = 0; i < enemysInRange.Count; i++)
        {
            if (enemysInRange[i] == null || OutOfRange(enemysInRange[i]))
            {
                enemysInRange.Remove(enemysInRange[i]);
            }
        }

        // check if the tower is allowed to shoot...
        if(attackTimer > attackSpeed)
        {
            // ... check if there is someone in range...
            if(enemysInRange.Count != 0)
            {
                // ... shoot and reset the attack timer.
                Fire();
                attackTimer = 0;
            }  
        }

        // change material on selection
        if (isSelected == true)
            mr.material.color = Color.blue;
        else
            mr.material.color = Color.white;
    }

    
    void Fire() // TODO, add attack method. e.g. laser, missile, mortar..., TODO, switch fire to attackScript
    {
        // create different algorithms for targeting method
        GameObject target = TargetAlgorithm(2);
  
        if (target != null)
        {
            RaycastHit hit;
            Vector3 dir = target.transform.position - gunPoint.transform.position;
            if (Physics.Raycast(gunPoint.transform.position, dir, out hit))
            {
                // ToDo switch DwarLine to fire particle
                DrawLine(gunPoint.transform.position, hit.point, Color.black);
                target.GetComponent<EnemyScript>().takeDamage(attackPower);
            }
        }else
        {
            enemysInRange.Remove(target);
        }
    }

    GameObject TargetAlgorithm(int value)
    {
        GameObject target;
        switch (value)
        {
            case 1:
                // target with most hp
                target = enemysInRange[0];
                return target;
            case 2:
                // closest target
                return ClosestTarget(enemysInRange, this.gameObject);
            case 3:
                // last target
                target = enemysInRange[enemysInRange.Count];
                return target;
            default:
                // first come first serve
                target = enemysInRange[0];
                return target;
        }
    }

    
    void OnTriggerStay(Collider other)
    {
        // if an object with the tag "Enemy" is in the trigger...
        if (other.tag == "Enemy")
        {
            // ... and it is NOT in the enemysInRange list ...
            if (!enemysInRange.Contains(other.gameObject))
            {
                // ...add it to the enemysInRange list.
                enemysInRange.Add(other.gameObject);
            }
        }
    }
    
    // Draw a line from start to end point with a set duration, remove the line when the duration is met.
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply")); // shader not found
        lr.material.color = color;
        //lr.startColor = color;
        lr.startWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }  
}
