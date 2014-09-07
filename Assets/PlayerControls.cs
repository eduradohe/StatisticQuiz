using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	
	private Color mouseOverColor = Color.cyan;
	private Color originalColor = Color.gray;
	private Color easyColor = Color.green;
	private Color mediumColor = Color.yellow;
	private Color hardColor = Color.red;
	
	private Vector3 originalPosition;
	
	private bool isValidSpot = false;
	private bool dragging = false;
	private float distance;
	
	private int actualSpot;
	private int otherSpot;
	private int steps;
	
	private EmptySpot newSpot;

	void Start() {

		if ( GameManager.usedQuestions.Count == 
		    (GameManager.easyMap.Count + GameManager.mediumMap.Count + GameManager.hardMap.Count) ) {
			Application.LoadLevel(6);
		}

		this.actualSpot = GameManager.playerSpot;
		this.transform.position = GameManager.playerPosition;
		this.otherSpot = -1;
		this.steps = 0;
		this.originalPosition = this.transform.position;
		renderer.material.color = originalColor;

		if ( this.actualSpot == 24 ) {
			Application.LoadLevel(6);
		}
	}
	
	void OnMouseDown() {
		this.originalPosition = this.transform.position;
		renderer.material.color = mouseOverColor;
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
	
	void OnMouseUp() {
		dragging = false;

		bool changeLevel = false;

		if ( this.isValidSpot ) {
			this.transform.position = this.newSpot.transform.position;
			this.actualSpot = this.otherSpot;
			changeLevel = true;
		} else {
			this.transform.position = this.originalPosition;
		}

		if ( changeLevel ) {
			GameManager.playerSpot = this.newSpot.spotId;
			GameManager.playerPosition = this.transform.position;
			GameManager.lastQuestionLevel = this.steps;
			Application.LoadLevel(2);
		}

		this.otherSpot = -1;
		this.newSpot = null;
		this.steps = 0;
		renderer.material.color = originalColor;
	}
	
	void OnTriggerEnter2D( Collider2D colInfo ) {

		if ( colInfo.tag == "EmptySpot" ) {
			EmptySpot emptySpot = (EmptySpot) colInfo.gameObject.GetComponent("EmptySpot");
			this.otherSpot = emptySpot.spotId;
			this.newSpot = emptySpot;
			
			this.steps = this.otherSpot - this.actualSpot;

			switch (this.steps) {
			case 1:
				renderer.material.color = easyColor;
				this.isValidSpot = true;
				break;
			case 2:
				renderer.material.color = mediumColor;
				this.isValidSpot = true;
				break;
			case 3:
				renderer.material.color = hardColor;
				this.isValidSpot = true;
				break;
			default:
				this.isValidSpot = false;
				break;
			}
		}
	}
	
	void OnTriggerExit2D( Collider2D colInfo ) {

		this.isValidSpot = false;
		this.otherSpot = -1;
		this.newSpot = null;
		this.renderer.material.color = mouseOverColor;
	}
	
	void Update() {
		if (dragging) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}