using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// clip
[System.Serializable]
public class EventPlayableAssetBase : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps {
        get { return ClipCaps.None; } // blendの仕方
    }

    // 通常の Inspector に表示される。
    [SerializeField] public string clipName = "clip";
    [SerializeField] public bool enableProcessEvent = false;

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        //Debug.LogError("CreatePlayable: "+ graph.ToString() + " / "+ owner);
        var behaviour = new EventPlayableBehaviour();
        behaviour.asset = this;

        TimelineEventBase timelineEventBase = owner.GetComponent<TimelineEventBase>();
        if (timelineEventBase != null) {
            behaviour.owner = timelineEventBase;
        } else {
            Debug.LogWarning("Add TimelineEventBase component to PlayableDirector.");
        }

        Playable playable = ScriptPlayable<EventPlayableBehaviour>.Create(graph, behaviour);

        return playable;
    }

    public virtual string GetEditorDisplayName() {
        return "clip: "+clipName;
    }
}
