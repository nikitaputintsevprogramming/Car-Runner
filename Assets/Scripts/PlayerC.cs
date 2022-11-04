using UnityEngine;
using System;

public class PlayerC : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        float inlX = Input.GetAxis("Horizontal");
        float inlY = Input.GetAxis("Vertical");

        movement = new Vector2(
            speed.x * inlX,
            speed.y * inlY);

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot)
        {
            WeaponScr weapon = GetComponent<WeaponScr>();
            if (weapon != null)
            {
              
                weapon.Attack(false);
            }
        }

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
    void OnDestroy()
    {
        // Игра окончена.
        // Добавьте скрипт к родителю, поскольку текущий игровой
        // объект, скорее всего, будет тут же уничтожен.
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
