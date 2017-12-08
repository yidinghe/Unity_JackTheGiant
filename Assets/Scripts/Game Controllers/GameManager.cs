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

	void Start ()
	{
		InitializeVariables ();
	}

	void InitializeVariables ()
	{
		if (!GamePreferences.IsGameInited ()) {

			GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetEasyDifficultyHighScore (0);
			GamePreferences.SetEasyDifficultyCoinScore (0);

			GamePreferences.SetMediumDifficultyState (1);
			GamePreferences.SetMediumDifficultyHighScore (0);
			GamePreferences.SetMediumDifficultyCoinScore (0);

			GamePreferences.SetHardDifficultyState (0);
			GamePreferences.SetHardDifficultyHighScore (0);
			GamePreferences.SetHardDifficultyCoinScore (0);

			GamePreferences.SetGameInit ();

		}
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

			SetScoreBasedOnDifficulty (score, coinScore);
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

	void SetScoreBasedOnDifficulty (int score, int coinScore)
	{

		if (GamePreferences.GetEasyDifficultyState () == 1) {

			int savedHighScore = GamePreferences.GetEasyDifficultyHighScore ();
			int savedCoinScore = GamePreferences.GetEasyDifficultyCoinScore ();

			if (score > savedHighScore) {
				GamePreferences.SetEasyDifficultyHighScore (score);
			}

			if (coinScore > savedCoinScore) {
				GamePreferences.SetEasyDifficultyCoinScore (coinScore);
			}

		}

		if (GamePreferences.GetMediumDifficultyState () == 1) {

			int savedHighScore = GamePreferences.GetMediumDifficultyHighScore ();
			int savedCoinScore = GamePreferences.GetMediumDifficultyCoinScore ();

			if (score > savedHighScore) {
				GamePreferences.SetMediumDifficultyHighScore (score);
			}

			if (coinScore > savedCoinScore) {
				GamePreferences.SetMediumDifficultyCoinScore (coinScore);
			}
				
		}

		if (GamePreferences.GetHardDifficultyState () == 1) {

			int savedHighScore = GamePreferences.GetHardDifficultyHighScore ();
			int savedCoinScore = GamePreferences.GetHardDifficultyCoinScore ();

			if (score > savedHighScore) {
				GamePreferences.SetHardDifficultyHighScore (score);
			}

			if (coinScore > savedCoinScore) {
				GamePreferences.SetHardDifficultyCoinScore (coinScore);
			}

		}

	}
}
