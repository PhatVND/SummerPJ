    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public int damage = 50;
    public GameObject impactEffect;
    public bool isSpecial = false;




    public void Seek(Transform target)
        {
            this.target = target;
        }


        void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;

            }
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
        transform.LookAt(target);
        }
        void HitTarget()
        {
           GameObject effectIns = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 5f);

            if (explosionRadius > 0f)
        {
            Explode();
        }
            else
        {
            Damage(target);
        }
         Destroy(gameObject);
        }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); 
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    private void Damage(Transform enemy)
    {
       Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);   
        }

        if (isSpecial)
        {
            if (e.isBoss)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, 2500);
                foreach (Collider collider in colliders)
                {

                    if (collider.tag == "BossChild")
                    {
                        Damage(collider.transform);
                    }
                }
            }
        }

    

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        Gizmos.color = Color.red;
    }
}