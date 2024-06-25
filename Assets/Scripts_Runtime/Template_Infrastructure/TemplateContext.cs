using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateContext {

    public Dictionary<int, PropTM> props;

    public AsyncOperationHandle propPtr;

    public TemplateContext() {
        props = new Dictionary<int, PropTM>();
    }

}