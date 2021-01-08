using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject buttonPanel;
    public GameObject instructionPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        SceneManager.LoadScene("Gameplay");
    }

    public void ToggleInstructions()
    {
        Debug.Log("Toggle Instructions");
        buttonPanel.SetActive(!buttonPanel.activeSelf);
        instructionPanel.SetActive(!instructionPanel.activeSelf);
    }
}
