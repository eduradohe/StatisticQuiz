using UnityEngine;
using System.Collections;

public class SolutionControl : MonoBehaviour {

	private Sprite solution;

	void Awake() {

		string questionId = "";
		
		switch (GameManager.lastQuestionLevel) {
		case 1:
			questionId = "E";
			break;
		case 2:
			questionId = "M";
			break;
		case 3:
			questionId = "H";
			break;
		default:
			break;
		}

		questionId += GameManager.lastQuestionId;
		this.solution = Resources.Load<Sprite>("Sprites/Solutions/" + questionId);
	}

	// Use this for initialization
	void Start () {

		GameObject solutionImage = new GameObject();
		solutionImage.AddComponent<SpriteRenderer>();
		solutionImage.GetComponent<SpriteRenderer>().sprite = this.solution;

		Vector3 sPosition = solutionImage.transform.position;
		sPosition.x = 0;
		sPosition.y = 0;
		sPosition.z = 0;
		solutionImage.transform.position = sPosition;

		GameManager.penalty = 0;
		GameManager.lastQuestionId = 0;
	}

	void OnGUI() {
		int areaWidth = 100;
		int areaHeight = 20;
		int initialWidth = (Screen.width / 2) - (areaWidth / 2);
		int initialHeight = ((Screen.height * 3) / 4) - (areaHeight / 2);

		bool goOn = GUI.Button (
			new Rect(
				initialWidth,
				initialHeight + ((areaHeight + 5) * 2),
				areaWidth,
				areaHeight
			),
			"Continuar"
		);
		
		if ( goOn ) {
			Application.LoadLevel(1);
		}
	}
}
