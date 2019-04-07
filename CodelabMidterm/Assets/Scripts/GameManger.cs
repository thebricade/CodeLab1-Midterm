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
			playButton = GameObject.Find("PlayButton").GetComponent<Button>();
			playButton.onClick.AddListener(TaskOnPlayClick);
			aboutButton = GameObject.Find("AboutButton").GetComponent<Button>();
			aboutButton.onClick.AddListener(TaskOnAboutClick);
			

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
				playButton = GameObject.Find("PlayButton").GetComponent<Button>();

				break;
			case GameState.playing:
				Time.timeScale = 1.0f;
				lvlObjs.SetActive(true);
				break;
			case  GameState.pause:
				Time.timeScale = 0f;
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

	void TaskOnAboutClick()
	{
		titleMenu.SetActive(false);
		currentState = GameState.about;
		

	}

	public void hitPlayButton()
	{
		currentState = GameState.playing;
	}
}
