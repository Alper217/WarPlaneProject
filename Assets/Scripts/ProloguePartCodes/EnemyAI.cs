using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;       // Oyuncunun uçaðý
    public float speed = 10f;      // Uçak hýzý
    public float orbitDistance = 15f; // Oyuncudan ne kadar uzaklýkta döneceði
    public float orbitSpeed = 5f;  // Dönerkenki hýz
    public GameObject bulletPrefab; // Mermi prefabý
    public Transform bulletSpawn;  // Merminin çýkýþ noktasý
    public float fireRate = 1f;    // Ateþ etme sýklýðý

    private float fireCooldown = 0f; // Ateþ etme bekleme süresi

    void Update()
    {
        // Oyuncunun etrafýnda dön
        OrbitPlayer();

        // Ateþ etme iþlemi
        if (Vector3.Distance(transform.position, player.position) <= orbitDistance)
        {
            FireAtPlayer();
        }
    }

    void OrbitPlayer()
    {
        Vector3 direction = (transform.position - player.position).normalized;
        Vector3 orbitPosition = player.position + direction * orbitDistance;

        // Oyuncunun etrafýnda dönme hareketi
        transform.RotateAround(player.position, Vector3.up, orbitSpeed * Time.deltaTime);

        // Uçaðýn oyuncuya bakmasýný saðla
        transform.LookAt(player);
    }

    void FireAtPlayer()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            fireCooldown = 1f / fireRate;

            // Mermiyi oluþtur ve ateþ et
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bulletSpawn.forward * 20f; // Mermi hýzý

            // Mermiyi belirli bir süre sonra yok et
            Destroy(bullet, 2f);
        }
    }
}
