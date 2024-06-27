
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Figure : MonoBehaviour {

    [SerializeField] Panel_FigureElement elePrefab;

    [SerializeField] Transform figureGroup;
    public void Ctor() {

    }

    public void Init(Sprite sp, int txt) {
        this.elePrefab.Init(sp, txt);
    }

    public void AddElement(Sprite sp, int txt) {
        Panel_FigureElement ele = GameObject.Instantiate(elePrefab, figureGroup);
        ele.Init(sp, txt);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }

}