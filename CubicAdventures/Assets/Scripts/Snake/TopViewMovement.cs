using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class TopViewMovement : MonoBehaviour {
    [SerializeField] private CharacterController controller;
    [SerializeField] private InputActionReference moveControl;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance;

    private float angle;
    private Vector3 keyDirection;
    private static int score;
    private bool hasReachedDestination;
    public static bool isGamePaused;
    float moveX;
    float moveZ;

    private void OnEnable() {
        moveControl.action.Enable();
    }
    private void OnDisable() {
        moveControl.action.Disable();
    }
    private void Start() {
           hasReachedDestination = true;
            isGamePaused = false;
            angle = 90;
            keyDirection = new Vector3(0f,0f,0f);
             score = 0;
             moveX =0;
             moveZ = 0;
        BodyPart.bodyPosList.Clear();
        BodyPart.bodyPartList.Clear();
}

    void Update() {

        if (!SnakeLogic.isGameFinished && !isGamePaused) {
            if(hasReachedDestination) GetPreviousPosition();
            Moving();
            BodyMoving();
            Debug.Log(hasReachedDestination);
            Debug.Log("parts " + BodyPart.bodyPartList.Count);
            Debug.Log("pos " + BodyPart.bodyPosList.Count);
        }
    }

    private void GetPreviousPosition() {
        if (BodyPart.bodyPartList.Count == 0) return;

        BodyPart.ClearPositions();
        BodyPart.AddPosition(transform.position, transform.rotation);
        for(int i = 0; i<BodyPart.bodyPartList.Count; i++) {
            BodyPart.AddPosition(BodyPart.GetPosition(i));
        }
        hasReachedDestination = false;
    }
    private void BodyMoving() {
        if (BodyPart.bodyPartList.Count == 0) return;

        for (int i = 0; i < BodyPart.bodyPartList.Count; i++) {

            BodyPart.bodyPartList[i].transform.position =  Vector3.MoveTowards(BodyPart.bodyPartList[i].transform.position, 
                                                           new Vector3(BodyPart.bodyPosList[i].position.x, 0f, BodyPart.bodyPosList[i].position.z),
                                                           Time.deltaTime * speed);
            BodyPart.bodyPartList[i].transform.rotation = BodyPart.bodyPosList[i].rotation;
            
        }
        if (BodyPart.bodyPartList[0].transform.position.x - BodyPart.bodyPosList[0].position.x <=  distance
            && BodyPart.bodyPartList[0].transform.position.z - BodyPart.bodyPosList[0].position.z <= distance) hasReachedDestination  = true;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        GameObject collidedObject = hit.collider.gameObject;
        CheckCollision(collidedObject, gameObject);

    }
   
    private void CheckCollision(GameObject collidedObject, GameObject player) {
        if (collidedObject == null) return;

        if (collidedObject.name.Contains("Wall")) {
            SnakeLogic.isGameFinished = true;
        } else if (collidedObject.name.Contains("Cube")) {
            hasReachedDestination = true;
            onElementCollide(collidedObject, player);
        } 
    }

    private void onElementCollide(GameObject collidedObject, GameObject player) {

        if (!collidedObject.name.Equals("Body")) {

            if (BodyPart.bodyPartList.Count == 0) {
                collidedObject.transform.parent.position = -player.transform.forward * distance + player.transform.position;
            } else if (BodyPart.bodyPartList.Count >=1) {
                collidedObject.transform.parent.position = -BodyPart.bodyPartList[BodyPart.bodyPartList.Count-1].transform.forward 
                                            * distance + BodyPart.bodyPartList[BodyPart.bodyPartList.Count - 1].transform.position;
            }
            collidedObject.transform.parent.rotation = player.transform.rotation;
            collidedObject.name = "Body";

            BodyPart.UpdateBodyPartList(collidedObject);
            GetPreviousPosition();

            SnakeLogic.noElements = true;
            UpdateScore();
        }
    }

    private void Moving() {
        Vector2 movement = moveControl.action.ReadValue<Vector2>();
        float previousAngle = angle;

        if (movement.x != 0) {
            moveX = movement.x;
            moveZ = 0f;
            angle = Mathf.Atan2(keyDirection.x, keyDirection.z) * Mathf.Rad2Deg;
        } else if (movement.y != 0) {
            moveX = 0f;
            moveZ = movement.y;
            angle = Mathf.Atan2(keyDirection.y, keyDirection.z) * Mathf.Rad2Deg;
        }

        //if (Mathf.Abs(previousAngle - angle) >90) return;
        float yAxisDifferese = GetComponent<Transform>().position.y;

        keyDirection = new Vector3(moveX, 0f, moveZ);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        controller.SimpleMove(keyDirection * speed);
        
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


}
