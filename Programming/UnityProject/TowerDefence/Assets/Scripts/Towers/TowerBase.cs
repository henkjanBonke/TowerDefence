using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    [SerializeField]
    protected float attackSpeed = 1, attackRange = 10, maxHealth, health = 100, armor = 0, attackPower = 1;

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
        attackSpeed *= 1.01f;
    }

    // Increase attack range by X% and update the collider radius
    public void UpgradeAttackRange()
    {
        attackRange *= 1.01f;
        GetComponent<SphereCollider>().radius = attackRange;
    }

    public void UpgradeMaxHealth()
    {
        maxHealth += 10;
    }
}
