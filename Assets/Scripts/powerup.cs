using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col){
        Debug.Log(this.gameObject.name);
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag == "Player"){
            Debug.Log("this is a player");
            FindObjectOfType<AudioManager>().Play("GetPowerup");
            switch(this.gameObject.name){
                case "swordPowerup(Clone)":
                    Debug.Log("collected sword powerup");
                    col.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).GetChild(1).GetChild(0).GetComponent<sword>().startKnockBackUp();
                    break;
                case "lightningPowerup(Clone)":
                    Debug.Log("apply speed");
                    if(col.gameObject.name == "Player1"){
                        col.gameObject.GetComponent<Player1Controller>().startSpeedUp();
                    } else if(col.gameObject.name=="Player2"){
                        col.gameObject.GetComponent<Player2Controller>().startSpeedUp();
                    }
                    
                    break;
                case "blockPowerup(Clone)":
                    Debug.Log("collected block powerup");
                    if(col.gameObject.name == "Player1"){
                        Debug.Log("collected block player1");
                        col.gameObject.GetComponent<Player1Controller>().startBlockUp();
                    } else if(col.gameObject.name=="Player2"){
                        Debug.Log("collected block player2");
                        col.gameObject.GetComponent<Player2Controller>().startBlockUp();
                    }
                    break;
                default:
                    break;
            }
            FindObjectOfType<PowerupManager>().resetPowerupTime();
            Destroy(this.gameObject);
        }

        
        
        
    }
}
