using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {

    public Text textFieldWaveCounter;
    public Text textFieldTimeTillNextWave;
    public Text textFieldCredits;

    private TowerBase currentTargetBuilding;
    private TowerBase targetBuilding;

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
    // Start UI Buttons
    public void AttackSpeedButton()
    {
        if(targetBuilding != null)
            targetBuilding.UpgradeAttackSpeed();
    }
    public void AttackRangeButton()
    {
        if (targetBuilding != null)
            targetBuilding.UpgradeAttackRange();
    }
    public void AttackDamageButton()
    {
        if (targetBuilding != null)
            targetBuilding.UpgradeAttackPower();
    }
    public void DefenceHealthButton()
    {
        if (targetBuilding != null)
            targetBuilding.UpgradeMaxHealth();
    }
    public void DefenceArmorButton()
    {
        if (targetBuilding != null)
            targetBuilding.UpgradeArmor();
    }
    // End UI Buttons

    void TargetTowerBuilding()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
                if(hit.collider.tag == "Tower")
                {
                    if(currentTargetBuilding == null) // first setup
                    {
                        currentTargetBuilding = hit.collider.transform.parent.gameObject.GetComponent<TowerBase>(); ;
                    }
                    if(currentTargetBuilding != hit.collider.transform.parent.gameObject.GetComponent<TowerBase>())
                    {
                        currentTargetBuilding.IsSelected(); // Deselect old target
                    }
                    targetBuilding = hit.collider.transform.parent.gameObject.GetComponent<TowerBase>();
                    targetBuilding.IsSelected(); // Select new Target
                    currentTargetBuilding = targetBuilding;
                }
                
        }
        
    }
}
