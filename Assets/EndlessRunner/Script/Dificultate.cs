using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dificultate : MonoBehaviour {


	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 5;
	private int scoreTonextLevel = 10;
	private float timer = 0.0f;

	private bool isDead=false;

	public Text TimmerJoc;
	public DeathMenu deathMenu;
	public Text hightscoreText;

    private int count;
	private int NrMonede;// nr de monede colectate
	private int hightscore;

	public Text countText;
	public Text nrMonede;

	void Start()
	{
		hightscoreText.text="HightScore: "+((int)PlayerPrefs.GetFloat ("Hightscore",hightscore)).ToString ();
	}
   

	// Update is called once per frame
	void Update () 
	{
		

		if (isDead)
		{
			
			return;
		}

	//Cronometru
//--------------------------------------------------------------------

		timer+=Time.deltaTime;

		string minutes=((int)timer/60).ToString("00");
		string seconds=(timer % 60).ToString("00");
		TimmerJoc.text = minutes + ":" + seconds;

//--------------------------------------------------------------------

		if (count >= scoreTonextLevel)
		{
			LevelUp ();
	
		}


	}
		
	void LevelUp()
	{
		if (difficultyLevel == maxDifficultyLevel)
		{
			return;
		}
		scoreTonextLevel *= 2;
		difficultyLevel++;

		GetComponent<PlayerScript> ().SetSpeed (difficultyLevel);

	}

	//Colectare, scor si afisare
//-------------------------------------------------------------------
void OnTriggerEnter(Collider other)

{
	if (other.gameObject.CompareTag("Pick Up"))
	{
		    //other.gameObject.SetActive(false);
			other.GetComponent<Renderer>().enabled=false;
			count++;
			NrMonede++;
			GameManager.Instance.currency++;
			AudioSource source = GetComponent<AudioSource> ();
			source.Play ();
	
	}
	
	SetCountText();
}

	void SetCountText()
	{
		countText.text = count.ToString();
		nrMonede.text = NrMonede.ToString();
	}



	//Death fuunction
	//Opreste timpul afisat pe ecran
//-----------------------------------------------------------------------

	public void OnDeath()
	{
		isDead = true;

		if (PlayerPrefs.GetFloat ("Hightscore",hightscore) < NrMonede)
		{
			hightscore = NrMonede;
			PlayerPrefs.SetFloat ("Hightscore",hightscore);
		}

		deathMenu.ToggleEndMenu ();

	}




//------------------------------------------------------------------------
}


