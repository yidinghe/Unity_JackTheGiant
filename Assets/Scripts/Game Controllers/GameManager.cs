using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	void OnEnable ()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Awake ()
	{
		MakeSingleton ();
	}

	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Gameplay") {

			if (gameRestartedAfterPlayerDied) {
				
				GamePlayController.instance.SetScore (score);
				GamePlayController.instance.SetCoinScore (coinScore);
				GamePlayController.instance.SetLifeScore (lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;

			} else if (gameStartedFromMainMenu) {

				GamePlayController.instance.SetScore (0);
				GamePlayController.instance.SetCoinScore (0);
				GamePlayController.instance.SetLifeScore (2);

				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;
			}
				
		}
	}

	public void CheckGameStatus (int score, int coinScore, int lifeScore)
	{
		if (lifeScore < 0) {

			//TODO save high Score and CoinScore

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = false;

			GamePlayController.instance.GameOverShowPanel (score, coinScore);
		} else {
			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = true;

			GamePlayController.instance.PlayerDiedRestartGame ();
		}
	}
}
