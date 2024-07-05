using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Role", menuName = "Template/TM_Role")]

public class RoleTM : ScriptableObject {

    [Header("Enemy_1")]

    
    public bool isEnemy_1;

    public int enmeny_1_Hp;
    [Header("Role")]

    public int typeID;

    public bool isRole;

    public float moveSpeed;

    public float interval;

    public float intervalTimer;

    // public int qqq;
    [Header("Animator")]

    public RuntimeAnimatorController animator;

    public Sprite sprite;

    // public Color color;


}