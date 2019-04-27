using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;

    private float takasa;

    // Use this for initialization
    void Start() {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
        //Unityちゃんとカメラの位置（y座標）の差を求める
        this.takasa = unitychan.transform.position.y + this.transform.position.y;

    }

    // Update is called once per frame
    void Update() {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.unitychan.transform.position.x, this.unitychan.transform.position.y + takasa, this.unitychan.transform.position.z - difference);
    }
}