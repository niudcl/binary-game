/***************************************
 * 
 * 	FileIOManager
 * 
 * 	Manages file IO and quiting game.
 * 
 * ************************************/
using UnityEngine;
using System.IO;
using System.Collections;

public class FileIOManager : MonoBehaviour {
	
	private string dir;
	private string filename = "highscore";
	private HighScore hs;

	private void Start () {
		hs = GameObject.FindObjectOfType<HighScore>();
		
		dir = Directory.GetCurrentDirectory() + "\\";
		hs.HScore = LoadFromFile(dir + filename);

		DontDestroyOnLoad(this);
	}

	private void Update () {
		if (Application.loadedLevel == 0) {
			Application.LoadLevel(1);
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			SaveToFile(hs.HScore, dir + filename);
			Application.Quit();
		}
	}

	private void SaveToFile (int score, string path) {
		File.WriteAllText(path, score.ToString());
	}

	private int LoadFromFile (string path) {
		string highscore;
		try {
			highscore = File.ReadAllText(path);
		} catch (FileNotFoundException e) {
			// no saved high score;
			Debug.Log(e);
			return 0;
		}
		return int.Parse(highscore);
	}
}
