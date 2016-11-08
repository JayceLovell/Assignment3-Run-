using UnityEngine;
using System.Collections;

//refernce to teh UI namespace
using UnityEngine.UI;
/**
 * StudentID: 300833478
 * Date: 07/11/2016
 */ 
public class GameController : MonoBehaviour {
    // Private Instance Variables
    private float _time;
    private bool _isGameOver;

    // PUBLIC INSTANCE VARIABLES
    public AudioSource GamePlaySound;

    public float TimeValue
    {
        get
        {
            return this._time;
        }
        set
        {
            this._time = value;
                this.TimeLable.text = Mathf.Round(this._time).ToString();
        }
    }

    [Header("UI Objects")]
    public Text TimeLable;

	// Use this for initialization
	void Start () {
        this.TimeValue = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
            this.TimeValue += Time.deltaTime; ;
	}
}
