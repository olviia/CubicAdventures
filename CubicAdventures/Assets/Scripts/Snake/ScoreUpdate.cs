using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
         GetComponent<TextMeshProUGUI>().text = SnakeLogic.GetScore().ToString();
    }
}
