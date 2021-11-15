using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{  //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }


    // Update is called once per frame
    void Update()
    {

        //キーを押した時フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag" ||
            Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyDown(KeyCode.DownArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyDown(KeyCode.S) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag" ||
            Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag" ||
            Input.GetKeyDown(KeyCode.DownArrow) && tag == "RightFripperTag" ||
            Input.GetKeyDown(KeyCode.S) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }


        //離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag" ||
            Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyUp(KeyCode.DownArrow) && tag == "LeftFripperTag" ||
            Input.GetKeyUp(KeyCode.S) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag" ||
            Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag" ||
            Input.GetKeyUp(KeyCode.DownArrow) && tag == "RightFripperTag" ||
            Input.GetKeyUp(KeyCode.S) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //Touch判定
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                //触ったときふりっぱーを動かす
                if (Screen.width / 2 > t.position.x && t.phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                if (Screen.width / 2 < t.position.x && t.phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //話したときふりっぱーを戻す
                if (Screen.width / 2 > t.position.x && t.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                if (Screen.width / 2 < t.position.x && t.phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }

            }
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}