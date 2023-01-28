using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int targetFrameRate = 60;
 
     private void Awake()
     {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = targetFrameRate;

         SceneControl sc = GameObject.FindObjectOfType(typeof(SceneControl)) as SceneControl;
         sc.ChangeScene("MainMenu");
     }
}
