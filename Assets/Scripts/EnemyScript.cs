using UnityEngine;

/// �������� ��������� �����
public class EnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private EnemyMove EnemyMove;
    private WeaponScr[] weapons;

    void Awake()
    {
        // �������� ������ ������ ���� ���
        weapons = GetComponentsInChildren<WeaponScr>();

        // ��������� �������, ����� �������������� ������� ��� ���������� ������
        EnemyMove = GetComponent<EnemyMove>();
    }

    // 1 - ��������� ���
    void Start()
    {
        hasSpawn = false;

        // ���������
        // -- ����������
        GetComponent<Collider2D>().enabled = false;
        // -- �����������
        EnemyMove.enabled = false;
        // -- ��������
        foreach (WeaponScr weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        // 2 - ���������, ������� �� ����� ������.
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            // �������������� ��������
            foreach (WeaponScr weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

            // 4 � ����� �� ����� ������? ���������� ������� ������.
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    // 3 - �������������.
    private void Spawn()
    {
        hasSpawn = true;

        // �������� ���
        // -- ����������
        GetComponent<Collider2D>().enabled = true;
        // -- �����������
        EnemyMove.enabled = true;
        // -- ��������
        foreach (WeaponScr weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
