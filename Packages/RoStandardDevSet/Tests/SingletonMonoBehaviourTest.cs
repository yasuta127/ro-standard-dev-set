using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace RoDevSet.Standard.Tests
{
    public class SingletonMonoBehaviourTest
    {
        [UnityTest]
        public IEnumerator Test()
        {
            SampleSingletonMonoBehaviour monoBehaviour1 = SampleSingletonMonoBehaviour.Instance;
            Assert.IsNotNull(monoBehaviour1);
            Debug.Log(monoBehaviour1.gameObject.name);
            Assert.AreEqual(monoBehaviour1.gameObject.name, nameof(SampleSingletonMonoBehaviour));

            GameObject go = new GameObject();
            SampleSingletonMonoBehaviour monoBehaviour2 = go.AddComponent<SampleSingletonMonoBehaviour>();
            Assert.IsNotNull(monoBehaviour2);
            yield return null;
            Assert.IsNull(monoBehaviour2);
        }
    }
}