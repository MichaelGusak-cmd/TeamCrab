using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    private int scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateScore() {
        scoreNumber++;
        _scoreText.text = "Score: " + scoreNumber;
    }

}
