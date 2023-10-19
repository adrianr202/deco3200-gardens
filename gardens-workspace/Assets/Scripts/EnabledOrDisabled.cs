using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledOrDisabled : MonoBehaviour
{
    public GameObject trigger;

    public void Trigger(){
        if(trigger.activeInHierarchy == false){
            trigger.SetActive(true);
        } 
        else
        {
            trigger.SetActive(false);
        }
    }
}
