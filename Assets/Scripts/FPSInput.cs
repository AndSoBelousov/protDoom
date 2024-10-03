using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _charController; // переменная для ссылки на компонент CharacterController

    void Start()
    {
        _charController = GetComponent<CharacterController>(); // доступ к другим компанентам, присоединенным к этому же объекту
        
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ); //    ограничиваем движение по диагонали той же скоростью,
        movement = Vector3.ClampMagnitude(movement, speed);// <= что и движение параллельно осям

        movement.y = gravity; // да будет гарвитация 

        movement *= Time.deltaTime;                         //      преобразуем(c помощью метода TransformDirection) из локальных
        movement = transform.TransformDirection(movement);  //  <=  в глобыльные координаты, что бы воспользоваться методом Move
        _charController.Move(movement); // заставим перемещать компонент CharacterController


    }
}
