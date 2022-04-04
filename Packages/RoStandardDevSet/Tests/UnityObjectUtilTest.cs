using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace RoDevSet.Standard.Tests
{
    public class UnityObjectUtilTest
    {
        [UnityTest]
        public IEnumerator UtilTest()
        {
            // Start前
            var go = new GameObject("TestObject");

            yield return null;
            // Start後

            FooMonoBehaviour fooMonoBehaviour = go.GetOrAddComponent<FooMonoBehaviour>();
            Assert.IsNotNull(fooMonoBehaviour);
            BarMonoBehaviour barMonoBehaviour = fooMonoBehaviour.GetOrAddComponent<BarMonoBehaviour>();
            Assert.IsNotNull(barMonoBehaviour);
            FooMonoBehaviour fooMonoBehaviour2 = go.GetOrAddComponent<FooMonoBehaviour>();
            FooMonoBehaviour fooMonoBehaviour3 = fooMonoBehaviour.GetOrAddComponent<FooMonoBehaviour>();
            Assert.AreEqual(fooMonoBehaviour, fooMonoBehaviour2);
            Assert.AreEqual(fooMonoBehaviour, fooMonoBehaviour3);

            var newInstanceFooMonoBehaviour = fooMonoBehaviour.InstantiateOf();
            Assert.IsNotNull(newInstanceFooMonoBehaviour);
            Assert.AreNotEqual(fooMonoBehaviour, newInstanceFooMonoBehaviour);
        }
    }
}