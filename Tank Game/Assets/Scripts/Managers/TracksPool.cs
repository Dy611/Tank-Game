using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Managers
{
    public class TracksPool : MonoBehaviour
    {
        /// <summary>
        /// Pooled List Of All Tracks In The Scene
        /// </summary>
        private static readonly List<TracksFade> tracks = new List<TracksFade>();

        /// <summary>
        /// The GameObject This Is Attached To
        /// </summary>
        private static GameObject trackPooler;

        private void Awake()
        {
            //Assign Object Instance
            trackPooler = gameObject;

            //Finds Any Precreated Tracks And Adds Them Into The List
            foreach (TracksFade track in Resources.FindObjectsOfTypeAll<TracksFade>())
            {
                tracks.Add(track);
                //Enables These Tracks To Be Usable
                track.canUse = true;
            }
        }

        //Clears Old References On Scene Change
        private void OnDisable()
        {
            tracks.Clear();
        }

        /// <summary>
        /// Looks For A Usable Track Inside List, Creates A New One If None Are Available
        /// </summary>
        /// <returns> Returns A Track </returns>
        public static TracksFade GetTrack()
        {
            //Looks Through Available Tracks
            for (int i = 0; i < tracks.Count; i++)
                if (tracks[i].canUse)
                    return tracks[i];

            //Creates A New Track Since None Currently Are Available
            return CreateAnotherTrack();
        }

        /// <summary>
        /// Creates A New GameObject And Makes It A Usable Track
        /// </summary>
        /// <returns> A Freshly Created GameObject And Track </returns>
        private static TracksFade CreateAnotherTrack()
        {
            //Creates A New GameObject And Increments The Name
            GameObject newTrack = new GameObject("Track" + (tracks.Count + 1));
            newTrack.transform.parent = trackPooler.transform;
            newTrack.AddComponent<SpriteRenderer>();
            //Adds The Track Fade Component And Adds This New Component To The Pool List
            TracksFade newFade = newTrack.AddComponent<TracksFade>();
            tracks.Add(newFade);
            //Returns The Fresh Track Fade Component
            return newFade;
        }
    }
}