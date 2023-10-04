using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlay : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    private BGMManager bgmManager;
    // Start is called before the first frame update
    void Awake()
    {
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AddSubjectListener();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySE()
    {
        audioSource.PlayOneShot(audioSource.clip);
        Debug.Log("SE再生");
    }

    /// <summary>
    /// BGMの発信を購読する場合の登録。同様にbgmManagerに対してAddListenerで発火スクリプトを設定すること。
    /// </summary>
    public void AddSubjectListener()
    {
        bgmManager.subject.AddListener(PlaySE);
    }
}
