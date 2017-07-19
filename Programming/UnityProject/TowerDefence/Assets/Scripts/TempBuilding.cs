using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBuilding : MonoBehaviour {

    public GameObject attackTower;
    public GameObject researchTower;
    public GameObject constructionTower;

    bool visable = false;

    void Start ()
    {
        attackTower.SetActive(false);
    }
	
	void Update ()
    {
		
	}

    public void EnableTower(string type)
    {
        visable = true;
        switch (type)
        {
            
            case "AttackTower":
                attackTower.SetActive(true);
                break;
            case "ResearchTower":
                researchTower.SetActive(true);
                break;
            case "ConstructionTower":
                constructionTower.SetActive(true);
                break;
            default:
                Debug.Log("No Tower Selected");
                break;
        }
    }
    public void DisableTower()
    {
        attackTower.SetActive(false);
        researchTower.SetActive(false);
        constructionTower.SetActive(false);
        visable = false;
    }

    public bool Visable
    {
        get
        {
            return visable;
        }
    }
}
