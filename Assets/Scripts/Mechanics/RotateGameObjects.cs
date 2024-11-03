using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Mechanics
{
    public class RotateGameObjects : MonoBehaviour
    {
        [SerializeField] private RotateObjectSettings[] _rotateObjectSettings;
        private readonly Dictionary<Sides, float> _sides = new Dictionary<Sides, float>
        {
            [Sides.Right] = 90,
            [Sides.Left] = -90,
            [Sides.Up] = 180
        };

        private enum Sides
        {
            Up,
            Right,
            Left
        };

        public void RotateUp() => OnRotate(Sides.Up);
        public void RotateRight() => OnRotate(Sides.Right);
        public void RotateLeft() => OnRotate(Sides.Left);

        private void OnRotate(Sides side)
        {
            StopAllCoroutines();

            foreach (var rotateObject in _rotateObjectSettings)
            {
                StartCoroutine(SmoothRotate(_sides[side],
                    rotateObject.Object, rotateObject.SmoothDelta, rotateObject.MirroredRotation));
            }
        }
        
        private IEnumerator SmoothRotate(float angle, Transform target, float smoothDelta, bool mirroredRotation)
        {
            var finalAngle = target.rotation.eulerAngles.z + angle;
            finalAngle *= mirroredRotation ? -1 : 1;
            
            var newRotation = Quaternion.Euler(new Vector3(0, 0, finalAngle));
            
            var time = .0f;
            
            while (time < 1)
            {
                target.rotation = Quaternion.Slerp(target.rotation, newRotation, time);
                time += smoothDelta * Time.deltaTime;
                
                yield return null;
            }
            
            target.rotation = newRotation;
        }
        
        [Serializable]
        public class RotateObjectSettings
        {
            [SerializeField] private Transform _object;
            [SerializeField, Range(0, 1)] private float _smoothDelta = 0.3f;

            [SerializeField] private bool _mirroredRotation;

            public Transform Object => _object;
            public float SmoothDelta => _smoothDelta;
            
            public bool MirroredRotation => _mirroredRotation;
        }
    }
}