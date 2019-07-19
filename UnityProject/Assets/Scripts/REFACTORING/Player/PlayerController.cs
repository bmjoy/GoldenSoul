using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using IngameDebugConsole;
using GS.Utils;

namespace GS.Player {
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Health))]
    public class PlayerController : MonoBehaviour {
        [HideInInspector]
        public int kills;

        public UnityEvent onGameOver;

        [HideInInspector]
        public Health healthBar;
        [HideInInspector]
        public Rigidbody2D rigidbody;
        [HideInInspector]
        public Animator anim;

        void Awake() {
            healthBar = GetComponent<Health>();
            rigidbody = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Start() {
            DebugLogConsole.AddCommandInstance( "heal", "Set health", "HealCMD", this );    
        }

        void FixedUpdate() {
            if (healthBar.health <= 0) onGameOver.Invoke();
        }

        protected void HealCMD(int value = 100)
        {
            healthBar.health = value;
            Debug.Log("New HP is " + healthBar.health);
        }
    }
    
}