using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ally))]
public class AllyMovement1 : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public float range = 15f;
    private Transform target;
    private Transform aim;
    private int wavepointIndex = 0;

    private Ally ally = null;
    private Enemy targetEnemy;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    void Start()
    {
        ally = GetComponent<Ally>();

        target = AllyWaypoints.points[0];

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            aim = nearestEnemy.transform;
        }
        else
        {
            aim = null;
        }

    }

    void Update()
    {
        if (aim != null)
        {
            
            if (!ally.walking)
            {
                ally.anim.SetBool("IsWalking", ally.walking);
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }

                fireCountdown -= Time.deltaTime;
            }
            else
            {
                Vector3 dir = aim.position - transform.position;
                transform.Translate(dir.normalized * ally.speed * Time.deltaTime, Space.World);
                ally.transform.LookAt(aim);
                ally.walking = true;
                ally.anim.SetBool("IsWalking", ally.walking);
                if (Vector3.Distance(transform.position, aim.position) <= range)
                {

                    ally.walking = false;
                }
                ally.speed = ally.startSpeed;
            }
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * ally.speed * Time.deltaTime, Space.World);
            ally.transform.LookAt(target);
            ally.walking = true;
            ally.anim.SetBool("IsWalking", ally.walking);
            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }

            ally.speed = ally.startSpeed;
        }
        
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            ally.anim.SetTrigger("Attack");
            bullet.Seek(aim);
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= AllyWaypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = AllyWaypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        EnemyStats.Lives--;
        Destroy(gameObject);
    }

}


