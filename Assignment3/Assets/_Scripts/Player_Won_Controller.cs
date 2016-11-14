using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Player_Won_Controller : MonoBehaviour {

    //Public
    public Transform PlayerDirection;
    public Text GameWon;

	// Use this for initialization
	void Start () {
        GameWon.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // need a variable to hold the location of our Raycast look
        RaycastHit hit;

        //if raycast hits an object then do somthing....
        if(Physics.Raycast (this.PlayerDirection.position, this.PlayerDirection.forward, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Car"))
            {
                GameWon.gameObject.SetActive(true);
            }
        }
        if (input.GetButtonDown("Fire1"))
        {
            //need a variable to hold the location of our Raycast Hit
            RaycastHit hit;

            // if raycast hits an object then do somthing....
            if(Physics.Raycast (this.PlayerDirection.position,this.PlayerDirection.forward, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Car"))
                {
                    SceneManager.LoadScene("GameWon");
                }
            }
        }
	}
}
