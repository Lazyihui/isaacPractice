using System;
using UnityEngine;

public class PropEntity : MonoBehaviour {


    [SerializeField] Collider2D cld2D;

    [SerializeField] SpriteRenderer sprRd;


    public int id;

    public int typeID;

    // 1 表示上面 2 表示下面 3 表示左边 4 表示右边
    public int nextLevelID;
    // 入口
    public bool isEnter;

    // 障碍
    public bool isObstacle;


    public void Ctor() {
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void SetCollider(bool isTrigger) {
        cld2D.isTrigger = isTrigger;
    }

    public void SetSprite(Sprite sprite) {
        sprRd.sprite = sprite;
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }


}