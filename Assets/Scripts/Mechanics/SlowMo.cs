using UnityEngine;

namespace Mechanics
{
    public class SlowMo : MonoBehaviour
    {
        [SerializeField] private float _slowMoEffect;
                
        private const byte NORMAL_TIME_SCALE = 1;
        private const float NORMAL_FIXED_TIME = 0.02f;

        public void ToggleSlowMo(bool isSlowMo)
        {
            var timeScale = isSlowMo ? Time.timeScale *= _slowMoEffect: NORMAL_TIME_SCALE;
            var fixedTime = isSlowMo ? Time.fixedDeltaTime *= _slowMoEffect : NORMAL_FIXED_TIME;
            
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = fixedTime;
        }
    }
}
