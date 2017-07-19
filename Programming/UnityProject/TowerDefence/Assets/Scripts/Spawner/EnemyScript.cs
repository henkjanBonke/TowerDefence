using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float speed = 5.0f;

    private float health = 1.0f;
    private int money = 1;

    private float armor;

    private ResourceManager resourceManager;


	void Start () {
        transform.LookAt(new Vector3(0, 0.5f, 0), Vector3.up);
        resourceManager = GameObject.Find("MainGameLogic").GetComponent<ResourceManager>();
	}
	
	void Update () {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

        if(health <= 0)
        {
            resourceManager.addCredits(money);
            Destroy(this.gameObject);
        }
	}

    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
