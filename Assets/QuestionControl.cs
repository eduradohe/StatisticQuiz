using UnityEngine;
using System.Collections.Generic;

public class QuestionControl : MonoBehaviour {

	private int questionLevel;
	private int drawnQuestion;
	private string question;
	private List<string> answers;
	private string questionId;

	public GUISkin theSkin;

	// Use this for initialization
	void Start () {
		this.questionLevel = GameManager.lastQuestionLevel;
		Dictionary<string, object> questionsMap = null;
		Dictionary<string, object> answersMap = null;

		string levelId = null;

		switch (this.questionLevel) {
		case 1:
			questionsMap = GameManager.easyMap;
			levelId = "E";
			break;
		case 2:
			questionsMap = GameManager.mediumMap;
			levelId = "M";
			break;
		case 3:
			questionsMap = GameManager.hardMap;
			levelId = "H";
			break;
		default:
				questionsMap = null;
			break;
		}

		answersMap = GameManager.answers;

		this.drawnQuestion = GameManager.lastQuestionId;
		this.questionId = null;

		while (this.drawnQuestion == 0) {
			this.drawnQuestion = Random.Range(1, questionsMap.Count + 1);
			this.questionId = levelId + this.drawnQuestion;

			if ( GameManager.usedQuestions.Contains(this.questionId) ) {
				this.drawnQuestion = 0;
				this.questionId = null;
			}
		}

		if (GameManager.lastQuestionId == 0) {
			GameManager.usedQuestions.Add (this.questionId);
		} else {
			this.questionId = levelId + this.drawnQuestion;
		}

		object qValue = null;
		object aValue = null;

		questionsMap.TryGetValue (this.drawnQuestion.ToString(), out qValue);
		this.question = qValue as string;

		answersMap.TryGetValue (this.questionId, out aValue);
		this.answers = aValue as List<string>;


	}

	void OnGUI () {
		GUI.skin = this.theSkin;
		GUI.Label (new Rect (5, 5, 250, 250), this.question);

		bool[] aButtons = new bool[this.answers.Count];
		string[] answersArray = this.answers.ToArray ();
		int correctIndex = -1;

		int buttonsAreaWidth = 200;
		int buttonsAreaHeight = 25;
		int initialWidth = Screen.width / 2 - buttonsAreaWidth / 2;
		int initialHeight = ((Screen.height * 1) / 4) - buttonsAreaHeight / 2;

		for ( int i = 0; i < this.answers.Count; i++ ) {
			string answer = answersArray[i];
			if ( answer.Contains("{C}") ) {
				correctIndex = i;
				answer = answer.Replace("{C}", "");
			}

			aButtons[i] = GUI.Button(
				new Rect(
					initialWidth,
					initialHeight + ((buttonsAreaHeight + 5) * i),
					buttonsAreaWidth,
					buttonsAreaHeight
				),
				answer
			);

			if ( aButtons[i] ) {
				if ( i == correctIndex ) {
					GameManager.score += (this.questionLevel - ((GameManager.penalty > this.questionLevel) ? this.questionLevel : GameManager.penalty)) * 5;

					Application.LoadLevel(3);
				} else {
					GameManager.penalty += 1;
					GameManager.lastQuestionId = this.drawnQuestion;
					Application.LoadLevel(4);
				}
			}
		}
	}
}
