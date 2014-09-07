using UnityEngine;
using System.Collections;
using System;

public class Score : MonoBehaviour, IComparable<Score> {

	public string playerName;
	public int score;

	public int CompareTo(Score other) {
		return other.score.CompareTo(this.score);
	}
}
