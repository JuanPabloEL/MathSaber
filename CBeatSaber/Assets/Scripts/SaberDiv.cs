using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaberDiv : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;
    public Text textPrefab;
    public string canvasNombre = "Canvas";
    public string segundoCanvas = "Puntuacion";

    public string CanvaTest = "Test";
    private int digitCount;


    // Start is called before the first frame update
    void Start()
    {
        // Recuperar el parámetro desde PlayerPrefs
        digitCount = PlayerPrefs.GetInt("Digits", 1); // Valor predeterminado de 1 si no se encuentra la clave

        // Puedes utilizar digitCount según sea necesario
        Debug.Log("Cantidad de dígitos seleccionados: " + digitCount);        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Color colorObjetoGolpeado = Color.white; // Color predeterminado si no se encuentra un color
                Renderer rendererObjetoGolpeado = hit.transform.GetComponent<Renderer>();
                
                if (rendererObjetoGolpeado != null)
                {
                    colorObjetoGolpeado = rendererObjetoGolpeado.material.color;
                }
                GameObject cuboDentroDelObjeto = hit.transform.Find("Cube (8)").gameObject;
                Renderer rendererCubo = cuboDentroDelObjeto.GetComponent<Renderer>();
                Color colorCubo = rendererCubo.material.color;
                bool result = Comprobarresultado(colorCubo);
                Destroy(hit.transform.gameObject);
                
                //CambiarTextosEnCanva();
                if(result){
                    CambiarTextosEnCanva();
                }
                else{
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
        previousPos = transform.position;
    }

    private bool Comprobarresultado(Color colorobj){
        Canvas canvas = GameObject.Find(canvasNombre)?.GetComponent<Canvas>();
        Canvas canva_test = GameObject.Find(CanvaTest)?.GetComponent<Canvas>();
        Text[] textsEnEscena = canvas.GetComponentsInChildren<Text>();
        Text[] textTest = canva_test.GetComponentsInChildren<Text>();
        string[] operacion = textsEnEscena[2].text.Split(' ');
        int num1, num2, opc1, opc2;
        Color color1 = textsEnEscena[0].color;
        Color color2 = textsEnEscena[1].color;
        int resultado;
        textTest[0].text = "" + color1.ToString() + ": " + color1.r.ToString() + "//" + colorobj.ToString() + ": " + colorobj.r.ToString();
        float cercania = 30f;
        if (int.TryParse(operacion[0], out num1) && int.TryParse(operacion[2], out num2) && int.TryParse(textsEnEscena[0].text, out opc1) && int.TryParse(textsEnEscena[1].text, out opc2))
        {
            resultado = num1 / num2;
            if(resultado == opc1){
                float restRed = Math.Abs(colorobj.r - color1.r);
                float restblue = Math.Abs(colorobj.b - color1.b);
                if(restblue == 0 || restRed == 0)
                    return true;
                else
                    return false; 
            }
            else if(resultado == opc2){
                float restRed = Math.Abs(colorobj.r - color2.r);
                float restblue = Math.Abs(colorobj.b - color2.b);
                if(restblue == 0 || restRed == 0)
                    return true;
                else
                    return false; 
            }
        }
        else
        {
            // Manejar el caso en el que la conversión falla para 'num1' o 'num2'
            // Puedes mostrar un mensaje de error o asignar valores predeterminados
        }
        return false;
    }

    private void CambiarTextosEnCanva()
    {
        Canvas canvas = GameObject.Find(canvasNombre)?.GetComponent<Canvas>();
        Canvas canvas2 = GameObject.Find(segundoCanvas)?.GetComponent<Canvas>();
        int cont = 0;
        
        System.Random random = new System.Random();
        Text[] puntos = canvas2.GetComponentsInChildren<Text>();
        string val = puntos[0].text;
        int punt;
        int[] numalea = new int[2];
        if (int.TryParse(val, out punt))
        {
            if(digitCount == 1){
                if (punt < 10){
                    numalea[0] = random.Next(1, 20);
                    numalea[1] = random.Next(1, 10);
                }
                else if (punt < 25){
                    numalea[0] = random.Next(1, 40);
                    numalea[1] = random.Next(1, 10);
                }
                else{
                    numalea[0] = random.Next(1, 100);
                    numalea[1] = random.Next(1, 50);
                }
                punt++;
                puntos[0].text = "" + punt.ToString();
            }
            else if(digitCount == 2){
                if (punt < 10){
                    numalea[0] = random.Next(1, 40);
                    numalea[1] = random.Next(1, 10);
                }
                else if (punt < 25){
                    numalea[0] = random.Next(1, 100);
                    numalea[1] = random.Next(1, 50);
                }
                else{
                    numalea[0] = random.Next(1, 500);
                    numalea[1] = random.Next(1, 50);
                }
                punt++;
                puntos[0].text = "" + punt.ToString();
            }
            else if(digitCount == 3){
                if (punt < 10){
                    numalea[0] = random.Next(1, 100);
                    numalea[1] = random.Next(1, 50);
                }
                else if (punt < 25){
                    numalea[0] = random.Next(1, 500);
                    numalea[1] = random.Next(1, 50);
                }
                else{
                    numalea[0] = random.Next(1, 1000);
                    numalea[1] = random.Next(1, 100);
                }
                punt++;
                puntos[0].text = "" + punt.ToString();
            }
        }
        else
        {
            puntos[0].text = "No jalo" + val;
        }
        
        int corr = 0;
        int elec = random.Next(1, 10);
        if (elec > 5)  corr = 1;
        int resp = numalea[0];
        int numer = numalea[0] * numalea[1];
        numalea[0] = numer;
        int[] opciones = new int[2]; 
        int incorr = 1 - corr;
        opciones[corr] = resp;
        do{
            opciones[incorr] = random.Next(resp - 10, resp + 10);
        }while(opciones[incorr] == resp || opciones[incorr] <= 0);
        if(canvas != null){
            Text[] textsEnEscena = canvas.GetComponentsInChildren<Text>();
            foreach (Text textEnEscena in textsEnEscena)
            {
                CambiarTexto(textEnEscena, cont, numalea, opciones);
                cont++;
            }
        }
    }

    private void CambiarTexto(Text text, int cont, int[] numalea, int[] opciones)
    {
        if(cont<2){
            text.text = "" + opciones[cont].ToString();
            text.fontSize = 22;
        }
        else{
            text.text = "" + numalea[0].ToString() + " ÷ " + numalea[1].ToString();
        }
    }

}
