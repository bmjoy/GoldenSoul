using UnityEngine;

namespace GS.Utils {
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> {
        static T _instance;

        public static T instance {
            get { return _instance; }
        }

        public static bool instanceExists { get { return _instance != null; } }

        protected virtual void Awake() {
            if (_instance != null)
                Destroy(gameObject);
            else
                _instance = (T) this;
        }

        void OnDestroy() {
            if (_instance == this)
                _instance = null;
        }
    }
}