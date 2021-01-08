using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    public Material redLight;
    public Material greenLight;
    public Material blueLight;
    public Material yellowLight;
    public Canvas canvas;

    UIController uiController;
    Material fire;
    int[] path;
    int[] playerPath;
    int levelCount;
    LevelMaintenance levelMaintenance;
    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        //path = new int[3];
        //path[0] = Random.Range(1, 5);
        //path[1] = Random.Range(1, 5);
        //path[2] = Random.Range(1, 5);
        //levelCount = 3;
        //playerPath = new int[3];
        levelMaintenance = new LevelMaintenance();
        uiController = canvas.GetComponent<UIController>();
        levelMaintenance.initializeGame(this.gameObject, uiController);
        //Rest of this code isn't running
        render = GetComponent<Renderer>();
        fire = render.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerPassed(int doorColor)
    {
        levelMaintenance.playerPassed(doorColor);
    }

    public void failed(int[] path)
    {
        StartCoroutine(failedAnimation(path));
    }

    public IEnumerator failedAnimation(int[] path)
    {
        Debug.Log("failed animation playing");
        render.material = redLight;
        yield return new WaitForSeconds(3);
        render.material = fire;
        StartCoroutine(playNewPath(path));
        //yield return null;
    }

    public void newPath(int[] path)
    {
        StartCoroutine(playNewPath(path));
    }

    public IEnumerator playNewPath(int[] path)
    {
        Debug.Log("New path playing");
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] == LevelMaintenance.GREEN)
            {
                render.material = greenLight;
                yield return new WaitForSeconds(1);
                render.material = fire;
                yield return new WaitForSeconds(1);
            }
            else if (path[i] == LevelMaintenance.RED)
            {
                render.material = redLight;
                yield return new WaitForSeconds(1);
                render.material = fire;
                yield return new WaitForSeconds(1);
            }
            else if (path[i] == LevelMaintenance.BLUE)
            {
                render.material = blueLight;
                yield return new WaitForSeconds(1);
                render.material = fire;
                yield return new WaitForSeconds(1);
            }
            else if (path[i] == LevelMaintenance.YELLOW)
            {
                render.material = yellowLight;
                yield return new WaitForSeconds(1);
                render.material = fire;
                yield return new WaitForSeconds(1);
            }
        }
    }
}
