using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static GameManager s_instance;

	public enum GameState { Title, Intro, Game, Continue, Win, GameOver  }

	public GameState m_gameState;

	#region Singleton Initialization
	public static GameManager instance {
		get { 
			if(s_instance == null)
				s_instance = GameObject.FindObjectOfType<GameManager>();
			
			return s_instance;
		}
	}
	
	void Awake() {
		if(s_instance == null) {
			//If I am the fist instance, make me the first Singleton
			s_instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			//If a Singleton already exists and you find another reference in scene, destroy it
			if(s_instance != this)
				DestroyImmediate(gameObject);
			//Destroy(gameObject);
		}
	}
	#endregion
	
	void Start () {
		m_gameState = GameState.Title;
	}

	void Update () {
		switch( m_gameState )
		{
		case GameState.Title:
			TitleUpdate();
			break;
		case GameState.Intro:
			IntroUpdate();
			break;
		case GameState.Game:
			GameUpdate();
			break;
		case GameState.Continue:
			ContinueUpdate();
			break;
		case GameState.Win:
			WinUpdate();
			break;
		case GameState.GameOver:
			GameOverUpdate();
			break;
		}
	}

	public void ChangeState( GameState newState ) {
		switch( newState )
		{
		case GameState.Title:
			break;
		case GameState.Intro:
			break;
		case GameState.Game:
			break;
		case GameState.Continue:
			break;
		case GameState.Win:
			break;
		case GameState.GameOver:
			break;
		}
	}

	// Update for when the game is on Title Screen
	void TitleUpdate() {
	}

	// Update for when the game is runnning the intro sequence
	void IntroUpdate() {
	}

	// Udate that runs during the game's play session
	void GameUpdate() {
	}

	// Update running while the game asks for continue/more credits
	void ContinueUpdate() {
	}

	// Update during the Win sequence when the players 
	void WinUpdate() {

	}

	// Update that takes place when 
	void GameOverUpdate() {

	}
}
