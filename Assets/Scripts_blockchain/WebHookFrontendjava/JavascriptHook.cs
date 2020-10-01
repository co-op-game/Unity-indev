using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Webhook between game and html interface for web3 - connect to wallet. 
public class JavascriptHook : NetworkBehaviour
{
    public PlayerSpawn playerspawn;
    bool spawned;

    public Text AddressOutput;


    string address;
    void Start()
    {
        spawned = false;
        address = "account_not_linked:bug if live player(exemption server/debugspawn";
    }

    public void WebHookSpawn(string recievedaddress)
    {
        if (this.isLocalPlayer)
        {
            if (spawned == !true)
            {
                address = recievedaddress;
                Debug.Log("Connected:");
                Debug.Log(recievedaddress);
                AddressOutput.text = address;
                playerspawn.Spawn(address);
                spawned = true;
            }
        }
    }


        //below for debugging only. 
        void Update()
    {
            if (this.isLocalPlayer)
            {
                if (spawned == !true)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        playerspawn.Spawn(address);
                        spawned = true;
                    }
                }
            }  

    }
}   
