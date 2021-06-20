using UnityEngine;

namespace TankGame.Profiles
{
    [CreateAssetMenu(menuName = "Tank Game/Create Input Profile")]
    public class InputProfile : ScriptableObject
    {
        [Header("Input Axis Names")]
        [Tooltip("Axis Name For Movement")]
        public string verticalAxis;
        [Tooltip("Axis Name For Rotating")]
        public string horizontalAxis;
        [Tooltip("Button Name For Firing")]
        public string shootButton;
    }
}