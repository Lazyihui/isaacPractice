using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Role", menuName = "Template/TM_Role")]

public class RoleTM : ScriptableObject {
    public int typeID;
    public float moveSpeed;

    public float interval;

    public float intervalTimer;

    [Header("Enemy_1")]

    
    public bool isEnemy_1;

    public float enmeny_1_Hp;

    public  float enemy_Maxhp;
    [Header("Role")]


    public bool isRole;


    // public int qqq;
    [Header("Animator")]

    public RuntimeAnimatorController animator;

    public Sprite sprite;

    // public Color color;


}