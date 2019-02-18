﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public sealed class EventPlayableBehaviour : PlayableBehaviour
{
    public EventPlayableAssetBase asset;
    public TimelineEventBase owner;

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        //Debug.Log("OnGraphStart: ");
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        //Debug.Log("OnGraphStop: ");
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        //var resolver = playable.GetGraph().GetResolver();
        // track 
        EventTrack track = (EventTrack)info.output.GetReferenceObject();
        owner.OnEnter(track.name, asset);
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        EventTrack track = (EventTrack)info.output.GetReferenceObject();
        owner.OnExit(track.name, asset);
    }

    // Called each frame while the state is set to Play
    //public override void PrepareFrame(Playable playable, FrameData info)
    //{
        
    //}
}
