using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateInfra {

    public static void Load(TemplateContext ctx) {

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Prop";

            var ptr = Addressables.LoadAssetsAsync<PropTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.props.Add(go.typeID, go);
            }
            ctx.propPtr = ptr;
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_FigureElement";
            var ptr = Addressables.LoadAssetsAsync<FigureElementTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.figureEles.Add(go.typeID, go);
            }
            ctx.figurePtr = ptr;

        }

    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.propPtr.IsValid()) {
            Addressables.Release(ctx.propPtr);
        }
        if (ctx.figurePtr.IsValid()) {
            Addressables.Release(ctx.figurePtr);
        }
    }
}