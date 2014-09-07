using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class PlayerScore : MonoBehaviour {

	private List<Score> scoreList;
	public GUISkin theSkin;

	// Use this for initialization
	void Start () {
		string dir = Application.dataPath;
		string path = dir + @"\";
		string filePath = path + "ScoreBoard.txt";
		
		StreamReader theReader = new StreamReader (filePath);
		string line;

		this.scoreList = new List<Score> ();

		using (theReader) {
			line = theReader.ReadLine();
			Debug.Log(line);

			while (line != null) {

				string[] entries = line.Split(';');

				Score score = new Score();
				score.playerName = entries[0];
				score.score = int.Parse(entries[1]);
				scoreList.Add (score);

				line = theReader.ReadLine();
			};
			
			theReader.Close();
		}

		scoreList.Sort ();
	}
	
	void OnGUI() {
		GUI.skin = this.theSkin;

		int areaWidth = 300;
		int areaHeight = 20;
		int initialWidth = (Screen.width / 2) - (areaWidth / 2);
		int initialHeight = (areaHeight / 2);

		int maxIndex = 0;

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 0 ),
				areaWidth,
				areaHeight
			),
			"Top 5"
		);

		for ( int i = 0; (i < this.scoreList.Count && i < 5); i++) {

			Score score = this.scoreList.ToArray()[i];

			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * (i + 1) ),
					areaWidth,
					areaHeight
				),
				score.playerName + " - " + score.score
			);

			maxIndex = i + 1;
		}

		bool newGame = GUI.Button (
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * (maxIndex + 1) ),
				areaWidth,
				areaHeight
			),
			"Novo Jogo"
		);

		bool credits = GUI.Button (
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * (maxIndex + 2) ),
				areaWidth,
				areaHeight
			),
			"Creditos"
		);

		if ( newGame ) {
			GameManager.ResetGame();
			Application.LoadLevel(1);
		}

		if ( credits ) {
			Application.LoadLevel(8);
		}
	}
}
