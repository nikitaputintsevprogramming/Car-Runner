using UnityEngine;

public class WeaponScr : MonoBehaviour
{
    public Transform ShotPrefab ;

    public float shootingRate = 0.25f ;

    private float shootCooldown ;
    void Start()
    {
        shootCooldown = 0f;
    }

    
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy)
    {
        shootCooldown = shootingRate;

        var shotTransform = Instantiate(ShotPrefab) as Transform;

        shotTransform.position = transform.position;

        ShotScr shot = shotTransform.gameObject.GetComponent<ShotScr>();

        if (shot != null)
        {
            shot.isEnemyShot = isEnemy ;
        }
        EnemyMove move = shotTransform.gameObject.GetComponent<EnemyMove>();

        if (move != null)
        {
            move.direction = this.transform.right;
        }
    }
    
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}

