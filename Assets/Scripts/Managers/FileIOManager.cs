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
		hs.HScore = LoadScoreFromFile(dir + filename);

		DontDestroyOnLoad(this);
	}

	private void Update () {
        // move past loading level
		if (Application.loadedLevel == 0) {
			Application.LoadLevel(1);
		}

        // esc quits game
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	private void OnApplicationQuit() {
		// save high score before quit
        File.WriteAllText(dir + filename, hs.HScore.ToString());
	}

	private int LoadScoreFromFile (string path) {
		int score;
        if (File.Exists(path)) {
            try {
                score = int.Parse(File.ReadAllText(path));
            } catch (System.FormatException e) {
                Debug.Log(e.ToString());
                score = 0;
            }
        } else {
            score = 0;
        }
        return score;
	}
}
