using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int currentHealth = 10;

        public UnityEvent OnTakeDamage = new UnityEvent(); // Optional
        public UnityEvent OnZeroHealth = new UnityEvent(); // Optional

        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            // Update the health of whatever GameObject this script is attached to.
            ValueDisplay.OnValueChanged.Invoke(gameObject.name + "Health", currentHealth);
            OnTakeDamage.Invoke();

            if (currentHealth <= 0)
            {
                OnZeroHealth.Invoke(); // Optional
                Destroy(gameObject);
            }

        }

        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health health = target.GetComponent<Health>();

            if (health) health.TakeDamage(damageAmount);
        }
    }
}
