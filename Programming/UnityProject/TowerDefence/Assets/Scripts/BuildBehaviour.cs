using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBehaviour : MonoBehaviour
{
    public GameObject attackTower;
    public GameObject researchTower;
    public GameObject constructionTower;
    public TempBuilding tempBuilding;

    GameObject towerToBuild;
   

	void Start ()
    {
		
	}
	
	void Update ()
    {
        BuildingPlacement();
	}

    public void TowerToBuild(string type)
    {
        
        switch (type)
        {
            case "AttackTower":
                towerToBuild = attackTower;
                tempBuilding.EnableTower(towerToBuild.name);
                Debug.Log("Building an Attack Tower");
                break;
            case "ResearchTower":
                towerToBuild = researchTower;
                tempBuilding.EnableTower(towerToBuild.name);
                Debug.Log("Building a Research Tower");
                break;
            case "ConstructionTower":
                towerToBuild = constructionTower;
                tempBuilding.EnableTower(towerToBuild.name);
                Debug.Log("Building a Construction Tower");
                break;
            default:
                Debug.Log("No Tower Selected");
                break;
        }
    }

    void BuildingPlacement()
    {
        if (towerToBuild != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
                if (hit.collider.tag == "ConstructionGround")
                {
                    tempBuilding.transform.position = hit.point;
                    Debug.Log("**");
                    // TODO check credits
                    if(Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        Instantiate(towerToBuild, hit.point, Quaternion.identity);
                        tempBuilding.DisableTower();
                        towerToBuild = null;
                    }
                    // stick towerToBuild to mouse
                    // on mouse click place towerToBuild
                }

        }
    }
}
