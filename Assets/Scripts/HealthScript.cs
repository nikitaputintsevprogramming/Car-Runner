using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// ����� ����������
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// ���� ��� �����?
    /// </summary>
    public bool isEnemy = true;

    /// <summary>
    /// ������� ���� � ��������� ������ �� ������ ���� ���������
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            // ������!
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // ��� �������?
        ShotScr shot = otherCollider.gameObject.GetComponent<ShotScr>();
        if (shot != null)
        {
            // ��������� �������������� ����
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // ���������� �������
                Destroy(shot.gameObject); // ������ �������� � ������� ������, ����� �� ������ ������� ������.      }
            }
        }
    }
}