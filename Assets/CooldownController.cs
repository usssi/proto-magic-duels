using GestureRecognizer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Events;

public class CooldownController : MonoBehaviour
{

    public int vidaEnemigo;
    public TextMeshProUGUI textoVidaEnemigo;

    public Recognizer recognizer;
    public RecognitionResult recognitionResult;


    public List<GesturePattern> patterns;
    [HideInInspector] public List<GesturePattern> iniPatterns;

    public GesturePattern recognizedGesture;
    public Score recognizedGestureScore;
    public float recognizedScoreFloat;

    public string recognizedGestureId;
    public int recognizedGestureDaño;
    public float recognizedGestureCooldown;

    public TextMeshProUGUI countdown1;
    public TextMeshProUGUI countdown2;
    public TextMeshProUGUI countdown3;
    public TextMeshProUGUI countdown4;
    public TextMeshProUGUI countdown5;

    public int countdown1Int;
    public int countdown2Int;
    public int countdown3Int;
    public int countdown4Int;
    public int countdown5Int;


    private void Start()
    {
        //textoVidaEnemigo.text = "vida enemigo: " + vidaEnemigo;

        recognizer = FindObjectOfType<Recognizer>();

        patterns = FindObjectOfType<Recognizer>().patterns;
        iniPatterns = patterns;
    }

    private void Update()
    {
        textoVidaEnemigo.text = "vida enemigo: " + vidaEnemigo;

        ///countdown controller

    }

    public void OnRecognizeVoid(RecognitionResult result)
    {
        if (result != RecognitionResult.Empty)
        {
            recognizedGesture = result.gesture;
            recognizedGestureScore = result.score;
            recognizedScoreFloat = recognizedGestureScore.score;

            recognizedGestureId = result.gesture.id;
            recognizedGestureDaño = result.gesture.daño;
            recognizedGestureCooldown = result.gesture.cooldown;

            ejecutarHechizo();

        }
        else
        {
            recognizedGesture = null;
            recognizedGestureScore = new Score();
            recognizedScoreFloat = 0;

            recognizedGestureId = "";
            recognizedGestureDaño = 0;
            recognizedGestureCooldown = 0;
        }
    }

    public void ejecutarHechizo()
    {
        if (vidaEnemigo>0)
        {
            vidaEnemigo -= recognizedGestureDaño;
            if (vidaEnemigo <= 0)
            {
                vidaEnemigo = 100;
            }
        }



    }


}
