using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<QuestProfile> questList;
    public List<QuestProfile> currentQuestList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        UpdateQuestAccepted();
    }

    public void UpdateQuestAccepted()
    {
        int l = questList.Count;
        for (int i = 0; i < l; i++)
        {
            if (questList[i].QuestProgress == QuestProgress.Accepted)
            {
                currentQuestList.Add(questList[i]);
            }
        }
    }
    public void AcceptQuest(int questID)
    {
        int l = questList.Count;
        for (int i = 0; i < l; i++)
        {
            if (questList[i].QuestID == questID && questList[i].QuestProgress == QuestProgress.Available)
            {
                Debug.Log("AcceptQuest");
                currentQuestList.Add(questList[i]);
                questList[i].QuestProgress = QuestProgress.Accepted;
            }
        }
    }
    public void GiveUpQuest(int questID)
    {
        // bo nv ra khoi danh sach hien tai
        int l = currentQuestList.Count;
        for (int i = 0; i < l; i++)
        {
            if (currentQuestList[i].QuestID == questID && currentQuestList[i].QuestProgress == QuestProgress.Accepted)
            {
                Debug.Log("GiveUpQuest");
                currentQuestList[i].QuestProgress = QuestProgress.Available;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }

        // tra nv ve danh sach cac nv
        l = questList.Count;
        for (int i = 0; i < l; i++)
        {
            if (questList[i].QuestID == questID)
            {
                questList[i].QuestProgress = QuestProgress.Available;

            }
        }
    }

    public void CompleteQuest(int questID)
    {
        int l = currentQuestList.Count;
        for (int i = 0; i < l; i++)
        {
            if (currentQuestList[i].QuestID == questID && currentQuestList[i].QuestProgress == QuestProgress.Accepted)
            {
                Debug.Log("CompleteQuest");
                currentQuestList[i].QuestProgress = QuestProgress.Complete;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

}

