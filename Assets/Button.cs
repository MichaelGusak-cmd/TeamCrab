using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void MyOnClick(string newScene) {
         SceneControl sc = GameObject.FindObjectOfType(typeof(SceneControl)) as SceneControl;
         sc.ChangeScene(newScene);
    }
}
