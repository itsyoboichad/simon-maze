using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text currentLevelText;
    public Text highestLevelText;

    int highestLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        //currentLevel = GetComponent<Text>();
        //highestLevel = GetComponent<Text>();
        currentLevelText.text = "1";
        highestLevelText.text = highestLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateLevel(int level)
    {
        if (level > highestLevel)
        {
            highestLevel = level;
            highestLevelText.text = highestLevel.ToString();
        }
        currentLevelText.text = level.ToString();
    }
}
