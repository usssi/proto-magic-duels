using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TouchDraw : MonoBehaviour
{
    Coroutine drawing;

    public GameObject lineaPrefabCargada;
    public Camera uiCam;
    public bool isdrawing;

    public float timer;
    public float timeLeft;
    public bool canDraw;

    private void Start()
    {
        canDraw = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartLine();
            //Debug.Log("dibujando");
        }
        if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
            //Debug.Log("termino de dibujar");
        }

        if (isdrawing)
        {            
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                timeLeft = 0.0f;
                canDraw = false;
                FinishLine();
                //Debug.Log("¡El temporizador ha llegado a cero!");
            }
        }
    }

    void StartLine()
    {
        timeLeft = timer;
        if (drawing!=null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
        isdrawing = true;
    }

    void FinishLine()
    {
        canDraw = true;
        StopCoroutine(drawing);
        isdrawing = false;
    }

    IEnumerator DrawLine()
    {
        GameObject newGameObject = Instantiate(lineaPrefabCargada, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer line = newGameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        newGameObject.gameObject.tag = "line";



        while (canDraw)
        {
            Vector3 position = uiCam.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }
    }
}
