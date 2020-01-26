using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA;
    [SerializeField]
    private Transform _targetB;
    private float _speed = 1.0f;
    // Start is called before the first frame update
    private Transform _start;
    private Transform _destination;
    void Start()
    {
        _start = _targetA;
        _destination = _targetB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination.position, Time.deltaTime * _speed);
        if (transform.position == _destination.position)
        {
            Transform temp = _start;
            _start = _destination;
            _destination = temp;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    //Collision detection with player
    // take player parent = this game object
    // exit collision
    // check if the player exited
    // take the player parent = null


}
