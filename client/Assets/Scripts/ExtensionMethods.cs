using System.Collections.Generic;
using UnityEngine;

namespace PhantasticCasino
{
    static class ExtensionMethods
    {
        public static T[] GetClosestComponentsInChildren<T>(this Component c) where T : Component
        {
            return c.GetClosestComponentsInChildren<T>(false, true);
        }
        public static T[] GetClosestComponentsInChildren<T>(this Component c, bool includeInactive) where T : Component
        {
            return c.GetClosestComponentsInChildren<T>(includeInactive, true);
        }
        public static T[] GetClosestComponentsInChildren<T>(this Component c, bool includeInactive, bool includeSelf) where T : Component
        {
            Queue<Transform> toScan = new Queue<Transform>();
            List<T> result = new List<T>();
            Transform current = c.transform;

            if (includeSelf)
            {
                result.AddRange(current.GetComponents<T>());
            }
            do
            {
                foreach (Transform t in current)
                {
                    if (t.gameObject.activeSelf || includeInactive)
                    {
                        toScan.Enqueue(t);
                    }
                }
                if (toScan.Count == 0)
                {
                    break;
                }
                current = toScan.Dequeue();
                result.AddRange(current.GetComponents<T>());
            } while (toScan.Count > 0);

            return result.ToArray();
        }

        public static T GetClosestComponentInChildren<T>(this Component c) where T : Component
        {
            return c.GetClosestComponentInChildren<T>(false, true);
        }

        public static T GetClosestComponentInChildren<T>(this Component c, bool includeInactive) where T: Component
        {
            return c.GetClosestComponentInChildren<T>(includeInactive, true);
        }

        public static T GetClosestComponentInChildren<T>(this Component c, bool includeInactive, bool includeSelf) where T: Component
        {
            Transform current = c.transform;
            if (includeSelf && c.TryGetComponent(out T target))
            {
                return target;
            }
            foreach(Transform t in current)
            {
                if ((t.gameObject.activeSelf || includeInactive) && t.TryGetComponent(out T loopTarget))
                {
                    return loopTarget;
                }
            }
            return null;
        }
    }
}
