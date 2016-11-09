using UnityEngine;
using System.Collections;

public class Clock_Controller : MonoBehaviour {

    private GameObject _gameControllerObject;
    public GameController _gameController;
    private bool _goingup;
    private float _speed;
    private Transform _transform;

    // PUBLIC PROPERTIES+++++++++++++++++++++++++++++++++
    public float Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }



    // Use this for initialization
    void Start () {
        _goingup = true;
        this._transform = this.GetComponent<Transform>();
        this._speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        _slowMovement();
    }
    //private methods
    private void _slowMovement()
    {
        Vector3 newPosition = this._transform.position;

        if (this._transform.position.y > 3.1f)
        {
            _goingup = false;
        }
        else if (this._transform.position.y < 1.43f)
        {
            _goingup = true;
        }

        if (_goingup)
        {
            newPosition.y += this._speed;
            this._transform.position = newPosition;
        }
        else
        {
            newPosition.y -= this._speed;
            this._transform.position = newPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _gameController.TimeValue -= Random.Range(1, 5);
        Destroy(gameObject);
    }
}
