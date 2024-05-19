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
    public float minHeight = 2000f; // Minimum u�u� y�ksekli�i
    public float maxHeight = 4000f; // Maksimum u�u� y�ksekli�i

    private float fireCooldown = 0f; // Ate� etme bekleme s�resi
    private float targetHeight;      // Hedef y�kseklik

    void Start()
    {
        // Ba�lang��ta rastgele bir hedef y�kseklik belirle
        targetHeight = Random.Range(minHeight, maxHeight);
    }

    void Update()
    {
        // Oyuncunun etraf�nda d�n
        OrbitPlayer();

        // Ate� etme i�lemi
        if (Vector3.Distance(transform.position, player.position) <= orbitDistance)
        {
            FireAtPlayer();
        }

        // Y�kseklik kontrol�
        MaintainHeight();
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
            if (bulletPrefab != null && bulletSpawn != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = bulletSpawn.forward * 20f; // Mermi h�z�

                    // Merminin olu�turuldu�unu kontrol etmek i�in log ekleyin
                    Debug.Log("Mermi ate�lendi!");

                    // Mermiyi belirli bir s�re sonra yok et
                    Destroy(bullet, 2f);
                }
                else
                {
                    Debug.LogError("BulletPrefab i�inde Rigidbody bile�eni bulunamad�.");
                }
            }
            else
            {
                Debug.LogError("BulletPrefab veya BulletSpawn atanmad�.");
            }
        }
    }

    void MaintainHeight()
    {
        // Hedef y�ksekli�e do�ru hareket et
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

        // Y�ksekli�i ayarla
        transform.position += heightAdjustment * speed * Time.deltaTime;
    }
}
