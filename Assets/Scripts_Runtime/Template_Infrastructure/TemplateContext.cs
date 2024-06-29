using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateContext {

    public Dictionary<int, PropTM> props;

    public AsyncOperationHandle propPtr;

    public Dictionary<int, FigureElementTM> figureEles;

    public AsyncOperationHandle figurePtr;


    public Dictionary<int, RoleTM> roles;

    public AsyncOperationHandle rolePtr;    
    public TemplateContext() {
        props = new Dictionary<int, PropTM>();
        figureEles = new Dictionary<int, FigureElementTM>();
        roles = new Dictionary<int, RoleTM>();
    }

}