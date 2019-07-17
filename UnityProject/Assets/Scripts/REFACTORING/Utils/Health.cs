using UnityEngine;

namespace GS.Utils {
    public class Health : MonoBehaviour {
        public float health;
        protected float lastHealth;
        public float maxHealth, healthRegen, extraRegenTimeout, extraRegen;

        float nextExtraRegen;

        protected virtual void FixedUpdate() {
            if (lastHealth != health) {
                if (IsExtraRegenEnabled()) nextExtraRegen = Time.time + extraRegenTimeout;
                lastHealth = health;
            }

            if (IsRegenEnabled() || IsExtraRegenEnabled()) {
                float now = Time.time;
                bool isExtraRegen = IsExtraRegenEnabled() && now >= nextExtraRegen;

                if (health < maxHealth) {
                    float healthPerSecond = isExtraRegen ? extraRegen : healthRegen;
                    float regen = Mathf.Min(maxHealth * healthPerSecond * Time.deltaTime, maxHealth - health);
                    health = lastHealth += regen;
                } else if (IsExtraRegenEnabled()) {
                    nextExtraRegen = Time.time + extraRegenTimeout;
                }
            }
        }

        bool IsRegenEnabled() {
            return healthRegen > 0;
        }

        bool IsExtraRegenEnabled() {
            return extraRegenTimeout > 0 && extraRegen > 0;
        }
    }
}