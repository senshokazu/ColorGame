using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCube : MonoBehaviour {
	public GameObject cube;
    float a = 0;
    
	// Use this for initialization
	void Start () {
		StartCoroutine ("stage");
	}
    //コルーチンを使う理由は、for文をそのまま使うとUnityがフリーズするから

	IEnumerator stage(){
		for (int i = 49; i >= 0; i--) {
         
			Instantiate (cube, new Vector3 (transform.position.x+a, transform.position.y, transform.position.z), new Quaternion (0, 0, 0, 0));
		    a +=0.5f;
			yield return new WaitForSeconds (0.000001f);
        }
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
