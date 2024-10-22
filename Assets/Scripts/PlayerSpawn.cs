﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawn : NetworkBehaviour
{   
    [SerializeField]
    GameObject playerprefab;

    Vector3 spawnPosition;
    Quaternion spawnRotation;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }

    public void Awake()
    {
        spawnPosition = new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
        spawnRotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 180.0f), 0);
       
    }


    public void Spawn(string address)
    {
        Cmdspawns(address);
    }

    [Command]
    void Cmdspawns(string address)
    {
        GameObject player = (GameObject)Instantiate(playerprefab, spawnPosition, spawnRotation);
        GameObject owner = this.gameObject;
        NetworkServer.SpawnWithClientAuthority(player, owner);
        player.name = address;
    }
}
