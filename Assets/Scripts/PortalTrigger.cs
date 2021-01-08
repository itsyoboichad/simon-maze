using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public bool activeTrigger = true;
    public enum PortalColor
    {
        Red,
        Blue,
        Green,
        Yellow,
    };
    public PortalColor portalColor;
    public GameObject indicatorLight;
    IndicatorController indicatorController;

    // Start is called before the first frame update
    void Start()
    {
        indicatorController = indicatorLight.GetComponent<IndicatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activeTrigger)
        {
            Vector3 currentPosition = other.transform.position;
            Vector3 newPosition = Vector3.zero;
            CharacterController otherController = other.gameObject.GetComponent<CharacterController>();
            if (portalColor == PortalColor.Green)
            {
                newPosition = currentPosition + Vector3.right * 25;
                indicatorController.playerPassed(LevelMaintenance.GREEN);
            }
            else if (portalColor == PortalColor.Blue)
            {
                newPosition = currentPosition + Vector3.left * 25;
                indicatorController.playerPassed(LevelMaintenance.BLUE);
            }
            else if (portalColor == PortalColor.Red)
            {
                newPosition = currentPosition + Vector3.back * 25;
                indicatorController.playerPassed(LevelMaintenance.RED);
            }
            else if (portalColor == PortalColor.Yellow)
            {
                newPosition = currentPosition + Vector3.forward * 25;
                indicatorController.playerPassed(LevelMaintenance.YELLOW);
            }
            //Debug.Log("Ran through " + portalColor + ". Old position: " + currentPosition + ", new position: " + newPosition);
            otherController.enabled = false;
            other.transform.position = newPosition;
            otherController.enabled = true;
        }
    }
}
