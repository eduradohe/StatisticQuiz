using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class GameOverControl : MonoBehaviour {

	public GUISkin theSkin;
	public string playerName;

	void Start () {
		this.playerName = "";
	}

	void OnGUI () {
		GUI.skin = this.theSkin;

		int areaWidth = 300;
		int areaHeight = 30;
		int initialWidth = (Screen.width / 2) - (areaWidth / 2);
		int initialHeight = ((Screen.height * 1)/ 4) - (areaHeight / 2);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight,
				areaWidth,
				areaHeight
			),
			"GAME OVER"
		);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 1),
				areaWidth,
				areaHeight
			),
			"Sua pontuaçao: " + GameManager.score
		);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 2),
				areaWidth - 250,
				areaHeight
			),
			"Nome: " + GameManager.score
		);

		this.playerName = GUI.TextField (
			new Rect(
				initialWidth + 50,
				initialHeight + ((areaHeight + 5) * 2),
				areaWidth - 50,
				areaHeight
			),
			this.playerName,
			25
		);

		bool ok = GUI.Button (
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 3),
				areaWidth,
				areaHeight
			),
			"OK"
		);

		if (ok) {
			this.Save (playerName);
			Application.LoadLevel(7);
		}
	}

	private void Save(string playerName) {

		StreamWriter sw = null;

		string dir = Application.dataPath;
		string path = dir + @"\";
		string filePath = path + "ScoreBoard.txt";
		
		if (!File.Exists (filePath)) {
			sw = File.CreateText (filePath);
		} else {
			sw = new StreamWriter(filePath, true);
		}

		sw.WriteLine ("{0};{1}", playerName, GameManager.score);
		sw.Close ();
	}
}
