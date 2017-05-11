using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeoutTextUI : MonoBehaviour {
    public Text text;
    float alpha;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        alpha = 1.0f;
      
	}
	
	// Update is called once per frame
	void Update () {
        alpha -= 1.0f * Time.deltaTime;
        text.color = new Color(1,0,0,alpha);
	}
}
