using UnityEngine;

public class LargeEnemy : MonoBehaviour
{
    public SphereCollision enemyDamage;
    public heal1 playerDamage;

    private heal1 enemyLargeMaxHealth;
    private heal1 enemyLargeHealth;

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    public AudioSource enemyDeathSound;

    void Start()
    {
        InitializeHealth();
    }

    public void InitializeHealth()
    {
        // Initialize unique health variables for each enemy
        enemyLargeMaxHealth = new heal1();
        enemyLargeHealth = new heal1();

        // Set initial health values
        enemyLargeMaxHealth.EnemylargeHealth = 80; // Adjust as needed
        enemyLargeHealth.EnemylargeHealth = enemyLargeMaxHealth.EnemylargeHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Damage the player
            playerDamage.PlayerHealth -= enemyDamage.EnemyDamage;
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            // Damage the enemy
            enemyLargeHealth.EnemylargeHealth -= playerDamage.PlayerDamage;
        }

        if (enemyLargeHealth.EnemylargeHealth < 1)
        {
            explode();
        }
    }

    void Update()
    {
        // Add any necessary update logic here
    }

    void explode()
    {
        gameObject.SetActive(false);
        enemyDeathSound.Play();

        for (int x = 0; x < cubesInRow; x++) 
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for(int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders) 
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - new Vector3(cubeSize * cubesInRow / 2, cubeSize * cubesInRow / 2, cubeSize * cubesInRow / 2);
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
}
