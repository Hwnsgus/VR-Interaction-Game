using System.Collections.Generic;
using UnityEngine;

namespace JusticeScale.Scripts.Scales
{
    [RequireComponent(typeof(MeshCollider))]
    public class TriggerScale : Scale
    {
        [Tooltip("The total weight of the objects currently on this scale trigger.")]
        public override float TotalWeight => weight;

        // Container for objects detected by the scale
        private GameObject _objectContainer;

        // HashSet to track objects on the scale, ensuring each is only counted once
        private HashSet<Transform> _detectedObjects = new HashSet<Transform>();

        private void Start()
        {
            // Initialize the object container at the start
            _objectContainer = new GameObject("Objects Container");
            _objectContainer.transform.parent = transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            var rb = other.GetComponent<Rigidbody>();
            if (rb != null && IsInDetectableLayer(other.gameObject) && _detectedObjects.Add(rb.transform))
            {
                // 태그 기반으로 무게 설정
                float weightToAdd = GetWeightBasedOnTag(other.tag);
                weight += weightToAdd;

                AddObjectToContainer(rb.transform);
                weight = Mathf.Round(weight * 100f) / 100f;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var rb = other.GetComponent<Rigidbody>();
            if (rb != null && _detectedObjects.Remove(rb.transform))
            {
                // 태그 기반으로 무게 제거
                float weightToRemove = GetWeightBasedOnTag(other.tag);
                weight -= weightToRemove;

                // Ensure total weight doesn't drop below zero
                weight = Mathf.Max(0, weight);
                weight = Mathf.Round(weight * 100f) / 100f;

                RemoveObjectFromContainer(rb.transform);
            }
        }

        private float GetWeightBasedOnTag(string tag)
        {
            // 태그에 따라 무게를 설정
            switch (tag)
            {
                case "Car1": return 1.0f; // 가장 가벼운 무게
                case "Car2": return 2.0f;
                case "Car3": return 3.0f;
                case "Car4": return 4.0f;
                case "Car5": return 9.0f;
                case "Car6": return 15.0f; // 가장 무거운 무게
                default: return 0.0f; // 무게가 없는 태그
            }
        }

        private void AddObjectToContainer(Transform objectTransform)
        {
            if (_objectContainer == null)
            {
                // Create a new container for the objects if it doesn't exist
                _objectContainer = new GameObject("Objects Container");
                _objectContainer.transform.parent = transform;
            }

            // Set the parent of the object to the container
            objectTransform.SetParent(_objectContainer.transform, true);
        }

        private void RemoveObjectFromContainer(Transform objectTransform)
        {
            // Unparent the object from the container
            if (_objectContainer != null) objectTransform.parent = null;

            // Destroy the container if it has no child objects left
            if (_objectContainer.transform.childCount == 0) Destroy(_objectContainer);
        }

        private bool IsInDetectableLayer(GameObject obj)
        {
            // Check if the object is in the correct layer 
            return ((layerMask.value & (1 << obj.layer)) != 0);
        }
    }
}
