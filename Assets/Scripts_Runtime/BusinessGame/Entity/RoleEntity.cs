using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {


    [SerializeField] Rigidbody2D rb;

    [SerializeField] public Animator animatior;
    [SerializeField] float moveSpeed = 1;


    public int id;

    public bool isRole;

    // 状态机
    public RoleFSMStatus status;

    public bool idle_isEntering;




    // 植物的cd
    public float cd;

    public float maxCd;

    public float maintain;

    public float maintainTimer;

    public float interval;

    public float intervalTimer;

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

    public void TearDown(){
        GameObject.Destroy(this.gameObject);
    }

}

