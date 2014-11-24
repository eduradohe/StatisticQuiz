using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class PlayerDataControl : MonoBehaviour {
		
		public GUISkin theSkin;
		public string playerName;
		public string playerCourse;
		public string playerSemester;
		public string playerCR;
		public string playerAge;
		public string playerGender;
		
		void Start () {
			this.playerName = "";
			this.playerCourse = "";
			this.playerSemester = "";
			this.playerCR = "";
			this.playerAge = "";
			this.playerGender = "";
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
				"PREENCHA SEUS DADOS"
			);
			
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 1),
					areaWidth - 220,
					areaHeight
				),
				"Nome: "
			);
			
			this.playerName = GUI.TextField (
				new Rect(
					initialWidth + 80,
					initialHeight + ((areaHeight + 5) * 1),
					areaWidth - 80,
					areaHeight
				),
				this.playerName,
				25
			);
			
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 2),
					areaWidth - 220,
					areaHeight
				),
				"Curso: "
			);
			
			this.playerCourse = GUI.TextField (
				new Rect(
					initialWidth + 80,
					initialHeight + ((areaHeight + 5) * 2),
					areaWidth - 80,
					areaHeight
				),
				this.playerCourse,
				25
			);
			
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 3),
					areaWidth - 220,
					areaHeight
				),
				"Periodo: "
			);
			
			this.playerSemester = GUI.TextField (
				new Rect(
					initialWidth + 80,
					initialHeight + ((areaHeight + 5) * 3),
					areaWidth - 80,
					areaHeight
				),
				this.playerSemester,
				25
			);
			
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 4),
					areaWidth - 220,
					areaHeight
				),
				"CR: "
			);
			
			this.playerCR = GUI.TextField (
				new Rect(
					initialWidth + 80,
					initialHeight + ((areaHeight + 5) * 4),
					areaWidth - 80,
					areaHeight
				),
				this.playerCR,
				25
			);
			
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 5),
					areaWidth - 220,
					areaHeight
				),
				"Idade: "
			);
			
			this.playerAge = GUI.TextField (
				new Rect(
					initialWidth + 80,
					initialHeight + ((areaHeight + 5) * 5),
					areaWidth - 80,
					areaHeight
				),
				this.playerAge,
				25
			);
			
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 6),
					areaWidth - 220,
					areaHeight
				),
				"Sexo: "
			);
			
			this.playerGender = GUI.TextField (
				new Rect(
					initialWidth + 80,
					initialHeight + ((areaHeight + 5) * 6),
					areaWidth - 80,
					areaHeight
				),
				this.playerGender,
				25
			);
			
			bool ok = GUI.Button (
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 7),
					areaWidth,
					areaHeight
				),
				"OK"
			);
			
			if (ok) {
				this.Save (playerName);
				Application.LoadLevel(2);
			}
		}
		
		private void Save(string playerName) {
			
			StreamWriter sw = null;
			
			string dir = Application.dataPath;
			string path = dir + @"\";
			string filePath = path + "ScoreBoard.txt";
			
			if (!File.Exists (filePath)) {
				sw = File.CreateText (filePath);
				sw.WriteLine ("{0};{1};{2};{3};{4};{5};{6}", "Nome", "Curso", "Periodo", "CR", "Idade", "Sexo", "Pontos");
			} else {
				sw = new StreamWriter(filePath, true);
			}
			
			sw.Write ("{0};{1};{2};{3};{4};{5};", playerName, playerCourse, playerSemester, playerCR, playerAge, playerGender);
			sw.Close ();
		}
}
