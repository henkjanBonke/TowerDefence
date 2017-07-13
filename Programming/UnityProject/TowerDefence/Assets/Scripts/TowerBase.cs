using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    [SerializeField]
    protected float attackSpeed = 0.1f, attackRange = 10, maxHealth, health = 100, armor = 0;

	void Start ()
    {
        maxHealth = health;

        // Set collider radius to the desired attackRange
        GetComponent<SphereCollider>().radius = attackRange;
    }
	

	void Update ()
    {
		
	}

    protected void UpgradeAttackSpeed()
    {
        attackSpeed *= 1.01f;
    }

    // Increase attack range by X% and update the collider radius
    protected void UpgradeAttackRange()
    {
        attackRange *= 1.01f;
        GetComponent<SphereCollider>().radius = attackRange;
    }

    protected void UpgradeMaxHealth()
    {
        maxHealth += 10;
    }
}
