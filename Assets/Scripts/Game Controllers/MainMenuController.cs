using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
		SceneManager.LoadScene ("GamePlay");
	}

	public void HighscoreMenu(){
		SceneManager.LoadScene ("HighScore");
	}

	public void OptionsMenu(){
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit();
	}


	public void MusicButton(){

	}
}
