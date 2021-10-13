using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Paddle : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        public float verticaldirection;
        public float Speed = 10;
        public BoxCollider2D _collider;
    private Vector2 _InitialPosition;

    private void Start()
        {
            if (_rigidbody == false)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
            
            if (_collider == false)
            {
                _collider = GetComponent<BoxCollider2D>();
            }

        _InitialPosition = transform.position;
        }
        private void Update()
        {
            verticaldirection = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            _rigidbody.position += new Vector2(0, verticaldirection) * (Speed * Time.fixedDeltaTime);
            
        }
    public void ResetPosition()
    {
        _rigidbody.position = _InitialPosition;
    }
    }

