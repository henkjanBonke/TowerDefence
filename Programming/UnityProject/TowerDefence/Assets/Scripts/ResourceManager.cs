using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    [SerializeField]
    private int moneyResource = 0;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void addMoney(int amount)
    {
        moneyResource += amount;
    }

    public void useMoney(int amount)
    {
        moneyResource -= amount;
    }
}
