﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineEventBase : MonoBehaviour
{
    public virtual void OnEnter(string track, EventPlayableAssetBase asset) {
        Debug.LogWarning("OnEnter: " + track + " / "+asset._name);

    }
    public virtual void OnExit(string track, EventPlayableAssetBase asset) {
        Debug.LogWarning("OnExit: " + track + " / " + asset._name);
    }
}