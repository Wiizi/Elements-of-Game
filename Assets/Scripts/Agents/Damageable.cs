using UnityEngine;

namespace Agents
{
    [RequireComponent(typeof(Agent))]
    public class Damageable : MonoBehaviour
    {
        public float MaxHealth;
        private float Health;

        private Agent agent;

        private void Awake()
        {
            this.agent = GetComponent<Agent>();
            Health = MaxHealth;
        }

        private void LateUpdate()
        {
            if (IsDestroyed())
            {
                Destroy(this.gameObject);
            }
        }

        public void TakeDamage(float damageAmount)
        {
            this.Health -= damageAmount;
        }

        public bool IsDestroyed()
        {
            return this.Health <= 0;
        }
    }
}