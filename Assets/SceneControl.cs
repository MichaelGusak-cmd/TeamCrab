using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
	public string defaultScene = "MainMenu";
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

	public void ChangeScene(string name)
	{
		SceneManager.LoadScene(name);
	}
}