using System;
using UnityEngine;

public class PropEntity : MonoBehaviour {


    [SerializeField] Collider2D cld2D;

    [SerializeField] SpriteRenderer sprRd;

    public int id;

    public int typeID;
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