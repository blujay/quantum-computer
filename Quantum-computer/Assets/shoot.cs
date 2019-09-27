using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

public Transform RHand;

    // Start is called before the first frame update
    public void shootObject(){
        var direction = RHand.transform.rotation * Vector3.up * 100f;
        this.gameObject.GetComponent<Rigidbody>().AddForce(direction);
        Debug.Log(direction);
    }
}
