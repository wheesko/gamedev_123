using UnityEngine;

public class SuperShotgun : MonoBehaviour, IRangedWeapon
{
    public Transform FirePoint;
    public AudioClip hitEnemyClip;
    public GameObject Bullet;
    public int Damage;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;

    void Start()
    {
        Debug.Log(transform.position);
        nextFire = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if(nextFire <= Time.time && Input.GetButton("Fire1"))
        {
            CollisionDetection();
            var bullet = Instantiate(Bullet, FirePoint.position, PlayerViewRotation);
            Destroy(bullet, 3);
            nextFire = Time.time + fireRate;
            PlayClip(hitEnemyClip);
        }

    }

    private void CollisionDetection()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.tag.Equals("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(Damage);
            }
        }
    }

    private Quaternion PlayerViewRotation => Camera.main.transform.rotation;

    private void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    } 
}
