using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hit : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue" || other.gameObject.tag == "Red")
        {

            var Canvas1 = Instantiate(canvas.gameObject, other.bounds.center - Camera.main.transform.forward * 0.2f, other.transform.rotation);
            //text.gameObject⇒textはUIなので.gameObjectを付けることでtextがついたgameObjectが複製される
            Destroy(Canvas1.gameObject, 1.0f);
        }

    }


}
