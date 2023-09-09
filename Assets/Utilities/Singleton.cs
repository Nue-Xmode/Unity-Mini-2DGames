using UnityEngine;

namespace Utilitiees
{
    /// <summary>
    /// 单例模式基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour
        where T : Singleton<T>
    {
        [HideInInspector] public static T I;

        public virtual void Awake()
        {
            if (I == null)
                I = this as T;
            else
                Destroy(gameObject);
        }

        public virtual void OnDestroy()
        {
            if (I == this)
                I = null;
        }
    }
}