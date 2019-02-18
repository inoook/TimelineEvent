using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExtraPlayableAsset : EventPlayableAssetBase
{
    public enum ContentType
    {
        A, B, C
    }

    public int additionalValue = 2;
    public ContentType contentType = ContentType.A;

    public override string GetLabel() {
        return "Mod: " + _name + "_" +contentType + "_" + additionalValue;
    }
}

