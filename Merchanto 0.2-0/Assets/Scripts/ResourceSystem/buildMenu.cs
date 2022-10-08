using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildMenu : MonoBehaviour
{
    public GameObject buildingMenu;
    public rawGenerator rawGen;

[Header("Buttons")]
    public Button farmButton;
    public Button foresterButton;
    public Button ironMineButton;

[Header("Prefabs")]
    public GameObject farmPrefab;
    public GameObject foresterPrefab;
    public GameObject ironMinePrefab;

    public bool buildingOpened;

    public void building()
    {
            buildingMenu.SetActive(true);
            buildingOpened = true;

            activateButtons();
    }

    public void activateButtons()
    {
        farmButton.onClick.AddListener(buildFarm);
    }

    public void buildFarm()
    {
        if(rawGen.state0Active)
        {
            rawGen.state0Active = false;
            rawGen.state1Active = true;
            Instantiate(farmPrefab, transform.position, transform.rotation);

            buildingMenu.SetActive(false);
            buildingOpened = false;
        }
    }

}
