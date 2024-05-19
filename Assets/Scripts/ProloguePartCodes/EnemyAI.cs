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
    public float minHeight = 2000f; // Minimum uçuþ yüksekliði
    public float maxHeight = 4000f; // Maksimum uçuþ yüksekliði

    private float fireCooldown = 0f; // Ateþ etme bekleme süresi
    private float targetHeight;      // Hedef yükseklik

    void Start()
    {
        // Baþlangýçta rastgele bir hedef yükseklik belirle
        targetHeight = Random.Range(minHeight, maxHeight);
    }

    void Update()
    {
        // Oyuncunun etrafýnda dön
        OrbitPlayer();

        // Ateþ etme iþlemi
        if (Vector3.Distance(transform.position, player.position) <= orbitDistance)
        {
            FireAtPlayer();
        }

        // Yükseklik kontrolü
        MaintainHeight();
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
            if (bulletPrefab != null && bulletSpawn != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = bulletSpawn.forward * 20f; // Mermi hýzý

                    // Merminin oluþturulduðunu kontrol etmek için log ekleyin
                    Debug.Log("Mermi ateþlendi!");

                    // Mermiyi belirli bir süre sonra yok et
                    Destroy(bullet, 2f);
                }
                else
                {
                    Debug.LogError("BulletPrefab içinde Rigidbody bileþeni bulunamadý.");
                }
            }
            else
            {
                Debug.LogError("BulletPrefab veya BulletSpawn atanmadý.");
            }
        }
    }

    void MaintainHeight()
    {
        // Hedef yüksekliðe doðru hareket et
        float currentHeight = transform.position.y;

        if (currentHeight < minHeight)
        {
            targetHeight = Random.Range(minHeight, maxHeight);
        }
        else if (currentHeight > maxHeight)
        {
            targetHeight = Random.Range(minHeight, maxHeight);
        }

        float heightDifference = targetHeight - currentHeight;
        Vector3 heightAdjustment = new Vector3(0, heightDifference, 0).normalized;

        // Yüksekliði ayarla
        transform.position += heightAdjustment * speed * Time.deltaTime;
    }
}
