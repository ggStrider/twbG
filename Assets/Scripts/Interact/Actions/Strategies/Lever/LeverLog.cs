using UnityEngine;

namespace Interact.Actions.Strategies.Lever
{
    public class LeverLog : MonoBehaviour, ILeverAction
    {
        public void Activated()
        {
            Debug.Log("Activated");
        }

        public void Deactivated()
        {
            Debug.Log("Deactivated");
        }
    }
}