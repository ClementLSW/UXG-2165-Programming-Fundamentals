using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment2
{

    //Task 5b: Bonus Attack Type (BONUS)
    //Complete AttackBonus to create a new attack pattern.
    //Inherit AttackStrategy base class and override the DoAttack function.
    //The attack should have a delay and a maximum distance (range).
    //You may add up to 1 prefab and 1 script to facilitate this attack.
    //Any prefab spawned MUST contain a class that inherits DamagerScript.
    //After completing this attack pattern, create a prefab variant of Guard
    //named GuardBonus and add this script as a component.
    //Replace GuardShoot_1 game object in A2Level1 scene with GuardBonus_1.
    //Task 5b START

    public class AttackBonus : AttackStrategy
    {
        [SerializeField] private GameObject prefab;
        PlayerScript player;
        float timer = 0.0f;

        private void Start()
        {
            player = FindObjectOfType<PlayerScript>();
        }

        public override void DoAttack()
        {
            StartCoroutine(BonusAttackSequence());
        }

        public IEnumerator BonusAttackSequence()
        {
            while(timer < delay)
            {
                timer += Time.fixedDeltaTime;
                yield return null;
            }
            Debug.Log("Actual Distance: " + Vector2.Distance(player.transform.position, transform.position).ToString() + ", Distance Limit:" + distance.ToString());
            if (Vector2.Distance(player.transform.position, transform.position) < distance)
            {
                player.TakeDamage(1);
            }
            Instantiate(prefab, transform.position, Quaternion.identity);

            yield break;
        }
    }

    //Task 5b END
}