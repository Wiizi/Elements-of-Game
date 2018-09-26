using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Environments;
using UnityEngine;

namespace Agents
{
    public enum AttackType
    {
        MeeleAll,
        MeeleClosest
    }
    
    [RequireComponent(typeof(Agent))]
    public class Attack : MonoBehaviour
    {
        public float Range;
        public float Damage;
        public float Cooldown;
        public AttackType Type;

        private Agent agent;

        private float TimeAtLastAttack;
        
        private void Awake()
        {
            TimeAtLastAttack = Time.time - Cooldown;
            this.agent = GetComponent<Agent>();            
        }

        public void Update()
        {
            float time = Time.time;
            if (time - TimeAtLastAttack > Cooldown)
            {
                List<Damageable> damageables = new List<Damageable>();
                List<Collider> colliders = Physics.OverlapSphere(this.transform.position, Range).ToList();
                Debug.Log("GOT colliders" + colliders.Count);
                
                foreach (var collider in colliders)
                {
                    damageables.AddRange(collider.gameObject.GetComponents<Damageable>());
                    damageables.AddRange(collider.gameObject.GetComponentsInParent<Damageable>());
                    damageables.AddRange(collider.gameObject.GetComponentsInChildren<Damageable>());
                }

                Debug.Log("GOT damageables " + damageables.Count);
                if (damageables.Count > 0)
                {
                    if (Type == AttackType.MeeleAll)
                        foreach (var damageable in damageables)
                        {
                            ApplyDamage(damageable);
                        }
                    else if (Type == AttackType.MeeleClosest)
                    {
                        Damageable closest = damageables[0];
                        float closestDistance = float.MaxValue;
                        foreach (var damageable in damageables)
                        {
                            float distance = Vector3.Distance(closest.gameObject.transform.position,
                                this.transform.position);
                            if (distance < closestDistance)
                            {
                                closest = damageable;
                                closestDistance = distance;
                            }
                        }
                        ApplyDamage(closest);
                    }
                }
            }
        }

        public void ApplyDamage(Damageable damageable)
        {
            Debug.Log("DAMAGING!!!");
            if (Vector3.Distance(damageable.transform.position, transform.position) < Range)
                damageable.TakeDamage(Damage);
        }
    }
}