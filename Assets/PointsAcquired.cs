using UnityEngine;
using System.Collections;

public class PointsAcquired : MonoBehaviour {

	public GUISkin theSkin;

	private int pointsAcquired;

	void Start() {
		this.pointsAcquired = (GameManager.lastQuestionLevel - ((GameManager.penalty > GameManager.lastQuestionLevel) ? GameManager.lastQuestionLevel : GameManager.penalty)) * 5;
		GameManager.penalty = 0;
		GameManager.lastQuestionId = 0;
	}

	void OnGUI() {
		GUI.skin = this.theSkin;

		int areaWidth = 300;
		int areaHeight = 30;
		int initialWidth = (Screen.width / 2) - (areaWidth / 2);
		int initialHeight = (Screen.height / 2) - (areaHeight / 2);

		GUI.Label (new Rect (
				initialWidth,
				initialHeight,
				areaWidth,
				areaHeight
			), 
		    "Voce ganhou " + pointsAcquired + " pontos!"
		);
		bool continuar = GUI.Button (new Rect (
				initialWidth,
				initialHeight + areaHeight + 5,
				areaWidth,
				areaHeight
			), 
		    "Continuar"
		);

		if ( continuar ) {
			Application.LoadLevel(1);
		}
	}
}
