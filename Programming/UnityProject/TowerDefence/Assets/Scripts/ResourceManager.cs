using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    [SerializeField]
    private int credits = 0;

    private UIBehaviour uIBehaviour;

	void Start ()
    {
		uIBehaviour = GameObject.Find("MainGameLogic").GetComponent<UIBehaviour>();
    }
	
	void Update () {
		
	}

    public void addCredits(int amount)
    {
        credits += amount;
        uIBehaviour.UpdateCredits(credits);
    }

    public void useCredits(int amount)
    {
        credits -= amount;
        uIBehaviour.UpdateCredits(credits);
    }
}
