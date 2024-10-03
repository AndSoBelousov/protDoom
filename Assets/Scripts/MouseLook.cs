using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes 
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY; // переменнаякоторая появится в инспекторе 

    public float sensitivityHor = 9.0f; 
    public float sensitivityVer = 9.0f;  

    public float minimumVert = -45.0f; 
    public float maximumVert = 45.0f;  

    private float _rotationX = 0;

    private Rigidbody body;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX) // вращение только по горизонтали
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY) // вращение только по вертикали 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityHor; // увеличиваем угол поворота по вертикали, в соотв. с перемещением мыши 
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // фмксируем угол поворота мин. и макс. значениями

            float rotationY = transform.localEulerAngles.y; // сохраняем одинаковый угол поворота вокруг оси Y (вращение по гориз. отсутствует)

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // новый вектор из сохраяненных значений поворота
        }
        else // комбинированное вращение 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityHor;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;// величина на которую следует поменять угол поворота
            float rotationY = transform.localEulerAngles.y + delta;// приращение угла поворота через значение delta

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // новый вектор из сохраяненных значений поворота
        }
    }
}
