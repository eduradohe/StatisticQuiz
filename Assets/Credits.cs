using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GUISkin theSkin;

	void OnGUI () {
		GUI.skin = this.theSkin;

		int areaWidth = 300;
		int areaHeight = 20;
		int initialWidth = (Screen.width / 2) - (areaWidth / 2);
		int initialHeight = (areaHeight / 2);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight,
				areaWidth,
				areaHeight
			),
			"Eduardo Oliveira - Programador, Artista 2D"
		);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight + (areaHeight + 5),
				areaWidth,
				areaHeight
			),
			"Jayme Mattos - Game Designer"
		);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 2 ),
				areaWidth,
				areaHeight
			),
			"Leonardo Dos Anjos - Game Designer"
		);

		GUI.Label(
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 3 ),
				areaWidth,
				areaHeight
			),
			"Priscila Dair - Game Designer"
			);
		
		bool goBack = GUI.Button(
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 4 ),
				areaWidth,
				areaHeight
			),
			"Voltar"
		);

		if ( goBack ) {
			Application.LoadLevel(7);
		}
	}
}
