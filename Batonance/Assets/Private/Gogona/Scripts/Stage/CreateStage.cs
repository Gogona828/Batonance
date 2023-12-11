using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateStage : MonoBehaviour
{

    // 置かれているステージ
    public List<GameObject> placedStages;
    // ステージの生成位置
    private Vector3 stageGenerationPosition;
    // 置くステージの数
    private int putStageNum;
    // 生成したステージ
    private GameObject generatedStage;
    // ステージのオフセット
    private Vector3 offset = new Vector3(0, 0, 9.5f);
    //内野追記
    //全てのステージを保存するスクリプト
    public List<GameObject> fieldList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        putStageNum = placedStages.Count;
        stageGenerationPosition = new Vector3(0, 0, (putStageNum-1) * 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (placedStages.Count < putStageNum) AddStage();
    }
    
    /// <summary>
    /// ステージを追加する
    /// </summary>
    private void AddStage()
    {
        generatedStage = Instantiate(fieldList[Random.Range(0,fieldList.Count)], stageGenerationPosition, Quaternion.identity, gameObject.transform);
        generatedStage.transform.position = placedStages[placedStages.Count - 1].transform.position + offset;
        placedStages.Add(generatedStage);
    }
}
