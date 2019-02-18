using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineEventSample : TimelineEventBase
{
    [SerializeField] Text debugText;

    public override void OnEnter(string track, EventPlayableAssetBase asset) {
        string str = "";
        str += "OnEnter: " + asset._name;
        if (asset is EventExtraPlayableAsset) {
            str += "_Type: " + ((EventExtraPlayableAsset)asset).contentType;
        }
        if (Application.isPlaying) {

        }
        //Debug.Log(str);
        debugText.text = track + " / " + str;
    }

    public override void OnExit(string track, EventPlayableAssetBase asset) {
        string str = "";
        str += "OnExit: " + asset._name;
        debugText.text = track + " / " + str;
    }
}
