using System;
using UnityEngine;


public class BulletEntity : MonoBehaviour {

    public int id;

    [SerializeField] float moveSpeed = 0.5f;

    // 上下左右 0=dowm 1=up 2=left 3=right
    public int dir;

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

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }



}