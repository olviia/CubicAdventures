using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;
    public void Start() {
        SetPanelIndexActive(0);
    }

    public void PlayGame() {
        SceneManager.LoadScene("CubicSnake");
    }
    public void SetPanelIndexActive(int panelIndex) {
        for (int i = 0; i < panels.Length; i++)
            panels[i].SetActive(panelIndex == i);
    }
}
