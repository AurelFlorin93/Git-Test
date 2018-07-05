using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{

	//private const float bufferTime = 3.0f;
	private static LevelManager instance;
	public static LevelManager Instance{get{return instance;}}

	public GameObject gameOver;
	public GameObject restartBtn;
	public GameObject endMenu;
	public GameObject pauseMenu;

//	public Transform respawnpoint;
	public Text endTimerText;
	public Text timerText;
//	private GameObject player;

	private float startTime;
	private float levelDuration;
	public float silverTime;
	public float goldTime;

//	private bool isDead = false;


	private void Start()
	{
		instance = this;
		pauseMenu.SetActive (false);
		//endMenu.SetActive (false);
		restartBtn.SetActive (true);
		gameOver.SetActive (false);

		startTime = Time.time;
		//player = GameObject.FindGameObjectWithTag ("Player");
	//	player.transform.position = respawnpoint.position;

	//	if (Time.time - startTime <bufferTime)

	//	{
	//		return;
	//	}
	}

//------------------------------------------------------------------------

	private void Update()
	{



	//	if (isDead)
	//	{
			
	//		return;
	//	}

	//	if (player.transform.position.y < -5.0f)
	//	{
	//		Death ();
	//	}

	//	levelDuration = Time.time - (startTime + bufferTime);

	//		string minutes=((int)levelDuration/60).ToString("00");
	//		string seconds=(levelDuration % 60).ToString("00");
	//		timerText.text = minutes + ":" + seconds;
		
	}
//------------------------------------------------------------




	//Meniu
//------------------------------------------------------------

	public void TogglePauseMenu()
	{
		pauseMenu.SetActive (!pauseMenu.activeSelf);
		Time.timeScale = (pauseMenu.activeSelf) ? 0 : 1;

		//restartBtn.SetActive (!restartBtn.activeSelf);
		//Time.timeScale=(restartBtn.activeSelf) ? 0:1;
	}

	public void RestartLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ToMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");
	}


	public void Victory()
	{
		gameOver.SetActive (false);
	//	Debug.Log ("VICTORIE");
		foreach(Transform t in endMenu.transform.parent)
		{
			t.gameObject.SetActive (false);
			//endMenu.SetActive(true);
		}

		endMenu.SetActive(true);
		Time.timeScale = 1;
		restartBtn.SetActive(false);

		//	Rigidbody rigid = player.GetComponent<Rigidbody>();
		//rigid.constraints = RigidbodyConstraints.FreezeAll;

		levelDuration = Time.time - (startTime + 5.0f);
		string minutes=((int)levelDuration/60).ToString("00");
		string seconds=(levelDuration % 60).ToString("00");
		endTimerText.text=minutes + ":" + seconds;





		//Recompensa in functie de timp
//------------------------------------------------------------------

		if (levelDuration  < goldTime)
		{
			GameManager.Instance.currency += 0;
			endTimerText.color = Color.yellow;
		}
		else if (levelDuration  < silverTime)
		{
			GameManager.Instance.currency += 0;
			endTimerText.color = Color.gray;
		} 
		else
		{
			GameManager.Instance.currency += 0;
			endTimerText.color = new Color (0.8f,0.5f,0.2f,1.0f);
		}

		GameManager.Instance.Save ();

//------------------------------------------------------------------	

		string saveString="";
		LevelData level = new LevelData (SceneManager.GetActiveScene ().name);
		saveString += (level.BestTime>levelDuration  || level.BestTime == 0.0f) ? levelDuration .ToString () : level.BestTime.ToString();
		saveString += '&';
		saveString +=silverTime.ToString();
		saveString += '&';
		saveString += goldTime.ToString ();

		PlayerPrefs.SetString (SceneManager.GetActiveScene ().name, saveString);
		//SceneManager.LoadScene ("MainMenu");
	}
/*
	public void Death()
	{
		player.transform.position = respawnpoint.position;
		Rigidbody rigid = player.GetComponent<Rigidbody> ();
		rigid.velocity = Vector3.zero;
		rigid.angularVelocity = Vector3.zero;
		RestartLevel ();
	}
	*/

//	public void OnDeath()
//	{
//		isDead = true;

//	}




}
