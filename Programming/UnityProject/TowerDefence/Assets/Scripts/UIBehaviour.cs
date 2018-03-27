using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {

    public Text textFieldWaveCounter;
    public Text textFieldTimeTillNextWave;
    public Text textFieldCredits;

    private TowerBase oldTargetBuilding;
    private TowerBase targetBuilding;

    BuildBehaviour buildBehavior;

    void Start ()
    {

    }
	
	void Update ()
    {
        TargetTowerBuilding();
    }

    public void UpdateWaveText(string t)
    {
        textFieldWaveCounter.text = t;
    }

    public void UpdateTTNW(string t)
    {
        textFieldTimeTillNextWave.text = t;
    }
    
    public void UpdateCredits(int amount)
    {
        textFieldCredits.text = amount.ToString();
    }
    // UI Buttons
    public void AttackSpeedButton()
    {
        if(!targetBuilding)
            targetBuilding.UpgradeAttackSpeed();
    }
    public void AttackRangeButton()
    {
        if (!targetBuilding)
            targetBuilding.UpgradeAttackRange();
    }
    public void AttackDamageButton()
    {
        if (!targetBuilding)
            targetBuilding.UpgradeAttackPower();
    }
    public void DefenceHealthButton()
    {
        if (!targetBuilding)
            targetBuilding.UpgradeMaxHealth();
    }
    public void DefenceArmorButton()
    {
        if (!targetBuilding)
            targetBuilding.UpgradeArmor();
    }
    // End UI Buttons

    // Building buttons
    public void BuildTower(string type)
    {
        buildBehavior.TowerToBuild(type);
    }


    // End Building buttons

    void TargetTowerBuilding()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
                if(hit.collider.tag == "Tower")
                {
                    if(oldTargetBuilding == null) // first setup
                    {
                        oldTargetBuilding = hit.collider.transform.parent.gameObject.GetComponent<TowerBase>(); ;
                    }
                    if(oldTargetBuilding != hit.collider.transform.parent.gameObject.GetComponent<TowerBase>())
                    {
                        oldTargetBuilding.DeSelect(); // Deselect old target
                    }
                    targetBuilding = hit.collider.transform.parent.gameObject.GetComponent<TowerBase>();
                    targetBuilding.Select(); // Select new Target
                    oldTargetBuilding = targetBuilding;
                }else // Did not click on a tower, deselecting current
                {
                    if(targetBuilding != null)
                        targetBuilding.DeSelect(); // Deselect old target
                    oldTargetBuilding = null;
                    targetBuilding = null;
                }
                
        }
        
    }
}
