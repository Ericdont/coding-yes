using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 6f;

    [SerializeField]
    private Rigidbody2D _rigidbody;


    public Vector2 MovementDirection;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        print($"{horizontal}, {vertical}");

        Vector3 currentPosition = transform.position;
        float speedModifier = Speed * Time.deltaTime;
        MovementDirection  = new Vector2 (horizontal, vertical);

    }
    private void FixedUpdate()
    {
        _rigidbody.position += MovementDirection * (Speed * Time.fixedDeltaTime);
    }
}
