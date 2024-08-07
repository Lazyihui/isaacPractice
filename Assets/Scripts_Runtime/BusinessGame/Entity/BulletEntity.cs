using System;
using UnityEngine;
using UnityEngine.UI;


public class BulletEntity : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;

    [SerializeField] SpriteRenderer sprRd;
    public int id;

    public float moveSpeed;

    // 上下左右 0=dowm 1=up 2=left 3=right
    public int dir_player;

    public float moveDistance;

    public float maxDistance;

    public float intervalTimer;

    public bool isRoleBullet;
    public bool isEnemyBullet;

    public Vector2 dir_Enmeny1;


    public void Ctor() {
        dir_Enmeny1 = Vector2.zero;
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

    public void SetSprite(Sprite sprite) {
        sprRd.sprite = sprite;
    }


    public void TearDown() {
        GameObject.Destroy(gameObject);
    }



}