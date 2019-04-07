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
	private GameObject[] titleScreenObj;
	private GameObject[] aboutScreenObj;

	private Button playButton;

	private GameObject titleMenu;

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
			titleMenu = GameObject.Find("TitleMenu"); 
			titleMenu.SetActive(true);
			playButton = GameObject.Find("PlayButton").GetComponent<Button>();
			playButton.onClick.AddListener(TaskOnPlayClick);
			currentState = GameState.title;
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
				break;
			case GameState.playing:
				break;
			case  GameState.pause:
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
}
