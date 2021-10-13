using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Wall : MonoBehaviour
{
    public BoxCollider2D Collider;

    [SerializeField]
    private EventTrigger.TriggerEvent _goalEvent;
   


    public bool IsTopWall;
    public bool IsBottomWall;
    public bool IsRightWall;
    public bool IsLeftWall;


    private void Start()
    { 
        if (Collider == null)
        {
            Collider = GetComponent<BoxCollider2D>();
        }
    }

   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _goalEvent.Invoke(null);
        }
    }
}
