using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Bullet", menuName = "Template/TM_Bullet")]

public class BulletTM : ScriptableObject {
    public float moveSpeed;

    public float intervalTimer;
    [Header("Player")]
    public bool isRoleBullet;

    public int typeID;

    public float moveDistance;

    public float maxDistance;


    [Header("Enemy")]
    public bool isEnemyBullet;

    [Header("Sprite")]

    public Sprite sprite;

}