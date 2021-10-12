using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    public float SPEEED;

    [SerializeField]
    private Vector2 _direction;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private CircleCollider2D _collider;

    [SerializeField]
    private EventTrigger.TriggerEvent trigger;

    private Vector3 OriginalPosition;
    private void Start()
    {

        OriginalPosition = transform.position;

        if (_rigidbody == false)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        if (_collider == false)
        {
            _collider = GetComponent<CircleCollider2D>();
        }

        float x = Random.Range(-1, 1);
        float y = Random.Range(-0.5f, 0.5f);

        _direction = Vector2.right;
        _rigidbody.AddForce(SPEEED * _direction);
    }
    public void ResetBall()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            _rigidbody.velocity = new Vector2(5, -5);
            transform.position = OriginalPosition;
            _rigidbody.velocity = new Vector2(5, 5);


        }
    }
}


     