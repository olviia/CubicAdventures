using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeLogic : MonoBehaviour
{

    [SerializeField] private GameObject element;

    private static int score;
    private void Start() {
    }

    private static bool noElements = true;
    private static bool isGameFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (!isGameFinished) {
            if (noElements) {
                generateElement();
            }
        } else {
            FinishGame();
        }
    }

    private void FinishGame() {
        //open finish game popup
    }

    public static void CheckCollision(string collidedObject) {

        if (collidedObject != null && collidedObject.Contains("Wall")) {
            EndGame();
        } else if (collidedObject != null && collidedObject.Contains("Cube")) {
            onElementCollide();
        }
    }


    private static void EndGame() {
        isGameFinished = true;
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
    private static void onElementCollide() {
        noElements = true;
        UpdateScore();

    }
    public static int GetScore() { 
        return score;
    }    
    public static void SetScore(int a) {
        score = a;
    }
    public static void UpdateScore() {
        score++;
    }
    public static bool IsGameFinished() {
        return isGameFinished;
    }


}
