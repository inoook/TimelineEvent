using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// Timeline Inspectorに表示用
[TrackClipType(typeof(EventPlayableAssetBase))]
[TrackColor(1f, 0f, 0f)]
//[TrackBindingType(typeof(TimelineEventBase))] // 左側Trackでバインドするオブジェクト
public sealed class EventTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
        //var binding = go.GetComponent<PlayableDirector>().GetGenericBinding(this) as ScheduleActionBase;
        //Debug.LogError("CreateTrackMixer: "+ go + " / "+ graph + " / "+ binding);
        // 右側のTrack部分
        foreach (var c in GetClips()) {
            EventPlayableAssetBase clip = (EventPlayableAssetBase)c.asset;
            c.displayName = clip.GetEditorDisplayName();
        }

        Playable playable = ScriptPlayable<EventMixerBehaviour>.Create(graph, inputCount);
        //Playable playable = ScriptPlayable<SchedulePlayableBehaviour>.Create(graph, inputCount);

        return playable;
    }
}