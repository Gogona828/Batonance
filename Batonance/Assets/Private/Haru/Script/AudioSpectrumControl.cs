using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumControl : MonoBehaviour
{
    public int debugint;//デバック用

    [SerializeField]
    private int[] angleList;//回転する角度を格納する配列
    public static AudioSpectrumControl instance;
    private void Awake()
    {
        //シングルトン
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I)) TurningSpectrum(0);//デバック用、左に傾ける
        //if (Input.GetKeyDown(KeyCode.N)) TurningSpectrum(1);//デバック用、真ん中にする
        //if (Input.GetKeyDown(KeyCode.S)) TurningSpectrum(2);//デバック用、右に傾ける
    }
    /// <summary>
    /// オーディオスペクタルムの長い部分を動かす。左、真ん中、右の三種。次に敵が出てくる方向に向ける。
    /// </summary>
    /// <param name="directionsIndex">敵が出てくる方向を入力する。左＝0、真ん中＝1、右＝2</param>
    public void TurningSpectrum(int directionsIndex)
    {
        transform.rotation = Quaternion.Euler(0, 0, angleList[directionsIndex]);
    }
}
