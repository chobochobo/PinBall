using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //得点を表示する
    private GameObject ScoreText;
    //得点
    private int score = 0;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization

    // Update is called once per frame
    void Start()
    {
        //Score初期化
        score = 0;
        //シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }


    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        string tags = other.gameObject.tag;

        // タグによって光らせる色を変える
        if (tags == "SmallStarTag")
        {
            score += 10;

            this.ScoreText.GetComponent<Text>().text = "Score:" + score;
        }
        else if (tags == "LargeStarTag")
        {
            score += 20;

            this.ScoreText.GetComponent<Text>().text = "Score:" + score;
        }
        else if (tags == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            score += 30;

            this.ScoreText.GetComponent<Text>().text = "Score:" + score;
        }
    }
}