using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement1 : MonoBehaviour {

    public string enemyTag = "Ally";
    public float range = 15f;
    private Transform target;
    private Transform aim;
    private int wavepointIndex = 0;

    public float power = 5;

    private Enemy ally = null;
    private Ally targetEnemy;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    void Start()
	{
		ally = GetComponent<Enemy>();

		target = Waypoints.points[0];

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
                if (Vector3.Distance(transform.position, aim.position) <= 1.5f)
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
            if (Vector3.Distance(transform.position, target.position) <= 1f)
            {
                GetNextWaypoint();
            }

            ally.speed = ally.startSpeed;
        }
    }

    void Shoot()
    {
        Ally e = aim.GetComponent<Ally>();
        King king = aim.GetComponent<King>();
        ally.anim.SetTrigger("Attack");
        if (e != null)
        {
            e.TakeDamage(power);
        }
        if (king != null)
        {
            king.TakeDamage(power);
        }
    }

    void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
