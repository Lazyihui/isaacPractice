using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_FigureElement : MonoBehaviour {

    [SerializeField] Sprite sp;

    [SerializeField] Text txt;

    public void Ctor() {

    }
    public void Init(Sprite Sp, int txt) {
        this.sp = Sp;
        this.txt.text = txt.ToString();
    }
}