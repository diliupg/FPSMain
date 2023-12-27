 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision ObjectWeHit)
    {
        if(ObjectWeHit.gameObject.CompareTag("Target"))
        {
            print("Hit Target");

            createBulletImpactEffect(ObjectWeHit);

            Destroy(gameObject);
        }

        if(ObjectWeHit.gameObject.CompareTag("Wall"))
        {
            print("Hit wall");

            createBulletImpactEffect(ObjectWeHit);

            Destroy(gameObject);
        }

        if(ObjectWeHit.gameObject.CompareTag("Ground"))
        {
            print("Hit Ground");

            createBulletImpactEffect(ObjectWeHit);

            Destroy(gameObject);
        }               
    }

    void createBulletImpactEffect(Collision ObjectWeHit)
    {
        ContactPoint contact = ObjectWeHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
        );

        hole.transform.SetParent(ObjectWeHit.gameObject.transform);
    }
}
