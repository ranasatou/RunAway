using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour {
    // coinPrefabを入れる
    public GameObject CoinPrefab;

    // Unityちゃんを呼ぶ
    private GameObject unitychan;

    // 右に生成する座標
    private float rightGeneratePos = 0;

    // Use this for initialization
    void Start() {
        this.unitychan = GameObject.Find("unitychan");

        // 右方向に生成する最初のアイテムの生成の基準座標
        this.rightGeneratePos = this.unitychan.transform.position.x + 15;
    }

    // Update is called once per frame
    void Update() {
        if (unitychan.transform.position.x + 10.0f > this.rightGeneratePos) {
            // コインを何枚出すのかランダムに設定
            int num = Random.Range(0, 20);

            // ランダムな数分コインを生成
            for (float i = 0; i < num; i++) {
                // x軸方向のばらつき
                float XRange = Random.Range(this.rightGeneratePos, this.rightGeneratePos + 15.0f);

                // z軸方向のばらつき
                float ZRange = Random.Range(this.unitychan.transform.position.z - 5, this.unitychan.transform.position.z + 5);

                GameObject coin = Instantiate(CoinPrefab) as GameObject;
                coin.transform.position = new Vector3(XRange, coin.transform.position.y, ZRange);
            }

            this.rightGeneratePos += 15;
        }
    }
}