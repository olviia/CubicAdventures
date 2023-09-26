using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class TopViewMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private InputActionReference moveControl;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance;

    private float angle;
    private Vector3 keyDirection; 
    private static int score;
    float moveX;
    float moveZ;

    private void OnEnable() {
        moveControl.action.Enable();
    }
    private void OnDisable() {
        moveControl.action.Disable(); 
    }


    void Update()
    {

        if (!SnakeLogic.isGameFinished) {
            Moving();
        }

    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        GameObject collidedObject = hit.collider.gameObject;
        CheckCollision(collidedObject, gameObject);
    }
    private void OnCollisionEnter(Collision collision) {
        //define collision
/*        if (collision != null && collision.contact.name.Contains("Body")) {
            SnakeLogic.isGameFinished = true;
        }*/
    }
    private void CheckCollision(GameObject collidedObject, GameObject player) {

        if (collidedObject != null && collidedObject.name.Contains("Wall")) {
            SnakeLogic.isGameFinished = true;
        } else if (collidedObject != null && collidedObject.name.Contains("Cube")) {
            onElementCollide(collidedObject, player);
        }
    }

    private void onElementCollide(GameObject collidedObject, GameObject player) {


        collidedObject.transform.parent.position = -player.transform.forward * distance + player.transform.position;
        collidedObject.transform.parent.rotation = player.transform.rotation;
        collidedObject.name = "Body";

        BodyPart.UpdateBodyPartList(collidedObject);

        SnakeLogic.noElements = true;
        SnakeLogic.isGameFinished = false;
        UpdateScore();

    }

    private void Moving() {
        Vector2 movement = moveControl.action.ReadValue<Vector2>();
        if (movement.x != 0) {
            moveX = movement.x;
            moveZ = 0f;
            angle = Mathf.Atan2(keyDirection.x, keyDirection.z) * Mathf.Rad2Deg;
        } else if (movement.y != 0) {
            moveX = 0f;
            moveZ = movement.y;
            angle = Mathf.Atan2(keyDirection.y, keyDirection.z) * Mathf.Rad2Deg;
        }
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
