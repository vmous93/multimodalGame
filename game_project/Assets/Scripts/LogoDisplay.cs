using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoDisplay : MonoBehaviour {
	public float startGame = 1;
	float currentTime;

	void Start()
	{

	}

    void Update ()
	{
		currentTime += Time.deltaTime;
		if (currentTime > startGame){
			PlaytheGame();
			enabled = false;
		}
	}

	public void PlaytheGame()
	{
		SceneManager.LoadSceneAsync("SampleScene");
	}
}
