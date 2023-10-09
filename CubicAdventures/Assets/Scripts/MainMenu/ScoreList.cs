using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreList : MonoBehaviour {
    private static List<float> scoreList = new List<float> {0,0,0,0,0,0,0,0 };
    public static void ScoreUpdate(float score) {
        //if (scoreList.Count == 0) InitializeList();

        if (score > scoreList[scoreList.Count - 1]) {
            scoreList[scoreList.Count - 1] = score;
        }
        scoreList.Sort();
        scoreList.Reverse();

        SaveScore();
    }
    public static List<float> getScoreList() {
        TakeListFromSaved();
        return scoreList;
    }
     private static void TakeListFromSaved() {
        scoreList.Clear();
         for (int i = 0; i < 8; i++) {
            if(PlayerPrefs.HasKey(i+" score"))
             scoreList.Add(PlayerPrefs.GetFloat(i + " score"));
         }
     }
     
    private static void SaveScore() {
        for (int i = 0; i < scoreList.Count; i++) {
            PlayerPrefs.SetFloat(i + " score", scoreList[i]);
        }
    }
    
}
