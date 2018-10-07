using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2f); // eyðir gameObjecti, notað fyrir bloodsplatter svo að það verði ekki til hundruði gameObjecta sem spawna blóð.
	}
}
