
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

    public void AddElement(UIContext ctx, Sprite sp, int txt, int typeID) {
        Panel_FigureElement ele = GameObject.Instantiate(elePrefab, figureGroup);
        ele.typeID = typeID;
        ele.id = ctx.figureEleRecordID++;
        ctx.figureEleRespository.Add(ele);
        Init(sp, txt);
    }

    public void SetElementText(int typeID, int txt) {

        elePrefab.SetText(txt);
    }
    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }

}