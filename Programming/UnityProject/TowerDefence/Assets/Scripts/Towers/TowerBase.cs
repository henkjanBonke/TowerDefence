using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    [SerializeField]
    protected float attackSpeed = 1, attackRange = 10, attackPower = 1, maxHealth, health = 100, armor = 0;
    protected bool isSelected = false;

	void Start ()
    {
        maxHealth = health;

        // Set collider radius to the desired attackRange
        GetComponent<SphereCollider>().radius = attackRange;
    }
	

	void Update ()
    {
		
	}

    public void UpgradeAttackSpeed()
    {
        attackSpeed *= 0.99f;
        Debug.Log(attackSpeed);
    }

    // Increase attack range by X% and update the collider radius
    public void UpgradeAttackRange()
    {
        attackRange *= 1.01f;
        GetComponent<SphereCollider>().radius = attackRange;
    }

    public void UpgradeAttackPower()
    {
        attackPower++;
    }

    public void UpgradeMaxHealth()
    {
        maxHealth += 10;
    }

    public void UpgradeArmor()
    {
        armor++;
    }

    public bool OutOfRange(GameObject enemy)
    {
        // if distance is greater then firerange
        float dis = Vector3.Distance(this.transform.position, enemy.transform.position);
        if (dis > attackRange)
        {
            return true;
        }
        return false;
    }

    public void Select()
    {
        isSelected = true;
    }
    public void DeSelect()
    {
        isSelected = false;
    }

    // attack algorithms
    public GameObject ClosestTarget(List<GameObject> enemysInRange, GameObject tower)
    {
        // loop through list of enemy's in range
        GameObject closestTarget = enemysInRange[enemysInRange.Count-1];
        float lowestDist = attackRange;
            for (int i = 0; i < enemysInRange.Count; i++)
            {
            // calculate distance between tower and enemy's
            float dis = Vector3.Distance(tower.transform.position, enemysInRange[i].transform.position);
                if (dis < lowestDist)
                {
                // store distance, overwrite when lower
                    lowestDist = dis;
                    closestTarget = enemysInRange[i];
                }
            }
        // return closest enemy
        return closestTarget;
        }
}
