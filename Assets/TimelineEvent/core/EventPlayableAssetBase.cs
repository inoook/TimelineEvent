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
    
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var behaviour = new EventPlayableBehaviour();
        behaviour.asset = this;
        behaviour.owner = owner.GetComponent<TimelineEventBase>();

        Playable playable = ScriptPlayable<EventPlayableBehaviour>.Create(graph, behaviour);

        return playable;
    }

    public virtual string GetEditorDisplayName() {
        return "clip: "+clipName;
    }
}
