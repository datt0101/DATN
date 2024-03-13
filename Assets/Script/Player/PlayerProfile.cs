using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfile : ScriptableObject
{
    [SerializeField] private int playerID; 
    [SerializeField] private string playerLevel; // Cap do cua nguoi choi
    [SerializeField] private string playerName;

    public int PlayerID { get => playerID; set => playerID = value; }
    public string PlayerLevel { get => playerLevel; set => playerLevel = value; }
    public string PlayerName { get => playerName; set => playerName = value; }

}

