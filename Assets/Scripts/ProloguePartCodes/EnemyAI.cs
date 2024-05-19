using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;       // Oyuncunun u�a��
    public float speed = 10f;      // U�ak h�z�
    public float orbitDistance = 15f; // Oyuncudan ne kadar uzakl�kta d�nece�i
    public float orbitSpeed = 5f;  // D�nerkenki h�z
    public GameObject bulletPrefab; // Mermi prefab�
    public Transform bulletSpawn;  // Merminin ��k�� noktas�
    public float fireRate = 1f;    // Ate� etme s�kl���

    private float fireCooldown = 0f; // Ate� etme bekleme s�resi

    void Update()
    {
        // Oyuncunun etraf�nda d�n
        OrbitPlayer();

        // Ate� etme i�lemi
        if (Vector3.Distance(transform.position, player.position) <= orbitDistance)
        {
            FireAtPlayer();
        }
    }

    void OrbitPlayer()
    {
        Vector3 direction = (transform.position - player.position).normalized;
        Vector3 orbitPosition = player.position + direction * orbitDistance;

        // Oyuncunun etraf�nda d�nme hareketi
        transform.RotateAround(player.position, Vector3.up, orbitSpeed * Time.deltaTime);

        // U�a��n oyuncuya bakmas�n� sa�la
        transform.LookAt(player);
    }

    void FireAtPlayer()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            fireCooldown = 1f / fireRate;

            // Mermiyi olu�tur ve ate� et
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bulletSpawn.forward * 20f; // Mermi h�z�

            // Mermiyi belirli bir s�re sonra yok et
            Destroy(bullet, 2f);
        }
    }
}
