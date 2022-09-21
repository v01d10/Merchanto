using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class workshopHandla : MonoBehaviour
{
    public GameObject buildingPoint;
    public GameObject workshopModel;
    public townfolkManager tManager;

    public workshopNew shopSO;
    public GameObject shopPanel;


[Header("Text")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI workerText;
    public TextMeshProUGUI workerMaxText;

[Header("Buttons")]
    public Button workerUpButt;
    public Button workerDownButt;

[Header("Booleans")]
    public bool shopPanelOn;
    public bool butt0Active;
    public bool butt1Active;
    public bool buutt2Active;

[Header("Type Buttons")]
    public Button butt0;
    public Button butt1;
    public Button butt2;

    

    void Start()
    {
        StartCoroutine("process");
    }

    void Update()
    {
        Timer();
        shopSO.StateMachine();

    }

    public void Timer()
    {
        if(shopSO.timerRunning)
        {
            shopSO.procTimer -= Time.deltaTime;
        }
    }

    IEnumerator process()
    {
        shopSO.checkResource();

        while(shopSO.active && shopSO.gotRes && shopSO.processing0)
        {
            print(name + "processing");
            shopSO.checkResource();

            shopSO.procTimer = shopSO.procTime;
            shopSO.timerRunning = true;
            
            print("going to wait");
            yield return shopSO.procWait;
            print("waited");
            
            shopSO.timerRunning = false;
            shopSO.input0.resAmount -= (shopSO.neededPer1Amount + (shopSO.buildingLvl/10));
            shopSO.output0.procAmount += (shopSO.receivedAount * (shopSO.workers/10));
        }

        while(shopSO.active && shopSO.processing1)
        {

            shopSO.procTimer = shopSO.procTime;
            shopSO.timerRunning = true;
            
            print("going to wait");
            yield return shopSO.procWait;
            print("waited");
            
            shopSO.timerRunning = false;
            shopSO.input1.resAmount -= (shopSO.neededPer1Amount + (shopSO.buildingLvl/10));
            shopSO.output1.procAmount += (shopSO.receivedAount * (shopSO.receivedAount * shopSO.workers/10));
        }
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("Clicked");
            onShopPanelClick();
        }
    }

    public void onShopPanelClick()
    {
        if(!shopPanelOn)
        {
            shopPanel.SetActive(true);
            shopPanelOn = true;

            workerUpButt.onClick.AddListener(addWorker);
            workerDownButt.onClick.AddListener(removeWorker);

            updateText();
        }
        else
        {
            shopPanel.SetActive(false);
            shopPanelOn = false;
        }
    }



    public void addWorker()
    {
        if(tManager.townfolks >= 1 && shopSO.workers < shopSO.maxWorkers)
        {
            tManager.townfolks -= 1;
            shopSO.workers += 1;

            workerText.text = shopSO.workers.ToString();
            workerMaxText.text = shopSO.maxWorkers.ToString();
        }
    }
    
    public void removeWorker()
    {
        if(shopSO.workers >= 1)
        {
            tManager.townfolks += 1;
            shopSO.workers -= 1;

            workerText.text = shopSO.workers.ToString();
            workerMaxText.text = shopSO.maxWorkers.ToString();
        }
    }

    public void updateText()
    {
        nameText.text = name;
        workerText.text = shopSO.workers.ToString();
        workerMaxText.text = shopSO.maxWorkers.ToString();

 
    }

}
