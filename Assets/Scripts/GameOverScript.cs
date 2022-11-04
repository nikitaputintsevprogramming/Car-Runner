using UnityEngine;

// ������ ��� ����� ����
public class GameOverScript : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (
          GUI.Button(
            // �� ��� � - �� ��������, �� ��� Y - 1/3 �� ������
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (1 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "������ �������!"
          )
        )
        {
            // ��������� ������� Stage1
            Application.LoadLevel("Stage1");
        }

        if (
          GUI.Button(
            // �� ��� � - �� ��������, �� ��� Y - 2/3 �� ������
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "����� � ����"
          )
        )
        {
            // ��������� ������� Menu
            Application.LoadLevel("Menu");
        }
    }
}

