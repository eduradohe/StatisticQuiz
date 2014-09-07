using UnityEngine;
using System.Collections;

public class WrongChoice : MonoBehaviour {

	public GUISkin theSkin;

	private int remainingAttempts;

	void Start () {
		this.remainingAttempts = GameManager.lastQuestionLevel - GameManager.penalty;
	}

	void OnGUI () {
		GUI.skin = this.theSkin;

		int areaWidth = 300;
		int areaHeight = 30;
		int initialWidth = (Screen.width / 2) - (areaWidth / 2);
		int initialHeight = ((Screen.height * 1)/ 4) - (areaHeight / 2);

		if (this.remainingAttempts == 0) {
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight,
					areaWidth,
					areaHeight
				),
				"Voce nao possui tentativas restantes."
			);
		} else if (this.remainingAttempts > 0) {
			GUI.Label(
				new Rect(
					initialWidth,
					initialHeight,
					areaWidth,
					areaHeight
				),
				"Voce possui " + this.remainingAttempts + " tentativas restantes."
			);

			bool tentar = GUI.Button (
				new Rect(
					initialWidth,
					initialHeight + ((areaHeight + 5) * 1),
					areaWidth,
					areaHeight
				),
				"Tentar Novamente"
			);

			if ( tentar ) {
				Application.LoadLevel(2);
			}
		}

		bool solution = GUI.Button (
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 2),
				areaWidth,
				areaHeight
			),
			"Mostrar Soluçao"
		);

		if ( solution ) {
			Application.LoadLevel(5);
		}
	}
}
