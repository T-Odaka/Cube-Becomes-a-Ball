using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody player;
    BoxCollider boxCollider;
    JudgGround judgGround;
    Scene loadScene;
    private Vector3 playerMoveDirection;
    private Vector3 jump;
    Vector3 right;
    Vector3 left;
    private bool collisionOther;
    private bool touchingTheWallRight;
    private bool touchingTheWallLeft;
    private bool cantJump;
    [SerializeField] float playerMoveSpeed = 0;
    [SerializeField] float playerSphereSpeed = 0;
    [SerializeField] float jumpPower = 0;
    [SerializeField] float maxAngular = 0;
    [SerializeField] GameObject HUDTop = default;

    // 壁すり抜け防止用の距離
    [SerializeField] float rayMaxDistance = default;

    private bool isSphere = false;
    private bool onGrounded = false;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        player.maxAngularVelocity = maxAngular;
        judgGround = transform.GetChild(0).gameObject.GetComponent<JudgGround>();

        // シーンロード
        loadScene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        // // // // // // // //
        // 回転制御・移動制御
        // // // // // // // //
        onGrounded = judgGround.playerOnGround;

        // 変形するにはマウスボタンを押し続ける
        // 四角のときは回転が固定され、ジャンプが可能
        if (Input.GetKey(KeyCode.Mouse0))
        {
            boxCollider.enabled = false;

            // Z軸回転を有効化し、回転するようにする
            // 一度 None で全て無効化しないと制限できない
            player.constraints = RigidbodyConstraints.None;
            player.constraints = RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezePositionZ;
            isSphere = true;
        }

        else
        {
            // Z軸回転を無効化し、回転を制限する
            boxCollider.enabled = true;
            player.constraints = RigidbodyConstraints.None;
            player.constraints = RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezePositionZ;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            isSphere = false;
        }


        // TODO: BoxCastに置き換えて接触判定の精度を上げる
        // 壁抜け制御用にRayを飛ばす
        right = transform.TransformDirection(Vector3.right);
        left = transform.TransformDirection(Vector3.left);

        if (Physics.Raycast(transform.position, right, rayMaxDistance))
        {
            Debug.Log("接触判定" + touchingTheWallRight);
            touchingTheWallRight = true;
        }
        else
        {
            touchingTheWallRight = false;
        }

        if (Physics.Raycast(transform.position, left, rayMaxDistance))
        {
            touchingTheWallLeft = true;
        }
        else
        {
            touchingTheWallLeft = false;
        }

        // // // // //
        // 接地判定
        // // // // //

        // TODO: こちらもBoxcastに置き換え
        // bottom = transform.TransformDirection(Vector3.down);
        // if (Physics.CheckBox(transform.position, transform.localScale / 2))
        // {
        //     Debug.Log("接地テスト: true");
        // }


        // // // // // // // //
        // プレイヤー操作項目
        // // // // // // // //

        // シーンリロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(loadScene.name);
        }

        // ESC押したときにメニューを表示する
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HUDTop.SetActive(!HUDTop.activeSelf);
        }

        // CUBE のとき 
        if (isSphere == false)
        {

            if (Input.GetKey(KeyCode.A) && touchingTheWallLeft == false)
            {
                playerMoveDirection.x = -playerMoveSpeed;
                player.transform.Translate(playerMoveDirection);
            }

            if (Input.GetKey(KeyCode.D) && touchingTheWallRight == false)
            {
                playerMoveDirection.x = playerMoveSpeed;
                player.transform.Translate(playerMoveDirection);
            }

            // ジャンプ
            if (onGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jump.y = jumpPower;
                    player.AddForce(jump);
                    Debug.Log("ジャンプ可能");
                }
            }

        }

        // SPHERE のとき　※CUBEのときと球体のときでは動かし方が異なる

        else
        {
            if (collisionOther == true)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    playerMoveDirection.x = -playerSphereSpeed;
                    player.AddForce(playerMoveDirection);

                }

                if (Input.GetKey(KeyCode.D))
                {
                    playerMoveDirection.x = playerSphereSpeed;
                    player.AddForce(playerMoveDirection);
                }
            }
        }
    }

    // // // // //
    // 接触判定 
    // // // // //
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject)
        {
            collisionOther = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        collisionOther = false;
    }

    public bool JudgForm
    {
        get { return this.isSphere; }
    }
}
