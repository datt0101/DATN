using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    [SerializeField] private QuestProfile questProfile;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collision QuestObject");
            QuestManager.instance.CompleteQuest(questProfile.QuestID);
        }
    }



}


