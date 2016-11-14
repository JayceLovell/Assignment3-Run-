using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//refernce to the UI namespace
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
    private float _fillAmount;
    private bool _isLightOn;
    private int interval = 1;
    private float _nextTime = 0;

    // PUBLIC INSTANCE VARIABLES
    public AudioSource GamePlaySound;
    public AudioSource OutOfBattery;
    public Image BatteryBar;
    public Light Light;
    public bool IsGameOver
    {
        get
        {
            return this._isGameOver;
        }
        set
        {
            this._isGameOver = value;
            if(_isGameOver)
            {
                _isGamePause = true;
                GameOverLable.gameObject.SetActive(true);
                BackToMainMenu.gameObject.SetActive(true);
                GamePlaySound.Stop();
                OutOfBattery.Play();
            }
        }
    }
    public bool IsGamePause
    {
        get
        {
            return this._isGamePause;
        }
        set
        {
            this._isGamePause = value;
            if(_isGamePause)
            {
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }
    }
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
    public float FillAmount
    {
        get
        {
            return this._fillAmount;
        }
        set
        {
            this._fillAmount = value;
            if (_fillAmount <= 0f)
            {
                IsGameOver = true;
            }
        }
    }

    [Header("Menu")]
    public Text TimeLable;
    public Text MenuTitle;
    public Button BackToMainMenu;
    public Button Resume;
    [Header("GameOver")]
    public Text GameOverLable;

	// Use this for initialization
	void Start () {
        this.TimeValue = 0.0f;
        MenuTitle.gameObject.SetActive(false);
        BackToMainMenu.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
        GameOverLable.gameObject.SetActive(false);
        _isGamePause = false;
        _isLightOn = true;
        FillAmount = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_isGamePause)
        {
            this.TimeValue += Time.deltaTime; ;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _bringUpMenu();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (_isLightOn)
            {
                Light.intensity = 0;
                _isLightOn = false;
            }
            else
            {
                Light.intensity = 4;
            }
        }
        if(Time.time >= _nextTime)
        {
            if (_isLightOn && !_isGameOver)
            {
                FillAmount -= 0.05f;
            }

            _nextTime += interval;
        }
        UpdateBattery();
    }
    // Private METHODS*******************************
    private void _bringUpMenu()
    {
        _isGamePause = true;
        MenuTitle.gameObject.SetActive(true);
        BackToMainMenu.gameObject.SetActive(true);
        Resume.gameObject.SetActive(true);
        Cursor.visible = true;
    }
    private void UpdateBattery()
    {
        BatteryBar.fillAmount = _fillAmount;
    }
    // Public METHODS*******************************
    public void BackToMainScreen()
    {
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
    }
    public void BringDownMenu()
    {
        _isGamePause = false;
        MenuTitle.gameObject.SetActive(false);
        BackToMainMenu.gameObject.SetActive(false);
        Resume.gameObject.SetActive(false);
    }
}
