using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopViewMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private InputActionReference moveControl;
    [SerializeField] private float speed = 1f;

    private float angle;
    private Vector3 keyDirection;
    private static string collidedObject;
    float moveX;
    float moveZ;

    private void OnEnable() {
        moveControl.action.Enable();
    }
    private void OnDisable() {
        moveControl.action.Disable(); 
    }


    // rewrite static and not staic
    void Update()
    {

        if (!SnakeLogic.IsGameFinished()) {
            Moving();
        }

    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        collidedObject = hit.collider.gameObject.name;
        SnakeLogic.CheckCollision(collidedObject);
        Debug.Log(collidedObject); 

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

}
