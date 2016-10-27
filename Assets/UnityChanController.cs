using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプの速度の減退
    private float dump = 0.8f;

    //ジャンプの速度
    float jumpVelocity = 20;

	// Use this for initialization
	void Start () {
        //アニメーターのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
        //走るアニメーションを再生するために、Animatorのパラメータを調整する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //着地点でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //クリックをやめたら上報告への速度を減速する
        if(Input.GetMouseButton(0) == false)
        {
            if(this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
	
	}
}
