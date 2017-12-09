﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{

	[SerializeField]
	private Text scoreText, coinText;

	// Use this for initialization
	void Start ()
	{
		SetScoreBasedOnDifficulty ();
	}

	void SetScore (int score, int coinScore)
	{
		scoreText.text = score.ToString ();
		coinText.text = coinScore.ToString ();
	}

	void SetScoreBasedOnDifficulty ()
	{
		
		if (GamePreferences.GetEasyDifficultyState () == 1) {
			SetScore (GamePreferences.GetEasyDifficultyHighScore (), GamePreferences.GetEasyDifficultyCoinScore ());
		}

		if (GamePreferences.GetMediumDifficultyState () == 1) {
			SetScore (GamePreferences.GetMediumDifficultyHighScore (), GamePreferences.GetMediumDifficultyCoinScore ());
		}

		if (GamePreferences.GetHardDifficultyState () == 1) {
			SetScore (GamePreferences.GetHardDifficultyHighScore (), GamePreferences.GetHardDifficultyCoinScore ());
		}

	}

	public void GoBackToMainMenu ()
	{
		SceneFader.instance.LoadLevel ("MainMenu");
	}
}
