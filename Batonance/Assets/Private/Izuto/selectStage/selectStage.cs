using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class selectStage : MonoBehaviour
{
    public Button Stage1;
    public Button Stage2;
    public Button Stage3;

    // Start is called before the first frame update
    void Start()
    {
        // 最初に選択状態にしたいボタンの設定
        Stage1.Select();
    }
}
