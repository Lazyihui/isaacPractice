using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {


    [SerializeField] Rigidbody2D rb;

    [SerializeField] public Animator animatior;

    [SerializeField] SpriteRenderer sprRd;
    public float moveSpeed;

    // 每个人都有的
    public int id;

    public int typeID;

    // 二选一的
    public bool isRole;


    // 状态机
    public RoleFSMStatus status;

    public bool idle_isEntering;




    // 子弹的cd
    public float interval;

    public float intervalTimer;

    // Enmey1素材信息

    public int enmeny_1_Hp;


    public void Ctor() {

    }


    public void Move(Vector2 dir, float dt) {

        var velo = rb.velocity;
        velo = dir * moveSpeed;
        rb.velocity = velo;

    }

    public void Enter_Idle() {
        status = RoleFSMStatus.Idle;
        idle_isEntering = true;
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void SetSprite(Sprite sprite) {
        sprRd.sprite = sprite;
        // sprRd.color  = color;
    }

    public void SetColor() {
        if (RoleConst.PLAYER == typeID) {
            sprRd.color = Color.white;
        } else if (RoleConst.ENEMY_1 == typeID) {
            sprRd.color = Color.white;
        } else if (RoleConst.ENEMY_2 == typeID) {
            sprRd.color = Color.red;
        }

    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }

}

