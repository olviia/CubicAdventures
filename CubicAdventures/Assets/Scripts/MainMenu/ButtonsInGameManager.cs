using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;
    public void Start() {
        SetPanelIndexActive(0);
    }

    public void StopGame() {
        SceneManager.LoadScene("MainMenu");
    }
    public void ShowScores() { }
    public void SetPanelIndexActive(int panelIndex) {
        for (int i = 0; i < panels.Length; i++)
            panels[i].SetActive(panelIndex == i);
    }

    public void RestartGame() { 
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void PauseGame() { 
        TopViewMovement.isGamePaused = true;
    }
    public void ContinueGame(){
        TopViewMovement.isGamePaused=false;
    }
}
