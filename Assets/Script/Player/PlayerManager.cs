using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Transform playerModel;
    public PlayerMovement playerMovement;
    //public Animator animator;
    public Rigidbody playerRigidbody;
    public CharacterController playerController;
    public MeshFilter playerMeshFilter;
    public PlayerProfile playerProfile;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Reset()
    {
        LoadChar();
    }

    protected virtual void LoadChar()
    {
        if (this.playerModel != null) return;
        this.playerModel = transform.Find("PlayerModel");
        this.playerMovement = transform.Find("PlayerMovement").GetComponent<PlayerMovement>();
        //this.playerRigidbody = transform.Find("PlayerMovement").GetComponent<Rigidbody>();
        //this.playerController = transform.Find("PlayerMovement").GetComponent<CharacterController>();
        this.playerRigidbody = GetComponent<Rigidbody>();
        this.playerController = GetComponent<CharacterController>();
        this.playerMeshFilter = this.playerModel.GetComponent<MeshFilter>();

        Debug.Log(transform.name + ": LoadChar", gameObject);

    }
}

    


