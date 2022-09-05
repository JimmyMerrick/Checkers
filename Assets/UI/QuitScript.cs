using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour
{

	public void QuitGame()
	{
		// Debug.Log("testing");
		// Close app in editor play mode
		UnityEditor.EditorApplication.isPlaying = false;

		// Quit game app after build
		Application.Quit();
	}

	public void PlayerGame() {
		// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void PlayersGame() {
		SceneManager.LoadScene(1);
	}

	public void OptionMenu() {

	}
}
