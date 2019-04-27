using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    private Rigidbody myRigidbody;
    //前進するための力（追加）
    private float forwardForce = 800.0f;

    //左右に移動するための力（追加）
    private float turnForce = 500.0f;

    //ジャンプするための力（追加）
    private float upForce = 600.0f;

    //左右の移動できる範囲（追加）
    private float movableRange = 180f;

    // Use this for initialization
    void Start() {

        //アニメータコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //止まってる状態のアニメーション
        this.myAnimator.SetFloat("Speed", 0);

        //走るアニメーションを開始
        //this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得（追加）
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

        //Unityちゃんに前方向の力を加える（追加）
        if (Input.GetKey(KeyCode.UpArrow)) {
            this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
            this.myAnimator.SetFloat("Speed", 1); // ここで1にする
        }else {
            this.myAnimator.SetFloat("Speed", 0);
        }

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる（追加）
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x) {
            //左に移動（追加）
            transform.Rotate(0, -1, 0);
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
            this.myAnimator.SetFloat("Speed", 1); // ここで1にする
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange) {
            //右に移動（追加）
            transform.Rotate(0, 1, 0);
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
            this.myAnimator.SetFloat("Speed", 1); // ここで1にする
        }

        //Jumpステートの場合はJumpにfalseをセットする（追加）
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
            this.myAnimator.SetBool("Jump", false);
        }

        //ジャンプしていない時にスペースが押されたらジャンプする（追加）
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f) {
            //ジャンプアニメを再生（追加）
            this.myAnimator.SetBool("Jump", true);
            //Unityちゃんに上方向の力を加える（追加）
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }
}