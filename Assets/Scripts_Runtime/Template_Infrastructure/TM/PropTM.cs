using System;
using UnityEngine;


[CreateAssetMenu(fileName = "TM_Prop", menuName = "Template/TM_Prop")]
public class PropTM : ScriptableObject {

    public int typeID;
    [Header("istrigger")]
    public bool isEnter;
    public bool isObstacle;

    public bool isFigure;

    [Header("item")]
    public bool isGold;

    public bool bomb;

    public bool isKey;

    [Header("chest")]
    public bool isChest;

    public bool isLive;

    [Header("coin")]
    public bool isCoin;


    [Header("sprite")]
    public Sprite sprite;

    [Header("animation")]   

    public Animator animator;
}
