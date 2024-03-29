using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro; // работа с текстом

public class CameraMover : MonoBehaviour
{
  public Transform Player; // персонаж
  public float speed; // скорость следования камеры за персонажем
  public GameObject Panel; // ссылка на Canvas.Panel
  public RectTransform ScoreTxt; // ссылка на Canvas.Text(TMP)
//  public TextMeshProUGUI BestScoreText; // ссылка на кмп.TextMeshPro-Text(UI) об.Canvas.TextBest

  private void Start()
  {
    Panel.SetActive(false); // деактивируем Canvas.Panel
  }

  void Update()
  {
    if (Player) // существует ли персонаж, т.к. он удалится при падении в OnTriggerEnter2D
    {
      if (Player.position.y > transform.position.y) // координата персонажа по Y > координата камеры по Y
      {
        Vector3 CameraPosition = Player.position; // CameraPosition = текущие координаты персонажа
        CameraPosition.x = 0; // координата по X всегда = 0, чтобы камера не смещалась по X
        CameraPosition.z = transform.position.z; // сохраняем координаты камеры по Z
        transform.position = CameraPosition; // меняем координаты камеры (т.е. меняем только координату по Y)
      }
    }
  }

  private void OnTriggerEnter2D (Collider2D collision) // столкновение по триггеру с объектом "collision"
  {
	//Debug.Log ("произошло столкновение"); // для отладки, вывод сообщения в консоль
    if (collision.gameObject.GetComponent<Doodler>()) // объект "collision" имеет компонент "Doodler"
    {
      Panel.SetActive(true); // активируем Canvas.Panel
      ScoreTxt.localPosition = new Vector3 (0, 150, 0); // меняем позицию Canvas.Text(TMP)
//      BestScoreText.text = "Лучший результат: " + PlayerPrefs.GetInt("score", 1);
    }

    Destroy (collision.gameObject); // удаляем объект "collision", с которым столкнулись
  }

}