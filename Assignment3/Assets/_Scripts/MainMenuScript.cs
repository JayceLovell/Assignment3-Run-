using UnityEngine;
using System.Collections;
//refernce to teh UI namespace
using UnityEngine.UI;
/**
 * StudentID: 300833478
 * Date: 07/11/2016
 */
public class MainMenuScript : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public AudioSource MainMenuSound;

    [Header("UI Objects")]
    public Button StartButton;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // PUBLIC METHODS
    public void Start_Game()
    {
        MainMenuSound.Stop();
        Application.LoadLevel("Main");
    }
}
