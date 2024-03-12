using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    [SerializeField] private List<QuestProfile> NpcQuestList;

    private bool isCollision = false;
    private void Update()
    {
        Debug.Log(isCollision);
        TakeQuest();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("touch NPC");
            isCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("dont touch NPC");
            isCollision = false;
        }
    }
    public void TakeQuest()
    {
        QuestManager.instance.AcceptQuest(NpcQuestList[0].QuestID);
    }
}


