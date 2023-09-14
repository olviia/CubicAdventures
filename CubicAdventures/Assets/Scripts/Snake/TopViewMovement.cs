using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopViewMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private InputActionReference moveControl;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float pause = 1f;

    private float angle;

    private void OnEnable() {
        moveControl.action.Enable();
    }
    private void OnDisable() {
        moveControl.action.Disable(); 
    }

    void Update()
    {

        Vector3 keyDirection = new Vector3(0f,0f,0f);

        Vector2 movement = moveControl.action.ReadValue<Vector2>();
        if (movement.x != 0) 
        {
            keyDirection = new Vector3(movement.x, 0f, 0f);
            angle = Mathf.Atan2(keyDirection.x, keyDirection.z) * Mathf.Rad2Deg;
        }
        else if (movement.y != 0) 
        {
            keyDirection = new Vector3(0f, 0f, movement.y);
            angle = Mathf.Atan2(keyDirection.y, keyDirection.z) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        controller.Move(keyDirection * speed * Time.deltaTime);

    }
}
