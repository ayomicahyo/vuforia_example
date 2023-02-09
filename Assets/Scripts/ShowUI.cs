using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject UI;

    public void ShowTheUI()
    {
        UI.SetActive(true);
    }

    public void HideTheUI()
    {
        UI.SetActive(false);
    }
}
