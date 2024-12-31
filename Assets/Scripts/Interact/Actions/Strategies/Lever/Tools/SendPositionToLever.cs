#if UNITY_EDITOR
using UnityEngine;

namespace Interact.Actions.Strategies.Lever.Tools
{
    public class SendPositionToLever : MonoBehaviour
    {
        private LeverMoveObject _leverMoveObject;
        
        public void Initialize(LeverMoveObject leverMoveObject)
        {
            _leverMoveObject = leverMoveObject;
        }
        
        public void SendStartPosition()
        {
            _leverMoveObject._SetStartPosition();
        }

        public void SendEndPosition()
        {
            _leverMoveObject._SetEndPosition();
        }
    }
}
#endif