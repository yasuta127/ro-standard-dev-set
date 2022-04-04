using System.Collections.Generic;
using UnityEngine;

namespace RoStandardDevSet
{
    public static class UnityObjectUtil
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            return component != null ? component : gameObject.AddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            return GetOrAddComponent<T>(component.gameObject);
        }

        public static T InstantiateOf<T>(this T component) where T : Component
        {
            return Object.Instantiate(component.gameObject).GetComponent<T>();
        }

        public static T InstantiateOf<T>(this T component, Vector3 position, Quaternion rotation) where T : Component
        {
            return Object.Instantiate(component.gameObject, position, rotation).GetComponent<T>();
        }

        public static bool IsInLayerMask(this GameObject gameObject, LayerMask layerMask)
        {
            int objLayerMask = (1 << gameObject.layer);
            return (layerMask.value & objLayerMask) > 0;
        }

        public static GameObject[] FindGameObjectsWithLayerMask(LayerMask layerMask)
        {
            var allGameObjects = Object.FindObjectsOfType<GameObject>();
            var resultGameObjects = new List<GameObject>();
            foreach (GameObject go in allGameObjects)
            {
                if (go.IsInLayerMask(layerMask))
                {
                    resultGameObjects.Add(go);
                }
            }

            return resultGameObjects.Count == 0 ? null : resultGameObjects.ToArray();
        }
    }
}