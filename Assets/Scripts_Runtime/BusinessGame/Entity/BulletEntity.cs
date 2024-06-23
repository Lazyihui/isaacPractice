using System;
using UnityEngine;


public class BulletEntity : MonoBehaviour {

    public int id;

    [SerializeField] float moveSpeed = 1;

    public void Ctor() {

    }

    public void Move(Vector2 dir, float dt) {

        Vector2 pos = transform.position;
        pos += dir * moveSpeed * dt;
        transform.position = pos;
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }



}