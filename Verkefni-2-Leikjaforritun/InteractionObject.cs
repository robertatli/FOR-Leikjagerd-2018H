using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {// notað fyrir playerInteract.cs

	public void DoInteraction()
    {
        gameObject.SetActive(false);//setur gameobjectið sem ekki active(lætur lykilinn hverfa t.d. eftir að hann sé tekinn upp)
    }
}
