using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public enum MovementType
    {
        LeftToRight,
        UpAndDown
    }

    public MovementType movementType = MovementType.LeftToRight;
    public float speed = 5f;
    public float distance = 5f;

    private Vector3 initialPosition;
    private bool movingRight = true;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (movementType == MovementType.LeftToRight)
        {
            MoveLeftToRight();
        }
        else if (movementType == MovementType.UpAndDown)
        {
            MoveUpAndDown();
        }
    }

    void MoveLeftToRight()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Vector3.Distance(initialPosition, transform.position) >= distance)
        {
            movingRight = !movingRight;
        }
    }

    void MoveUpAndDown()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (Vector3.Distance(initialPosition, transform.position) >= distance)
        {
            movingUp = !movingUp;
        }
    }
}
