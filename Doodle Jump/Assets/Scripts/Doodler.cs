using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodler : MonoBehaviour
{
  public float MoveSpeed; // скорость движения/перемещения по X
  public float JumpForce; // сила прыжка по Y
  public float MoveDecreaser; // замедление движения по X
  private Rigidbody2D rb;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>(); // получаем ссылку на компонент "Rigidbody2D"
  }

  private void OnCollisionEnter2D (Collision2D collision) // столкновение с твёрдым телом
  {
    if (rb.velocity.y <= 0.5f) // проверка отрицательной скорости по Y (вертикальной скорости) объекта, т.е. падает ли объект
    {
      Vector2 Velocity = rb.velocity; // Velocity = вектор текущей скорости объекта
      Velocity.y = JumpForce; // составляющая Y Velocity = сила прыжка
      rb.velocity = Velocity; // задаём вектор текущей скорости объекта
    }
  }

  void Update()
  {
    Vector2 Velocity = rb.velocity; // Velocity = вектор текущей скорости объекта

    if (Input.GetButton("Fire1")) //проверка на нажатие ЛКМ, Input.GetMouseButton(0)
    {
      if (Input.mousePosition.x < Screen.width/2) // проверка позиции мыши по X (по горизонтали) меньше половины ширины экрана
      {
        Velocity.x = - MoveSpeed; // составляющая X Velocity = отрицательная скорость движения
      }
      else
      {
        Velocity.x = MoveSpeed; // составляющая X Velocity = положительная скорость движения
      }
	  rb.velocity = Velocity; // задаём вектор текущей скорости объекта
    }
    else
    {
      Velocity.x *= MoveDecreaser; // корректируем составляющую X Velocity
      rb.velocity = Velocity; // замедляем скорость движения по X (если MoveDecreaser < 1)
    }
  }

}