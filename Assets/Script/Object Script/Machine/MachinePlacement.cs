using System.Diagnostics;
using UnityEngine;

public class MachinePlacement : MonoBehaviour
{
    public bool haveMachine;
    public int signId;

    public GameObject signButton, machineButton, upgradeButton;
    private RotationControl rotationControl;
    public GameObject[] machine_prefabs;
    public MachineScript machine;
    public GameObject plantGrid;

    [SerializeField] private InventorySystem inventory;

    int sellValue = 0;
    //private Collider signCollider;
    [SerializeField] GameObject transparentCube;
    private void Awake()
    {
        rotationControl = FindAnyObjectByType<RotationControl>();
        //signCollider = GetComponent<Collider>();
    }

    void OnMouseOver()
    {
        // Check if the right mouse button is clicked while the cursor is over this object
        if (Input.GetMouseButtonDown(0) && !rotationControl._isRotating) // 1 = Right Mouse Button
        {
            if (!haveMachine)
            {
                //signButton.SetActive(!signButton.activeSelf);
                ButtonStorage.changeButton(signButton);
                signButton.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
            }
            else
            {

                //machineButton.SetActive(!machineButton.activeSelf);
                ButtonStorage.changeButton(machineButton);
                machineButton.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, rotationControl._currentAngle, gameObject.transform.rotation.z);
                if (machine.upgradeLevel >= 2) upgradeButton.SetActive(false);
                else upgradeButton.SetActive(true);
            }
         }
    }

    private void OnMouseEnter()
    {
        transparentCube.SetActive(true);
    }

    private void OnMouseExit()
    {
        transparentCube.SetActive(false);
    }

    public void AddMachine(int prefab_index)
    {

        if (machine != null) return;
        //machine = Instantiate(machine_prefabs[prefab_index]);
        //machine.transform.SetParent(gameObject.transform);
        //MachineScript machineScript = new();

        if (inventory.coins < 400) return;

        inventory.coins -= 400;
        sellValue += 300;
        MachineScript machineScript = new();
        if (prefab_index == 0)
        {
            machineScript = plantGrid.AddComponent<UltraVioletMachine>();
            machineScript.plantGrid = plantGrid;
        }
        else if(prefab_index == 1)
        {
            machineScript = plantGrid.AddComponent<ElectricTractorMachine>();
            machineScript.plantGrid = plantGrid;
        }
        machineScript.id = prefab_index;
        machineScript.signId = signId;
        machineScript.plantGrid = plantGrid;
        machine = machineScript;

        //signCollider.enabled = false;
        signButton.SetActive(false);
        haveMachine = true;
    }

    public void DestryMachine()
    {
        if(machine == null)
        {
            //Debug.Log("lkhjeda");
            return;
        }
        Destroy(plantGrid.GetComponent<MachineScript>());
        machine = null;
        haveMachine = false;
        machineButton.SetActive(false);

        inventory.coins += sellValue / 2;
        sellValue = 0;
    }

    public void upgradeMachine()
    {
        if (!haveMachine) return;

        int price = 1000 + (machine.upgradeLevel * machine.upgradePrice);
        if (inventory.coins < price) return;

        inventory.coins -= price;
        machine.UpgradeMachine();

        sellValue += 700;

        if (machine.upgradeLevel >= 2) upgradeButton.SetActive(false);
        ButtonStorage.changeButton(machineButton);
    }

    public void deAcvtivateUpgradeButton()
    {
        if (machine.upgradeLevel >= 2) upgradeButton.SetActive(false);
    }
}
