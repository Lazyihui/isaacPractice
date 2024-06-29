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

    public bool isChest;

    public Sprite sprite;

}
