using System;
using UnityEngine;
using UnityEngine.UI;

public class RoleEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float moveSpeed = 1;


    public int id;

    public bool isRole;



    public RoleEntity() { }

    public void Ctor() {

    }

    public void Move(Vector2 dir,float dt) {

        // var velo = rb.velocity;
        // velo = dir * moveSpeed;
        // rb.velocity = velo;
        // Debug.Log(dir); 

        Vector2 pos = transform.position;
        pos += dir * moveSpeed * dt;
        transform.position = pos;
    }



}

