using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    [SerializeField]
    protected float attackSpeed = 1, attackRange = 1, maxHealth, health = 100, armor = 0;

	void Start ()
    {
        maxHealth = health;
	}
	

	void Update ()
    {
		
	}

    protected void UpgradeAttackSpeed()
    {
        attackSpeed *= 1.01f;
    }

    protected void UpgradeAttackRange()
    {
        attackRange *= 1.01f;
    }

    protected void UpgradeMaxHealth()
    {
        maxHealth += 10;
    }
}
