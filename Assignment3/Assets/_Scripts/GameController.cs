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
    private bool _isGamePause;

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
    public Text MenuTitle;
    public Button BackToMainMenu;
    public Button Resume;

	// Use this for initialization
	void Start () {
        this.TimeValue = 0.0f;
        MenuTitle.gameObject.SetActive(false);
        BackToMainMenu.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
        _isGamePause = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_isGamePause)
        {
            this.TimeValue += Time.deltaTime; ;
        }
    }
    // Private METHODS*******************************
    private void _bringUpMenu()
    {
        _isGamePause = true;
        MenuTitle.gameObject.SetActive(true);
        BackToMainMenu.gameObject.SetActive(true);
        Resume.gameObject.SetActive(true);
    }
    // Public METHODS*******************************
    public void BackToMainScreen()
    {

    }
    public void BringDownMenu()
    {
        _isGamePause = false;
        MenuTitle.gameObject.SetActive(false);
        BackToMainMenu.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
    }
}
