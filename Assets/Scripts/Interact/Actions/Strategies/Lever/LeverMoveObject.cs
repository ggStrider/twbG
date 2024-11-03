using UnityEngine;

namespace Interact.Actions.Strategies.Lever
{
    public class LeverMoveObject : MonoBehaviour, ILeverAction
    {
        public void Activated()
        {
            Debug.Log("real");
        }

        public void Deactivated()
        {
            Debug.Log("realreal2");
        }
    }
}