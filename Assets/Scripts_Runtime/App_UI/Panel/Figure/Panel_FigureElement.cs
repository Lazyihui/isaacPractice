using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_FigureElement : MonoBehaviour {

    [SerializeField] Image img;

    [SerializeField] Text txt;

    public void Ctor() {

    }
    public void Init(Sprite Sp, int txt) {
        this.img.sprite = Sp;
        this.txt.text = txt.ToString();
    }
}