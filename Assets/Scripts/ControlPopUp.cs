using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPopUp : MonoBehaviour
{
    public GameObject Panel;

    //On button click, activate text panel 
        public void openPanel(){
        if(Panel != null){
            Panel.SetActive(true);
        }
    }

}
