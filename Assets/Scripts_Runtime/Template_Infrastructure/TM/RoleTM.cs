using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TM_Role", menuName = "Template/TM_Role")]

public class RoleTM : ScriptableObject {

    [Header("bool")]
    
    public bool isEnemy_1;


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



}