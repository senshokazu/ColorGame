using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float speed;
    public int hp, attack;
    public int color_count; 
    public int fullhp, init_color_count;
    // Use this for initialization
    void Start()
    {

        fullhp = hp;

        init_color_count = color_count;
    }

    // Update is called once per frame
    void Update()
    {
        if (color_count > init_color_count)//カラーカウントを取得するほどオブジェクトが大きくなる
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            init_color_count += 1;
        }
    }
}
