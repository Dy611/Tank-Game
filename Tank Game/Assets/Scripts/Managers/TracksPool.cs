using System.Collections.Generic;
using UnityEngine;

public class TracksPool : MonoBehaviour
{
    private static readonly List<TracksFade> tracks = new List<TracksFade>();
    private static GameObject trackPooler;

    private void Awake()
    {
        trackPooler = gameObject;
        foreach(TracksFade track in Resources.FindObjectsOfTypeAll<TracksFade>())
        {
            tracks.Add(track);
            track.canUse = true;
        }
    }

    public static TracksFade GetTrack()
    {
        for(int i = 0; i < tracks.Count; i++)
            if(tracks[i].canUse)
                return tracks[i];

        return CreateAnotherTrack();
    }

    private static TracksFade CreateAnotherTrack()
    {
        GameObject newTrack = new GameObject("Track" + (tracks.Count + 1));
        newTrack.transform.parent = trackPooler.transform;
        newTrack.AddComponent<SpriteRenderer>();
        TracksFade newFade = newTrack.AddComponent<TracksFade>();
        tracks.Add(newFade);
        return newFade;
    }
}