using System;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text turnCounter;
    [SerializeField] private Text dayCounter;
    [SerializeField] private Text[] coinCounter;
    [SerializeField] private Text[] storageCounter;
    [SerializeField] private InventorySystem inventory;
    [SerializeField] private GameObject skipButton;
    [SerializeField] private TutorialSystem tutorialSystem;

    private DateTime startDate = new DateTime(2025, 1, 1);


    // Hari ke-0 = 1 Jan 2025 (bisa ubah tahunnya sesuai kebutuhan)

    private void Update()
    {
        coinCounter[1].text = $"Money : {inventory.coins} G";
        coinCounter[0].text = $"Money : {inventory.coins} G";

        //if (tutorialSystem.alur[4])
        //{
        //    skipButton.SetActive(true);
        //}

        //if(ButtonStorage.getCurrentButton() != null) Debug.Log(ButtonStorage.getCurrentButton().name);
    }

    public void countCoin()
    {
        //coinCounter[0].text = $"Money : {inventory.coins} G";
    }

    public void countStorageAmount()
    {
        // seed counter
        storageCounter[0].text = inventory.inventory[1].amount.ToString();
        storageCounter[1].text = inventory.inventory[2].amount.ToString();
        storageCounter[2].text = inventory.inventory[4].amount.ToString();
        storageCounter[3].text = inventory.inventory[5].amount.ToString();
        // yield counter

        storageCounter[4].text = inventory.inventory[9].amount.ToString();
        storageCounter[5].text = inventory.inventory[10].amount.ToString();
        storageCounter[6].text = inventory.inventory[11].amount.ToString();
        storageCounter[7].text = inventory.inventory[12].amount.ToString();

    }
    public void countTurn(int day)
    {
        turnCounter.text = "Turn " + (day / 6);
    }

    public void countDate(int day)
    {
        countTurn(day);

        // Hitung tanggal dari jumlah hari
        DateTime currentDate = startDate.AddDays(day);

        // Format: DD/MM
        dayCounter.text = currentDate.Day + "/" + currentDate.Month;
    }
        //[SerializeField] protected static GameObject uiPlacement;
        //static GameObject ui;
        //static public bool haveUiTable;

        //public void CreateUi(GameObject uiPrefab)
        //{
        //    ui = Instantiate(uiPrefab);
        //    ui.transform.SetParent(uiPlacement.transform);
        //    haveUiTable = true;
        //}

        //public void DestroyUi()
        //{
        //    Destroy(ui);
        //    haveUiTable = false;
        //}
    }
