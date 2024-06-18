using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PA.WeaponSystem
{
	public class Weapon : MonoBehaviour
	{
		[SerializeField]
		List<AttackPatternSO> weapons;
		private int index = 0;
		[SerializeField]
		private AudioClip weaponSwap;

		public bool shootingDelayed;

		[SerializeField]
		private AttackPatternSO attackPattern;

		[SerializeField]
		private Transform shootingStartPoint;

		public GameObject projectile;
        //public AudioSource gunAudio;

        public List<GameObject> bullets = new List<GameObject>();
        Transform myTransform;
        public Transform desPos;
        public int shootingTime;
        public int bulletDamage;
        private GameObject notListedObject;
        public bool InsLock = false;
        public GameObject rangeColl;

        public void SwapWeapon()
		{
			index++;
			index = index >= weapons.Count ? 0 : index;
			attackPattern = weapons[index];
            rangeColl.GetComponent<CircleCollider2D>();
            //gunAudio.PlayOneShot(weaponSwap);
            

        }

		public void PerformAttack()
		{
			if (shootingDelayed == false)
			{
				shootingDelayed = true;
                Debug.Log("PerformAttack on ");
                //gunAudio.PlayOneShot(attackPattern.AudioSFX);
                bullets[0].gameObject.SetActive(true);
                bullets[0].GetComponent<Rigidbody2D>().AddForce(transform.right * 15, ForceMode2D.Impulse);
                bullets[0].transform.SetParent(null);
                notListedObject = bullets[0];
                notListedObject.GetComponent<BulletDamageHolder>().damage_Value = bulletDamage;

                bullets.RemoveAt(0);
                //GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
                attackPattern.Perform(shootingStartPoint);

				StartCoroutine(DelayShooting());
			}
		}

		private IEnumerator DelayShooting()
		{
            yield return new WaitForSeconds(attackPattern.AttackDelay);
            bullets.Add(notListedObject);
            notListedObject.transform.SetParent(desPos);
            notListedObject.transform.position = desPos.position;
            notListedObject.SetActive(false);
            PerformAttack();
            shootingDelayed = false;
		}
	}
}