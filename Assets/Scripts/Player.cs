using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField][Range(0, 1)] float deathVFXVolume = 0.75f;
    [SerializeField] AudioClip shootSFX;
    [SerializeField][Range(0, 1)] float shootVFXVolume = 0.25f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingX = 1f;
    [SerializeField] float paddingY = 1f;
    [SerializeField] float health = 200f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float fireInterval = 0.5f;

    Coroutine fireCoroutine;
    float minX;
    float maxX;
    float minY;
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        MovementBoundriesSetup();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
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
        FindObjectOfType<LevelController>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVFXVolume);
    }

    private void Move()
    {
        // by default GetAxis is between 0 and 1 so we need to multiply it to a speed
        var deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
        // transform.position = new Vector2(newXPos, transform.position.y);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // StopAllCoroutines();
            // StopCoroutine(FireContinuously()); not works
            StopCoroutine(fireCoroutine);
        }
    }

    private void MovementBoundriesSetup()
    {
        // viewport position s always between 0 and 1
        Camera mainCamera = Camera.main;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingY;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingY;
    }

    public float GetHealth() { return health; }

    IEnumerator FireContinuously()
    {
        // use while to make it work for holding button
        // without while we have to push the button realse and push again to shoot
        while (true)
        {
            //Quaternion.identity means don't apply any rotation
            //Instantiate by default doesn't return a GameObject
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootVFXVolume);
            yield return new WaitForSeconds(fireInterval);
        }
    }
}
