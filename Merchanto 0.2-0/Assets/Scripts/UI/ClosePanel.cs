using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public void CloseTab()
    {
        this.gameObject.SetActive(false);
    }
}
