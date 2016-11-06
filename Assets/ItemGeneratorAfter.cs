using UnityEngine;
using System.Collections;

public class ItemGeneratorAfter : MonoBehaviour {
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject cornPrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんと生成するオブジェクトの距離
    private float difference = 40.0f;

    //時間計測用の変数
    private float delta = 0;
    //オブジェクトの生成間隔
    private float span = 1.0f;

    // Use this for initialization
    void Start() {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        this.ItemGenerator();

    }

    // Update is called once per frame
    void Update() {
        this.delta += Time.deltaTime;
        //span以上の時間が経過したか
        if (this.delta > this.span)
        {
            this.delta = 0;
            this.ItemGenerator();
        }

    }

    //アイテムを生成するメソッド
    void ItemGenerator()
    {
        if (this.unitychan.transform.position.z + this.difference > startPos)
        {
            //一定の距離ごとにアイテムを生成
            if(startPos < goalPos)
            {
                startPos += 15;
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(0, 10);
                if (num <= 1)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject corn = Instantiate(cornPrefab) as GameObject;
                        corn.transform.position = new Vector3(4 * j, corn.transform.position.y, startPos);
                    }
                }
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j < 2; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くz軸のオフセットをランダムに設定
                        int offsetZ = Random.Range(0, 6);
                        //50%コイン配置、30%車配置、10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, startPos + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, startPos + offsetZ);
                        }
                    }
                }
            }
        }
    }
}

        

