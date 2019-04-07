using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
	title,
	about,
	pause,
	playing
}

public class GameManger : MonoBehaviour
{
	private GameState currentState;
	private GameObject pause;

	private Button playButton, aboutButton;

	public GameObject titleMenu;
	public GameObject aboutScreen;
	public GameObject pauseMenu;
	public GameObject lvlObjs;

	public static GameManger instance; 
	// Use this for initialization
	void Start () {
		
		//Singleton Make sure there's only one GM 
		if (instance  == null)
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
			//set starting state
			
			//Game Menu Objs
			//GameObject titleMenu = Instantiate((Resources.Load<GameObject>("Prefabs/TitleMenu")));
			currentState = GameState.title; 
			titleMenu.SetActive(true);
			//setting the buttons on the main menu
			//playButton = GameObject.Find("PlayButton").GetComponent<Button>();
			//aboutButton = GameObject.Find("AboutButton").GetComponent<Button>();
			

			lvlObjs.SetActive(false);
		}
		else
		{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		checkGameState();
	}

	void checkGameState()
	{
		switch (currentState)
		{
			case GameState.title:
				Time.timeScale = 0f;
				break;
			case GameState.about:
				aboutScreen.SetActive(true);
				break;
			case GameState.playing:
				Time.timeScale = 1.0f;
				lvlObjs.SetActive(true);
				
				//while PLAYING see if Space or ESC has been pressed to pause
				if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Escape))
				{
					currentState = GameState.pause;
				}
				break;
			case  GameState.pause:
				Time.timeScale = 0f;
				pauseMenu.SetActive(true);
				lvlObjs.SetActive(false);
				
				break;
		}
	}

	void TaskOnPlayClick()
	{
		//all title screen objects need to be destroyed OR turn it off?? 
		titleMenu.SetActive(false);
		currentState = GameState.playing;

		/*titleScreenObj = GameObject.FindGameObjectsWithTag("TitleScreen");

		for (var i = 0; i < titleScreenObj.Length; i++)
		{
			//Destroy(titleScreenObj[i]);
			//titleScreenObj[i].SetActive(false);
			
		} */	
	}

	public void hitPlayButton()
	{
		titleMenu.SetActive(false);
		aboutScreen.SetActive(false);
		pauseMenu.SetActive(false);
		currentState = GameState.playing;
	}

	public void hitAboutButton()
	{
		titleMenu.SetActive(false);
		currentState = GameState.about;
	}

	public void hitMenuButton()
	{
		titleMenu.SetActive(true);
		aboutScreen.SetActive(false);
		pauseMenu.SetActive(false);
		currentState = GameState.title;
	}
}
