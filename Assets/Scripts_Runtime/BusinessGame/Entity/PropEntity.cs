using System;
using UnityEngine;

public class PropEntity : MonoBehaviour {

    // 0 enter 1 obstacle

    [SerializeField] Collider2D cld2D;

    [SerializeField] SpriteRenderer sprRd;

    [SerializeField] Rigidbody2D rb2D;


    public int id;

    public int typeID;

    // 1 表示上面 2 表示下面 3 表示左边 4 表示右边
    public int nextLevelID;

    //这里区分是不是触发器
    // 入口
    public bool isEnter;

    // 障碍
    public bool isObstacle;
    
    //istrigger 
    public bool isFigure;
    //这里区分是不是触发器

    // 是什么种类
    public bool isGold;

    public bool bomb;

    public bool isKey;

    public bool isChest;

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

    public void SetRigidbody(RigidbodyType2D type) {
        rb2D.bodyType = type;
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;

    }
    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }


}