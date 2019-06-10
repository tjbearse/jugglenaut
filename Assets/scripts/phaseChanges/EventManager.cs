using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
	public delegate void GameOverDel();
	public static event GameOverDel onGameOver;
	public static void GameOver() {
		if (EventManager.onGameOver != null) {
			EventManager.onGameOver();
		}
	}

	public delegate void RestartDel();
	public static event RestartDel onRestart;
	public static void Restart() {
		if (EventManager.onRestart != null) {
			EventManager.onRestart();
		}
	}
}
