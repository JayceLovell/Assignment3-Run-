using UnityEngine;
using System.Collections;

public class Clock_Controller : MonoBehaviour {

    private GameObject _gameControllerObject;
    public GameController _gameController;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //private methods
    private void OnTriggerEnter(Collider other)
    {
        _gameController.TimeValue -= Random.Range(1, 5);
        Destroy(gameObject);
    }
}
