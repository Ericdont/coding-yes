using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButFucked : MonoBehaviour
{
    
    
        public float SPEEED;

        [SerializeField]
        private Vector2 _direction;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private CircleCollider2D _collider;

        private void Start()
        {
            if (_rigidbody == false)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }
            if (_collider == false)
            {
                _collider = GetComponent<CircleCollider2D>();
            }

        _direction = Vector2.right;
        _rigidbody.AddForce(SPEEED * _direction);

        //   float x = Random.Range(-1, 1);
        //  float y = Random.Range(-0.5f, 0.5f);

        _direction = Vector2.right;
            _rigidbody.AddForce(SPEEED * _direction);
        }
        private void FixedUpdate()
        {
            _rigidbody.position += _direction * (SPEEED * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PADDEL"))
            {
                _direction = -_direction;
                Paddle paddle = collision.gameObject.GetComponent<Paddle>();
                float hitPosition = (transform.position.y - collision.transform.position.y) / paddle._collider.bounds.size.y;
                print(hitPosition);

                _direction.y = hitPosition;
                print(hitPosition);
            }

            else if (collision.gameObject.CompareTag("Enviroment"))
            {
                Wall wall = collision.gameObject.GetComponent<Wall>();
                if (wall.IsTopWall || wall.IsBottomWall)
                {
                    float hitPosition = (transform.position.x - collision.transform.position.x) / wall.Collider.bounds.size.x;

                    //_direction.y = hitPosition;
                    _direction = new Vector2(_direction.x, _direction.y * hitPosition).normalized;
                    print($"{wall.name}     {hitPosition}");
                }
            }
        }
   }
