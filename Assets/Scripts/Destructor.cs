﻿using UnityEngine;

public class Destructor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		Destroy(coll.gameObject);
	}
}
