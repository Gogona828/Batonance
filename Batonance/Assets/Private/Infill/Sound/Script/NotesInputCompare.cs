using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
/// <summary>
/// 入力と譜面を比較して、差異を計算する
/// </summary>
public class NotesInputCompare : MonoBehaviour
{


    // Start is called before the first frame update
    private void Awake() {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int CompareTiming(float inputTime)
    {
        //0 = 良？とかでリスト化かenum化
        int result = 0;
        //どうしよっか（Listを小節数だけ生成してしまった方が、findをする必要はない
        //が、Listが冗長になる。逆に必要分だけにするなら、現在小節から最寄りのList位置を保存、計算する処理を毎発火ごとに行う必要がある？
        //結論：後回し。
        return result;
    }
}
