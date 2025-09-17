using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    // kubis, tomat, timun, dan strawberi
    public int[] yieldsTotal_Array = new int[4]; 
    public int[] yieldsMin_Array = new int[4];
    public int[] yieldsMax_Array = new int[4];

    public EnemyStats minStats = new EnemyStats();
    public EnemyStats maxStats = new EnemyStats();

    public int enemyEncounter = 0;

    [SerializeField] private Text kubisCounter, tomatCounter, timunCounter, strawberiCounter;
    [SerializeField] private Text[] duelYieldCounters, playerYieldCounters;
    [SerializeField] private InventorySystem inventorySystem;

    InventoryObject kubisInventory, tomatInventory, timunInventory, strawberiInventory;

    [SerializeField] private GameObject DuelPanel;

    public int durationCounterDuel;

    private void Awake()
    {
        kubisInventory = inventorySystem.GetInventoryObjectBy(9);
        tomatInventory = inventorySystem.GetInventoryObjectBy(10);
        timunInventory = inventorySystem.GetInventoryObjectBy(11);
        strawberiInventory = inventorySystem.GetInventoryObjectBy(12);
    }
    public void EnemyGetYields()
    {
        ChangeMinMaxYields();

        int kubisYield     = Random.Range(yieldsMin_Array[0], yieldsMax_Array[0]);
        int tomatYield     = Random.Range(yieldsMin_Array[1], yieldsMax_Array[1]);
        int timunYield     = Random.Range(yieldsMin_Array[2], yieldsMax_Array[2]);
        int strawberiYield = Random.Range(yieldsMin_Array[3], yieldsMax_Array[3]);

        yieldsTotal_Array[0] += kubisYield;
        yieldsTotal_Array[1] += tomatYield;
        yieldsTotal_Array[2] += timunYield;
        yieldsTotal_Array[3] += strawberiYield;

        //kubisCounter.text     = $"Kubis           :  {yieldsTotal_Array[0]}";
        //tomatCounter.text     = $"Tomat         :  {yieldsTotal_Array[1]}";
        //timunCounter.text     = $"Timun        :  {yieldsTotal_Array[2]}";
        //strawberiCounter.text = $"Strawberi  :  {yieldsTotal_Array[3]}";

        LoadEnemyStock();
    }

    public void LoadEnemyStock()
    {
        kubisCounter.text = $"Kubis          :  {yieldsTotal_Array[0]}";
        tomatCounter.text = $"Tomat         :  {yieldsTotal_Array[1]}";
        timunCounter.text = $"Timun         :  {yieldsTotal_Array[2]}";
        strawberiCounter.text = $"Strawberi  :  {yieldsTotal_Array[3]}";
    }

    public void ChangeMinMaxYields()
    {
        int day = gameManager.day / 6;

        yieldsMin_Array [0] = minStats.kubisStats[day];
        yieldsMax_Array [0] = maxStats.kubisStats[day];
        yieldsMin_Array [1] = minStats.tomatStats[day];
        yieldsMax_Array [1] = maxStats.tomatStats[day];
        yieldsMin_Array [2] = minStats.timunStats[day];
        yieldsMax_Array [2] = maxStats.timunStats[day];
        yieldsMin_Array [3] = minStats.strawberiStats[day];
        yieldsMax_Array [3] = maxStats.strawberiStats[day];
    }

    public void ChangeEnemy()
    {
        enemyEncounter++;
        for (int i = 0; i < yieldsTotal_Array.Length; i++)
        {
            yieldsTotal_Array[i] = 0;
        }
        LoadEnemyStock();
    }

    public void StartDuel()
    {
        StartCoroutine(CountYieldDuel());
    }

    public void DuelPlayer()
    {
        bool playerWon = 
        (
            kubisInventory.amount >= yieldsTotal_Array[0] && 
            tomatInventory.amount >= yieldsTotal_Array[1] && 
            timunInventory.amount >= yieldsTotal_Array[2] && 
            strawberiInventory.amount >= yieldsTotal_Array[3]
        );

        if (!playerWon)
        {
            gameManager.GameOver();
            return;
        }

        int sellAmount = 0;

        sellAmount += kubisInventory.amount * kubisInventory.price;
        sellAmount += tomatInventory.amount * tomatInventory.price;
        sellAmount += timunInventory.amount * timunInventory.price;
        sellAmount += strawberiInventory.amount * strawberiInventory.price;

        kubisInventory.amount = 0;
        tomatInventory.amount = 0;
        timunInventory.amount = 0;
        strawberiInventory.amount = 0;

        inventorySystem.coins += sellAmount + 500;

        for (int i = 0; i < duelYieldCounters.Length; i++)
        {
            duelYieldCounters[i].text = $"??? :";
            playerYieldCounters[i].text = $": ???";
        }
        DuelPanel.SetActive(false);
    }

    private IEnumerator CountYieldDuel()
    {
        float time = 0f;

        // Enemy
        int[] startValuesEnemy = new int[yieldsTotal_Array.Length]; // awal 0
        int[] targetValuesEnemy = yieldsTotal_Array;                // tujuan akhir

        // Player
        int[] startValuesPlayer = new int[4]; // awal 0
        int[] targetValuesPlayer =
        {
        inventorySystem.inventory[9].amount,
        inventorySystem.inventory[10].amount,
        inventorySystem.inventory[11].amount,
        inventorySystem.inventory[12].amount
    };

        while (time < durationCounterDuel)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / durationCounterDuel); // progress 0 → 1

            for (int i = 0; i < duelYieldCounters.Length; i++)
            {
                // Enemy counter
                int enemyValue = Mathf.RoundToInt(Mathf.Lerp(startValuesEnemy[i], targetValuesEnemy[i], t));
                duelYieldCounters[i].text = $"{enemyValue} :";

                // Player counter
                int playerValue = Mathf.RoundToInt(Mathf.Lerp(startValuesPlayer[i], targetValuesPlayer[i], t));
                playerYieldCounters[i].text = $": {playerValue}";
            }

            yield return null;
        }

        // Pastikan nilai akhir benar
        for (int i = 0; i < duelYieldCounters.Length; i++)
        {
            duelYieldCounters[i].text = $"{targetValuesEnemy[i]} :";
            playerYieldCounters[i].text = $": {targetValuesPlayer[i]}";
        }

        yield return new WaitForSeconds(0.5f);

        DuelPlayer();
    }


    public void SaveEnemyData()
    {
        MainSaveSystem.SaveEnemyData(yieldsTotal_Array, enemyEncounter);
    }

    public void LoadEnemyData()
    {
        EnemyData enemyData = MainSaveSystem.LoadEnemyeData();
        if (enemyData.yieldsTotal_Array == null)
        {
            Debug.Log("null bang enemy data");
            return;
        }

        yieldsTotal_Array = enemyData.yieldsTotal_Array;
        enemyEncounter = enemyData.enemyEncounter;
    }
}

[System.Serializable]
public class EnemyStats
{
    public int[] kubisStats = new int[61];
    public int[] tomatStats = new int[61];
    public int[] timunStats = new int[61];
    public int[] strawberiStats = new int[61];
}

