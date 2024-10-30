using UnityEditor;
using UnityEngine;

using System.Collections.Generic;
using Tools;

namespace CheckEnvironment
{
    public class GetObjectsInRange : MonoBehaviour
    {
        [SerializeField] private float _radius = 1f;
        private readonly Collider2D[] _interactionResult = new Collider2D[10]; 

        public GameObject[] GetObjects()
        {
            var size = Physics2D.OverlapCircleNonAlloc(
                transform.position, _radius, _interactionResult);
            
            var overlaps = new List<GameObject>();

            for(var i = 0; i < size; i++)
            {
                overlaps.Add(_interactionResult[i].gameObject);
            }
            return overlaps.ToArray();
        }

        #if UNITY_EDITOR
        private void OnDrawGizmosSelected() 
        {
            Handles.color = HandlesColors.TransparentRed;
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);    
        }
        #endif
    }
}