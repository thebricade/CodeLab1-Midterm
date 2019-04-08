using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
	title,
	about,
	pause,
	playing, 
	ending
}

public enum Level //not using 
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
	public GameObject[] lvlObjs;

	public static GameManger instance = null; 
	
	//set up timer
	public float timeLeft;
	public Text displayTimer;

	private int levelNum= 0;
	
	
	// Use this for initialization
	private void Awake()
	{
			
		//Singleton Make sure there's only one GM 

		if (instance  == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			//set starting state
		
			//currentState = GameState.title; 
			//titleMenu.SetActive(true);
			//lvlObjs.SetActive(false);
		}
		else
		{
			Destroy(this);
		}
	}

	void Start () {
		
		timeLeft = 15;
		currentState = GameState.title;
		lvlObjs[levelNum].SetActive(false);
	
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
				if (timeLeft < 0)
				{
					
					Debug.Log(levelNum);
					if (levelNum < 2)
					{
						SceneManager.LoadScene(levelNum+1);
						//lvlObjs[levelNum].SetActive(true);
						
					}else if (levelNum == 3)
					{
						currentState = GameState.ending;
					}
					changeLevel();
				}
				
				
				

				//while PLAYING see if Space or ESC has been pressed to pause
				if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Escape))
				{
					currentState = GameState.pause;
				}
				
				//running the timer
				timeLeft -= Time.deltaTime;
				displayTimer.text = timeLeft.ToString();
				
				
				
				break;
			case  GameState.pause:
				Time.timeScale = 0f;
				pauseMenu.SetActive(true);
				lvlObjs[levelNum].SetActive(false);
				
				break;
			case GameState.ending:
				displayTimer.text = "How well did you do?"; 
				break;
		}
	}

	void changeLevel()
	{
		if (levelNum < 3)
		{
			levelNum = levelNum + 1;
		}

		switch (levelNum)
		{
			case 1:
				//level 2
				timeLeft = 20f;
				lvlObjs[0].SetActive(false);
				
				break;
			case 2:
				//level 3
				timeLeft = 30f;
				lvlObjs[0].SetActive(false);
				lvlObjs[1].SetActive(false);
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
