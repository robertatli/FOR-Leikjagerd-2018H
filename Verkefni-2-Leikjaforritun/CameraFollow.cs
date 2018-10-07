using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {// lætur myndavélina elta playerinn

    public Transform target;// til að merkja targetið
    public float smoothTime = 0.3F;// hversu "smooth" movementið er á myndavélinni, hun er þa aðeins eftir playerinum
    public float posY;// styllir hversu hátt hun er fyrir ofan playerinn
    private Vector3 velocity = Vector3.zero; // fyrir velocity

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, posY, -10));// setur sig hjá playerinum

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);// hreyfir sig með playerinum smoothly
    }
}
