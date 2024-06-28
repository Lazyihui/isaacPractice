using System;
using System.Collections.Generic;


public class FigureEleRespository {

    Dictionary<int, Panel_FigureElement> all;

    Panel_FigureElement[] temArray;

    public FigureEleRespository() {
        all = new Dictionary<int, Panel_FigureElement>();
        temArray = new Panel_FigureElement[5];
    }

    public void Add(Panel_FigureElement entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(Panel_FigureElement entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out Panel_FigureElement[] array) {
        if (all.Count > temArray.Length) {
            temArray = new Panel_FigureElement[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out Panel_FigureElement entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<Panel_FigureElement> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }


}