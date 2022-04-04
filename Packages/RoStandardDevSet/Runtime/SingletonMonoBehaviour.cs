using System;
using UnityEngine;

namespace RoDevSet.Standard
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Type t = typeof(T);
                    instance = (T)FindObjectOfType(t);
                    if (instance == null)
                    {
                        var go = new GameObject(t.Name);
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            CheckInstance();
        }

        /// <summary>
        /// 他のGameObjectにアタッチされているか調べる。
        /// アタッチされている場合は自身を破棄する。
        /// </summary>
        /// <returns></returns>
        protected bool CheckInstance()
        {
            if (instance == null)
            {
                instance = this as T;
                return true;
            }

            if (Instance == this)
            {
                return true;
            }

            Destroy(this);
            return false;
        }
    }
}