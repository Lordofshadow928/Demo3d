using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByVJoystick : MonoBehaviour
{
    public CharacterController controller;
    public float movingSpeed = 10f;
    public Joystick joystick;

    private void CanMove()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float hInput = joystick.Horizontal;
        float vInput = joystick.Vertical;
        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        controller.SimpleMove(direction * movingSpeed);
    }
}
