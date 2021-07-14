using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject countText;
    private int Count;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;

        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.countText = GameObject.Find("CountText");
        this.countText.GetComponent<Text>().text = "Count " + Count.ToString();
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
        this.countText.GetComponent<Text>().text = "Count " + Count.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "SmallStarTag":
                Count += 10;
                break;
            case "LargeStarTag":
                Count += 20;
                break;
            case "SmallCloudTag":
                Count += 15;
                break;
            case "LargeCloudTag":
                Count += 25;
                break;
        }
    }

}
