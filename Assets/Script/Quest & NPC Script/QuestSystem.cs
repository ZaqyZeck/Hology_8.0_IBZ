using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private GameManager gameManager;
    private InventorySystem inventory;
    public List<Quest> questList;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        inventory = FindAnyObjectByType<InventorySystem>();
    }

    public void createQuest(int yieldId, int yieldAmount, int deadline)
    {
        int id = questList.Count;
        Quest createdQuest = new Quest(id, yieldId, yieldAmount, deadline);
        questList.Add(createdQuest);
    }

    public List<Quest> getActiveQuest()
    {
        List<Quest> activeQuest = new List<Quest>();
        int currentDate = gameManager.day;
        foreach (Quest quest in questList)
        {
            int startDate = quest.startDate;
            int deadLine = quest.deadline;
            if (quest.isComplete) continue;
            if (currentDate >= startDate && currentDate <= deadLine)
            {
                activeQuest.Add(quest);
            }
        }

        return activeQuest;
    }

    public List<Quest> getFailedQuest()
    {
        List<Quest> failedQuest = new List<Quest>();
        int currentDate = gameManager.day;
        foreach (Quest quest in questList)
        {
            int startDate = quest.startDate;
            int deadLine = quest.deadline;
            if (quest.isComplete) continue;
            if (currentDate == deadLine)
            {
                failedQuest.Add(quest);
            }
        }

        return failedQuest;
    }

    public void completeQuest(int questId)
    {
        Quest targetQuest = GetQuestBy(questId);
        if (targetQuest.isComplete)
        {
            Debug.LogError($"quest dengan id {questId} sudah selesai");
            return;
        }
        InventoryObject inventoryObject = inventory.GetInventoryObjectBy(targetQuest.yieldId);
        if (inventoryObject == null || targetQuest == null)
        {
            Debug.LogError("Inventory Id tidak ditemukan");
            return;
        }
        if (inventoryObject.amount < targetQuest.yieldAmount)
        {
            Debug.LogError("jumlah tidak cukup");
            return;
        }
        inventoryObject.amount -= targetQuest.yieldAmount;
        targetQuest.isComplete = true;
    }

    public void autoComplete()
    {
        List<Quest> activeQuest = getActiveQuest();
        int currentDate = gameManager.day;
        foreach (Quest quest in activeQuest)
        {
            if(quest.deadline == currentDate)
            {
                completeQuest(quest.questId);
            }
        }
    }

    public void CekQuest()
    {
        List<Quest> failedQuest = getFailedQuest();
        //List<Quest> activeQuest = getActiveQuest();
        if (failedQuest.Count > 0)
        {
            gameManager.GameOver();
        }
    }

    public Quest GetQuestBy(int id)
    {
        foreach (Quest quest in questList)
        {
            if(quest.questId == id) return quest;
        }
        return null;
    }
}

[Serializable]
public class Quest
{
    public int questId;
    public int yieldId;
    public int yieldAmount;
    public int startDate;
    public int deadline;
    public bool isComplete;
    //public bool isActive;

    public Quest()
    {
    }

    public Quest(int questId, int yieldId, int yieldAmount, int deadline)
    {
        this.questId = questId;
        this.yieldId = yieldId;
        this.yieldAmount = yieldAmount;
        this.deadline = deadline;
    }
}
