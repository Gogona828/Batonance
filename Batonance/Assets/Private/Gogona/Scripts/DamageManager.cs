using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class DamageManager : MonoBehaviour
{
    // シングルトンのインスタンス
    static public DamageManager instance;
    [SerializeField]
    private GameObject playerHp;
    [SerializeField]
    private GameObject enemyHp;
    [SerializeField]
    private List<GameObject> enemyList;
    [SerializeField]
    private List<IDamagable> enemyDamageList = new List<IDamagable>();
    private IDamagable playerDamage;
    private IDamagable enemyDamage;
    /// <summary>
    /// インスタンスの生成
    /// </summary>
    private void Awake()
    {
        playerDamage = playerHp.GetComponent<IDamagable>();
        enemyDamage = enemyHp.GetComponent<IDamagable>();
        foreach (GameObject enemy in enemyList)
        {
            IDamagable enemyDamage = enemy.GetComponent<IDamagable>();
            enemyDamageList.Add(enemyDamage);
        }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// ダメージの処理
    /// </summary>
    public void DamageCalculation(float damage, IDamagable target)
    {
        Debug.Log($"ダメージ計算");
        Debug.Log($"ターゲット：" + target);
        target.Damage(damage);
    }

    /// <summary>
    /// 必殺技のダメージ処理
    /// </summary>
    public void SpecialMoveDamage(float damage)
    {
        Debug.Log($"必殺技の処理");
        foreach (IDamagable target in enemyDamageList)
        {
            target.Damage(damage);
        }
    }
}
