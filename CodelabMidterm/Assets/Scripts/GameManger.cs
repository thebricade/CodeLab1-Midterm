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

	public static GameManger instance; 
	// Use this for initialization
	void Start () {
		
		//Singleton Make sure there's only one GM 
		if (instance  == null)
		{
			
		}
		else
		{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void checkGameState()
	{
		switch (currentState)
		{
			case GameState.title:
				break;
			case GameState.about:
				break;
			case GameState.playing:
				break;
			case  GameState.pause:
				break;
		}
	}
}
