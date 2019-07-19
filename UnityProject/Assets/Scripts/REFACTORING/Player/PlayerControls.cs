using UnityEngine;
using GS.Utils;

namespace GS.Player {
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(PlayerController))]
    public class PlayerControls : Singleton<PlayerControls> {
        Vector2 currentVelocity = Vector2.zero;
        public float accelerationMultiplier = 2;

        PlayerController player;
        new Transform transform;
        new Rigidbody2D rigidbody;

        protected override void Awake() {
            base.Awake();
            player = GetComponent<PlayerController>();
            transform = base.transform;
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Start() {
            Debug.Log("im alive");
        }

        private void Update() {
            currentVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            player.anim.SetInteger("vector",5);

            if (currentVelocity.x > 0)
            {
                player.anim.SetInteger("vector", 3);
            }
            else if (currentVelocity.x < 0)
            {
                player.anim.SetInteger("vector", 1);
            }
            else if (currentVelocity.y > 0)
            {
                player.anim.SetInteger("vector", 2);
            }
            else if (currentVelocity.y < 0)
            {
                player.anim.SetInteger("vector", 4);
            }
        }

        void FixedUpdate() //Physics code
        {
            rigidbody.velocity = transform.TransformDirection(currentVelocity.normalized * 3f);
        }
    }
}