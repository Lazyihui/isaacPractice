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
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Role";
            var ptr = Addressables.LoadAssetsAsync<RoleTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.roles.Add(go.typeID, go);
            }
            ctx.rolePtr = ptr;

        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "TM_Bullet";
            var ptr = Addressables.LoadAssetsAsync<BulletTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.bullets.Add(go.typeID, go);
            }
            ctx.bulletPtr = ptr;

        
        }

    }

    public static void Unload(TemplateContext ctx) {
        if (ctx.propPtr.IsValid()) {
            Addressables.Release(ctx.propPtr);
        }
        if (ctx.figurePtr.IsValid()) {
            Addressables.Release(ctx.figurePtr);
        }
        if (ctx.rolePtr.IsValid()) {
            Addressables.Release(ctx.rolePtr);
        }
        if(ctx.bulletPtr.IsValid()) {
            Addressables.Release(ctx.bulletPtr);
        }
    }
}