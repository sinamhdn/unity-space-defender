using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150;
    // public double weight = 0;

    [Header("Shooting")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float minDelayBetweenShots = 0.2f;
    [SerializeField] float maxDelayBetweenShots = 3f;
    float shotCounter;

    [Header("FX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField][Range(0, 1)] float deathVFXVolume = 0.75f;
    [SerializeField] AudioClip shootSFX;
    [SerializeField][Range(0, 1)] float shootVFXVolume = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minDelayBetweenShots, maxDelayBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        HitProcess(damageDealer);
    }

    private void HitProcess(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.HitTarget();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVFXVolume);
    }

    private void CountdownAndShoot()
    {
        // Time.delttime is fps independent time
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Shoot();
            shotCounter = Random.Range(minDelayBetweenShots, maxDelayBetweenShots);
        }
    }

    private void Shoot()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootVFXVolume);
    }
}
