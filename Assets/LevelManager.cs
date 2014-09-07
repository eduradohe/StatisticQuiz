using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GUISkin theSkin;

	void OnGUI () {
		GUI.skin = this.theSkin;
		GUI.Label(new Rect(5, 5, 200, 500), "Pontos: " + GameManager.score);
	}
}