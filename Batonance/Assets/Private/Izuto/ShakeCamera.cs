using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    // 揺れのパラメータ
    public float shakeDuration = 0.5f;  // 揺れる時間
    public float shakeIntensity = 0.1f; // 揺れの強さ

    private float originalFOV; // 元の視野角
    private Camera mainCamera; // カメラ

    private void Start()
    {
        // カメラの取得と初期設定
        mainCamera = Camera.main;
        originalFOV = mainCamera.fieldOfView;
    }

    private void Update()
    {
        // スペースキーが押されたら揺れを開始
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartShake();
        }
    }

    // 揺れを開始するメソッド
    private void StartShake()
    {
        StartCoroutine(Shake());
    }

    // 揺れを実行するコルーチン
    private System.Collections.IEnumerator Shake()
    {
        float elapsedTime = 0f; // 経過時間

        // 指定した時間内に揺れる
        while (elapsedTime < shakeDuration)
        {
            // 視野をランダムに変化させることで揺れを表現
            mainCamera.fieldOfView = originalFOV + Random.Range(-1f, 1f) * shakeIntensity;

            // 経過時間を更新
            elapsedTime += Time.deltaTime;

            // 1フレーム待機
            yield return null;
        }

        // 揺れが終わったら視野を元に戻す
        mainCamera.fieldOfView = originalFOV;
    }
}
