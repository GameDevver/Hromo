using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour {

    private Camera _camera; //Перменная тип Camera
    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();//Доступ к компонентам
        //Cursor.lockState = CursorLockMode.Locked;//блокировка курсора
        //Cursor.visible = true; //скрываем указатель мыши

    }
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2;
        float posY = _camera.pixelHeight / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");//команда GUI.Label() отображает символ *
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && 
            EventSystem.current.IsPointerOverGameObject() )
        { //реакция на нажатие кнопки мыши
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0); //середина экрана, половина ширины и высоты
            Ray ray = _camera.ScreenPointToRay(point);//Создание луча методом.
            RaycastHit hit;//переменная для информации луча
            if (Physics.Raycast(ray, out hit))
            {    //луч заполняет информацией переменную
                
                StartCoroutine(SphereIndicator(hit.point));//Запуск сопрограммы в ответ на попадание
                GameObject hitOnject = hit.transform.gameObject;//Получаем объект, в который попал луч
                ReactiveTarget target = hitOnject.GetComponent<ReactiveTarget>();
                if (target != null)
                { //проверяем у этого объекта компонента ReactiveTarget
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {//Сопрограмма использует функцию IEnumerator
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); //говорим переменной sphere,что это примитив сфера
        sphere.transform.position = pos; //перемещаем в позицию попадания, где храниться в переменной pos
        yield return new WaitForSeconds(0.3f);//слово yield указывает когда остановиться
        Destroy(sphere);//удаляем gameObject
    }
    //Кто посмотрел данный скрипт напишите мне в личку: "I know Ray."

}
