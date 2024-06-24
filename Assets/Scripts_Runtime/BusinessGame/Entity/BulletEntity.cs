using System;
using UnityEngine;
using UnityEngine.UI;


public class BulletEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;

    public int id;

    [SerializeField] public float moveSpeed = 0.5f;

    // 上下左右 0=dowm 1=up 2=left 3=right
    public int dir;

    public float moveDistance;

    public float maxDistance;

    public float intervalTimer;


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

    public void SetRB(RigidbodyType2D type) {
        rb.bodyType = type;
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }



}