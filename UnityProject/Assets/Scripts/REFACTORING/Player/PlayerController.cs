using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
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
        public Rigidbody2D rigidbody;
        public Animator anim;

        void Awake() {
            healthBar = GetComponent<Health>();
            rigidbody = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void FixedUpdate() {
            if (healthBar.health <= 0) onGameOver.Invoke();
        }
    }
    
}