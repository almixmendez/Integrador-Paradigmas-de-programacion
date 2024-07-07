using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLoose : MonoBehaviour
{
    [Header("MANAGER")]
    // Victoria y derrota.
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject loosePanel;

    void Start()
    {
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("FinalBoss") == null)
        {
            ShowVictoryPanel();
        }
        else if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            ShowDefeatPanel();
        }
    }

    public void ShowVictoryPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowDefeatPanel()
    {
        loosePanel.SetActive(true);
    }
}
