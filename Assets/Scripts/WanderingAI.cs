using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] public float _speed = 3.0f;         // скорость движения 
    [SerializeField] public float _obstacleRange = 5.0f; // рассстояние с которого начинается реакция на препятсятвия

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive;                                 // для слежения за состояением персонажа  


    private void Start()
    {
        _alive = true;                                  // инициализация переменной 
    }
    private void Update()
    {
        moveAI();
    }

    private void moveAI()
    {
        if (_alive)             // только в случае если персонаж жив 
        {
        transform.Translate(0f, 0f, _speed * Time.deltaTime);       //постоянное передвижение вперед

        Ray ray = new Ray(transform.position, transform.forward); // луч находится в том же положении и 
                                                                  // целится в том же направлении что и перс.
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))               // луч для осмотра сцены
        {
                GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
            else if (hit.distance < _obstacleRange)                   
            {                                                     // полу рандомный поворот от препятсявия
                float angle = Random.Range(-110, 110);              
                transform.Rotate(0f, angle, 0f);
            }
        }
        }
    }

    public void SetAlive(bool alive) // открытый метод, позволяющий внешнему коду воздействовать на "живое" сост.
    {
        _alive = alive;
    }
}
