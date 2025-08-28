using System;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text turnCounter;
    [SerializeField] private Text dayCounter;
    [SerializeField] private Text coinCounter;
    [SerializeField] private InventorySystem inventory;

    private DateTime startDate = new DateTime(2025, 1, 1);
    // Hari ke-0 = 1 Jan 2025 (bisa ubah tahunnya sesuai kebutuhan)

    public void countCoin()
    {
        coinCounter.text = $"Money : {inventory.coins} G";
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
