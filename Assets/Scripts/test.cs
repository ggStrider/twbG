using UnityEngine;
using System.Collections;

namespace Mechanics
{
    public class test : MonoBehaviour
    {
        [SerializeField] private SmoothRotateSettings[] _smoothRotateSettings;
        [SerializeField] private Transform _buttonsParent;

        private Coroutine[] _activeSmoothCoroutine = new Coroutine[10];

        public void OnRotate(float zDelta)
        {
            var rotationVector = new Vector3(0, 0, zDelta);
            var rotateQuaternion = Quaternion.Euler(rotationVector);

            if (_smoothRotateSettings[0].Object.rotation == rotateQuaternion) return;

            for (var i = 0; i < _activeSmoothCoroutine.Length; i++)
            {
                if(_activeSmoothCoroutine[i] != null)
                    StopCoroutine(_activeSmoothCoroutine[i]);
            }

            for (byte i = 0; i < _smoothRotateSettings.Length; i++)
            {
                _activeSmoothCoroutine[i] = StartCoroutine(SmoothRotate(rotateQuaternion, 
                _smoothRotateSettings[i].Object, _smoothRotateSettings[i].SmoothRotateTime, i));
            }

            rotateQuaternion.z *= -1;
            _buttonsParent.rotation = rotateQuaternion;

        }

        private IEnumerator SmoothRotate(Quaternion rotation, Transform rotateObject, float rotateTime,  byte coroutineIndex)
        {
            var startRotation = rotateObject.rotation;
            var elapsedTime = 0.0f;

            while (elapsedTime < rotateTime)
            {
                rotateObject.rotation = Quaternion.Slerp(startRotation, rotation, elapsedTime / rotateTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rotateObject.rotation = rotation;
            _activeSmoothCoroutine[coroutineIndex] = null;
        }

        [System.Serializable]
        public class SmoothRotateSettings
        {
            [SerializeField] private Transform _object;
            [SerializeField] private float _smoothRotateTime = 0.3f;

            public Transform Object => _object;
            public float SmoothRotateTime => _smoothRotateTime;
        }
    }
}