using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeLogic : MonoBehaviour
{

    [SerializeField] private GameObject element;
    [SerializeField] private GameObject finishPopUp;
    [SerializeField] private TextMeshProUGUI scoreText;


    public static bool noElements;
    public static bool isGameFinished;
    private void Start() {
     noElements = true;
    isGameFinished = false;
}


    // Update is called once per frame
    void Update()
    {
        if (!isGameFinished) {
            if (noElements) {
                generateElement();
            }
        } else if (!finishPopUp.activeSelf) {
            finishPopUp.SetActive(true);
            float score = TopViewMovement.GetScore();
            scoreText.text += "\n" + score;
            ScoreList.ScoreUpdate(score);
        }
    }

    public void generateElement() {
        Vector3[] field = CubicSnakeSceneSetUp.getFieldInUnits();

        float x = Random.Range(field[0].x, field[1].x);
        float z = Random.Range(field[2].z, field[1].z);

        if (!(Physics.CheckSphere(new Vector3(x, 0.8f, z), 0.6f))) {
            Instantiate(element, new Vector3(x, 0f, z), Quaternion.identity);
            noElements = false;
        } else {
            generateElement();
        }
    }


}
