using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera; // доступ к камере 

    void Start()
    {
        _camera = GetComponent<Camera>(); // Доступ к другим компонентам, присоединенным к этому же объекту

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // при нажатии кнопки мыши
        {                                                                                    //     центр экрана(от куда будет выстрел)
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0); //  <= это половина его ширины и высоты
            Ray ray = _camera.ScreenPointToRay(point); // создание луча методом ScreenPointToRay
            RaycastHit hit;                            // 
            if (Physics.Raycast(ray, out hit))         // испущенный луч заполняет инфомацией переменную, на которую имеется скидка
            {
                GameObject hitObject = hit.transform.gameObject; // получаем объект в который попал луч
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if( target != null)
                {
                    target.ReactToHit();                //вызов метода при поподании
                    Debug.Log("Target hit");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
                
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); // создаем сферу 
        sphere.transform.position = pos;                                      //в месте куда мы стреляем
        yield return new WaitForSeconds(1);                                 //выжидаем секунду
        Destroy(sphere);                                                    // уничтожаем сферу
    }
}
