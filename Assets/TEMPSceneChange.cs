using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Trigger this on some condition
        String newScene = "FailScreen";
        SceneControl sc = GameObject.FindObjectOfType(typeof(SceneControl)) as SceneControl;
        sc.ChangeScene(newScene);
    }
}
