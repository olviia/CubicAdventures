using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> mProUGUIs;
    public void setScores() {
        List<float> scores = ScoreList.getScoreList();
        for(int i = 0; i<scores.Count; i++) {
            mProUGUIs[i].text = (i+1) + ". " + scores[i];
        }
    }
}
