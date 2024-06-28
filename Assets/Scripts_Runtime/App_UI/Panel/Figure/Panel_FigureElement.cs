using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_FigureElement : MonoBehaviour {

    [SerializeField] Image img;

    [SerializeField] Text txt;
    public int id;

    public int typeID;
    public void Ctor() {

    }
    public void Init(Sprite Sp, int txt) {
        this.img.sprite = Sp;
        this.txt.text = txt.ToString();
    }

    public void SetText(int txt) {
        this.txt.text = txt.ToString();
    }

}