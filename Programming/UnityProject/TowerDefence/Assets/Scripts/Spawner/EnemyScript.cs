using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private float speed = 5.0f;

    private float health;

    private float armor;


	void Start () {
        transform.LookAt(new Vector3(0, 0.5f, 0), Vector3.up);
	}
	
	void Update () {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
	}
}
