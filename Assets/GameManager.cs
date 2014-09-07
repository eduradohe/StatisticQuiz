using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static int score;
	public static int lastQuestionLevel;
	public static int lastQuestionId;
	public static int playerSpot;
	public static Vector3 playerPosition;
	
	public static int penalty;

	public static Dictionary<string, object> easyMap;
	public static Dictionary<string, object> mediumMap;
	public static Dictionary<string, object> hardMap;
	public static Dictionary<string, object> answers;

	public static List<string> usedQuestions;

	void Awake () {
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Inicializando...");
		ResetGame ();

		string dir = Application.dataPath;
		string path = dir + @"\Questions\";

		easyMap = new Dictionary<string, object> ();
		this.Load (path + "Easy.txt", easyMap);
		
		mediumMap = new Dictionary<string, object> ();
		this.Load (path + "Medium.txt", mediumMap);
		
		hardMap = new Dictionary<string, object> ();
		this.Load (path + "Hard.txt", hardMap);
		
		answers = new Dictionary<string, object> ();
		this.Load (path + "Answers.txt", answers);

		Application.LoadLevel(1);
	}

	private void Map(string[] entries, Dictionary<string, object> map) {

		object toBePut = null;

		if ( entries[0].StartsWith("E") || entries[0].StartsWith("M") || entries[0].StartsWith("H") ) {

			object value = null;
			List<string> answers = null;

			if ( map.TryGetValue(entries[0], out value) ) {
				answers = value as List<string>;
			} else {
				answers = new List<string>();
			}

			answers.Add(entries[1]);
			toBePut = answers;
		} else {
			toBePut = entries[1];
		}

		map.Remove (entries [0]);
		map.Add (entries[0], toBePut);
	}

	private bool Load(string fileName, Dictionary<string, object> map) {

		try {
			string line;

			StreamReader theReader = new StreamReader(fileName, Encoding.Default);

			using (theReader) {

				line = theReader.ReadLine();

				while (line != null) {

					string[] entries = line.Split(':');
					if (entries.Length > 0) {
						Map(entries, map);
					}

					line = theReader.ReadLine();
				};

				theReader.Close();
				return true;
			}
		}

		catch (System.Exception e) {
			System.Console.WriteLine("{0}\n", e.Message);
			return false;
		}
	}

	public static void ResetGame() {
		score = 0;
		penalty = 0;
		lastQuestionLevel = 0;
		lastQuestionId = 0;
		playerSpot = 0;
		playerPosition = new Vector3(-2.3f, 2.58f, 0);
		
		usedQuestions = new List<string> ();
	}
}
