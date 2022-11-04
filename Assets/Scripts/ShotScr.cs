using UnityEngine;

public class ShotScr : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;
    
    void Start()
    {
        Destroy(gameObject, 20);
    }


}
