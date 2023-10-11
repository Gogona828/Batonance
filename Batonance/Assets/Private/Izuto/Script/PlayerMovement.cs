using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f; // スピード変更
    // [SerializeField] private float jumpSpeed = 100.0f; // ジャンプ力変更
    // [SerializeField] private float gravity = 20.0f; // 重力変更
    // [SerializeField] private float maxHeight = 3.0f;// プレイヤーの高さの制限
    // [SerializeField] private float guardMagnification = 2.0f;
    private CharacterController PC;//(PlayerCharacter)
    private Vector3 moveDirection;// X・Y・Z軸(移動方向)を保持するための関数(.Zeroで0に指定)
    private float height;// プレイヤーの高さ
    // private bool isDefending = false; // ガードの判定
    [SerializeField]
    private GameObject playerModel;
    // [System.NonSerialized]
    public Animator animator;
    [SerializeField]
    private GameObject hpBarObj;
    private IDamagable hpBar;
    private Vector3 forward;
    private Vector3 right;
    [System.NonSerialized]
    public Vector3 facingReinforcement;
    private bool isWalk;
    private float latePos;
    private float velocity;
    [SerializeField]
    private float minVelocity;

    private PlayerGuard playerGuard;
    private PlayerAttack playerAtk;

    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<CharacterController>();
        playerGuard = GetComponent<PlayerGuard>();
        playerAtk = GetComponent<PlayerAttack>();
        moveDirection = Vector3.zero;
        // animator = playerModel.GetComponent<Animator>();
        hpBar = hpBarObj.GetComponent<IDamagable>();

        isWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        PCMove();
        height = transform.position.y;// プレイヤーの高さを取得する
        //if (height > maxHeight)// プレイヤーの高さを制限する
        //{
        //    Debug.Log("High");
        //    transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        //}

        /* {
            if (Input.GetMouseButtonDown(1))// 右クリックが押されたら防御開始
            {
                Debug.Log("Defending");
                isDefending = true;
            }

            if (Input.GetMouseButtonUp(1))// 右クリックが離されたら防御終了
            {
                isDefending = false;
            }
        } */
    }

    void PCMove()
    {
        // キャラクターの移動処理
        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        /*if (PC.isGrounded && !playerGuard.isGuard && !playerAtk.isAttack)
        {
            moveDirection = Vector3.zero;
            forward = Camera.main.transform.TransformDirection(Vector3.forward);
            right = Camera.main.transform.TransformDirection(Vector3.right);
            if (UsePCController.s_shouldUseCntl) {
                moveDirection += (Input.GetAxis("LStickX") * right + Input.GetAxis("LStickY") * forward).normalized;
            }
            else {
                moveDirection += (Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward).normalized;
            }

            moveDirection *= speed;

            if (UsePCController.s_shouldUseCntl && (Input.GetAxis("LStickX") != 0 || Input.GetAxis("LStickY") != 0))
            {
                facingReinforcement = moveDirection;
                facingReinforcement.y = 0;
                playerModel.transform.rotation = Quaternion.LookRotation(-facingReinforcement);
                isWalk = true;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            {
                facingReinforcement = moveDirection;
                facingReinforcement.y = 0;
                playerModel.transform.rotation = Quaternion.LookRotation(-facingReinforcement);
                isWalk = true;
            }
            else
            {
                if (Mathf.Abs(velocity) > minVelocity)
                {
                    animator.SetFloat("Walk", Mathf.Abs(velocity / Time.deltaTime));
                    animator.SetFloat("Walktest", velocity);
                    velocity = velocity / 2;
                }
                isWalk = false;
                return;
            }

            /* if (PC.isGrounded && Input.GetKeyDown(KeyCode.Space))//地面に接地かつSpaceキーの押された時
            {
                Debug.Log("Jump");
                animator.SetTrigger("Jump");
                moveDirection.y += jumpSpeed;
            } #1#
        }
        else if (playerGuard.isGuard || playerAtk.isAttack) {
            isWalk = false;
            return;
        }*/
        // velocity = ((transform.position.x + transform.position.z) / 2 - latePos);
        animator.SetFloat("Walk", 1/*Mathf.Abs(velocity / Time.deltaTime)*/);
        // latePos = (transform.position.x + transform.position.z) / 2;
        moveDirection.y += Physics.gravity.y * Time.deltaTime;// 重力の適用
        
        PC.Move(moveDirection * Time.deltaTime);// 移動の実行
        animator.SetBool("BoolWalk", isWalk);
    }

    //public float CalculateDamage(float damageAmount)// ダメージ計算時に呼ばれる関数
    //{
    //    if (isDefending)
    //    {
    //        // 防御中はダメージを半分にする
    //        return damageAmount / guardMagnification;
    //        DamageManager.instance.DamageCalculation(damageAmount,hpBar);
    //    }
    //    else
    //    {
    //        return damageAmount;
    //        DamageManager.instance.DamageCalculation(damageAmount,hpBar);
    //    }
    //}

    public void GetPlayerSpeed(float _spe)
    {
        speed = _spe;
    }
}
