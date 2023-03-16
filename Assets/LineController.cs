using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject[] lineArray;
    public GameObject[] drawedLineArray;

    private void Update()
    {
        getLinesAndChangeTag();

        drawedLineArray = GameObject.FindGameObjectsWithTag("drawedLine");

        DeleteDrawedLinesVoid();
    }

    private void getLinesAndChangeTag()
    {
        lineArray = GameObject.FindGameObjectsWithTag("line");

        if (FindObjectOfType<TouchDraw>().isdrawing == false)
        {
            foreach (var item in lineArray)
            {
                item.transform.gameObject.tag = "drawedLine";
            }
        }
    }

    private void DeleteDrawedLinesVoid()
    {
        if (FindObjectOfType<TouchDraw>().isdrawing == false)
        {
            foreach (var item in drawedLineArray)
            {
                if (item.CompareTag("drawedLine"))
                {
                    //Debug.Log("se borraran las lineas" + item.name);
                    //item.GetComponent<LineRenderer>().enabled = false;
                    Destroy(item);
                }
            }
        }
    }
}
