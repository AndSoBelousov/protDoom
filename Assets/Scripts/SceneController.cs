using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;    // хранит в себе шаблон 
    private GameObject _enemy;                          // экземпляр этого шаблона 

    void Start()
    {
        
    }

    
    void Update()
    {
        CreateEnemy();

    }

    private void CreateEnemy()  // создание врага 
    {
        if (_enemy == null) // если в сцене не осталось врагов 
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            //По умолчанию Instantiate()возвращает новый объект как универсальный Objectтип, но Object напрямую
            //он практически бесполезен, и нам нужно обращаться с ним как GameObject
            //для приведения типа используем ключевое слово "as"
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
