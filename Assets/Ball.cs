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
    private Vector2 _previousDirection;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private CircleCollider2D _collider;

    [SerializeField]
    private EventTrigger.TriggerEvent trigger;

    

    private Vector3 OriginalPosition;

    public void ResetPosition()
    {
        _previousDirection = _direction;


    }

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

    public void AddForceInRandomDirection()
    {
        float x = Random.Range(-1, 1);
        float y = Random.Range(-0.5f, 0.5f);

        _direction = Vector2.right;
        _rigidbody.AddForce(SPEEED * _direction);
    }
}
   // public void AddForce()
//    {
   //     int x = Random.Range(-1, 1);
     //   if (x == 0)
       // {
     //       x = 1;
       // }

//        float y = Random.Range(-0.5f 0.5);

  //      if(x == _previousDirection.x)
    //    {
        //    x = -x;
      //  }

 //       _direction = new Vector2(x, y);
  //      _rigidbody.AddForce(_direction * SPEEED);
   // }
// }


     