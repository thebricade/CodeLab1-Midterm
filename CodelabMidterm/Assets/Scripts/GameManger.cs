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

public enum Level
{
	level1,
	level2,
	level3
}

public class GameManger : MonoBehaviour
{
	private GameState currentState;
	private Level currentLevel;
	
	public GameObject titleMenu;
	public GameObject aboutScreen;
	public GameObject pauseMenu;
	public GameObject lvlObjs;

	public static GameManger instance; 
	
	//set up timer
	public float timeLeft;
	public Text displayTimer; 
	
	// Use this for initialization
	void Start () {
		
		//timeLeft = 30f;
		
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
				//running the timer
				timeLeft -= Time.deltaTime;
				displayTimer.text = timeLeft.ToString();
				if (timeLeft <= 0)
				{
					changeLevel();
				}
				
				break;
			case  GameState.pause:
				Time.timeScale = 0f;
				pauseMenu.SetActive(true);
				lvlObjs.SetActive(false);
				
				break;
		}
	}

	void changeLevel()
	{
		switch (currentLevel)
		{
			case Level.level1:
				timeLeft = 10; 
				break;
			case Level.level2:
				timeLeft = 60f;
				break;
			case Level.level3:
				timeLeft = 40f; 
				break;
							
		}
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
