using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreGuard : MonoBehaviour
{
    [SerializeField, Tooltip("防御力")]
    private float defensePower;
    [SerializeField, Tooltip("ガードオブジェクト")]
    private GameObject guard;
    [SerializeField, Tooltip("ガード中かどうか")]
    public bool isGuard;
    /* [SerializeField, Tooltip("ガードのアニメーション")]
    private Animator animator; */

    // Start is called before the first frame update
    void Start()
    {
        guard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("SquareButton")) {
            Guard();
        }
        else {
            isGuard = false;
            guard.SetActive(false);
        }
    }

    private void Guard()
    {
        isGuard = true;
        guard.SetActive(true);
    }

    public float DamageDecrease(float _damage)
    {
        _damage -= defensePower;
        return _damage;
    }

    public void GetPlayerGuard(float _def)
    {
        defensePower = _def;
    }
}
