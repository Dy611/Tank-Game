using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Input Profile")]
    public class InputProfile : ScriptableObject
    {
        public string verticalAxis;
        public string horizontalAxis;
        public string shootButton;
    }
}