using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid2D : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject puzzlePiece;
    private GameObject[,] grid;
    public bool isPlayerOne;
    public int rojo;
    public int azul;
    private Color tinte;
    public int conth;
    public int contv;
    public int contk;
    public int contp;
    private Text Rojo;
    private Text Azul;

    // Use this for initialization
    void Start()
    {
       
        grid = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject go = GameObject.Instantiate(puzzlePiece) as GameObject;
                Vector3 position = new Vector3(x, y, 0);
                go.transform.position = position;
                grid[x, y] = go;
                
            }
        }
        isPlayerOne = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawLine(Vector3.zero, mPosition);
        UpdatePickedPiece(mPosition);
    }

    public void UpdatePickedPiece(Vector3 position)
    {
        int x = (int)(position.x + 0.5f);
        int y = (int)(position.y + 0.5f);

        for (int _x = 0; _x < width; _x++)
        {
            for (int _y = 0; _y < height; _y++)
            {
                
                {
                    GameObject go = grid[_x, _y];
                    if (go.GetComponent<Renderer>().material.color != Color.red && go.GetComponent<Renderer>().material.color != Color.blue)
                    {
                        go.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

                    }
                   
                }
            }
        }

        if (x >= 0 && y >= 0 && x < width && y < height)
        {


            Senalar(grid[x, y]);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject go = grid[x, y];
                if (go.GetComponent<Renderer>().material.color != Color.red && go.GetComponent<Renderer>().material.color != Color.blue)
                {
                    ColorFijo(x, y, go);
                    VerIzq(x, y, go.GetComponent<Renderer>().material.color);
                    VerDer(x, y, go.GetComponent<Renderer>().material.color);
                    VerArr(x, y, go.GetComponent<Renderer>().material.color);
                    VerAba(x, y, go.GetComponent<Renderer>().material.color);
                    DiagDerU(x, y, go.GetComponent<Renderer>().material.color);
                    DiagDerD(x, y, go.GetComponent<Renderer>().material.color);
                    DiagIzqU(x, y, go.GetComponent<Renderer>().material.color);
                    DiagIzqD(x, y, go.GetComponent<Renderer>().material.color);
                    conth = VerIzq(x, y, go.GetComponent<Renderer>().material.color) + VerDer(x, y, go.GetComponent<Renderer>().material.color);
                    contv = VerArr(x, y, go.GetComponent<Renderer>().material.color) + VerAba(x, y, go.GetComponent<Renderer>().material.color);
                    contk = DiagDerU(x, y, go.GetComponent<Renderer>().material.color) + DiagIzqD(x, y, go.GetComponent<Renderer>().material.color);
                    contp = DiagIzqU(x, y, go.GetComponent<Renderer>().material.color) + DiagDerD(x, y, go.GetComponent<Renderer>().material.color);

                    if (conth == 3 || contv == 3 || contk == 3 || contp == 3)
                    {
                        if (isPlayerOne)
                        {
                            Debug.Log("Gano el Azul");
                          
                        }
                        else
                        {
                            Debug.Log("Gano el Rojo");
                        }
                       
                    }
                }
                
            }
        }

    }

    void Senalar(GameObject turi)
    {
        if (turi.GetComponent<Renderer>().material.color == Color.white)
        {
            turi.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

   public void ColorFijo (int x, int y, GameObject go)
    {
        
        if (isPlayerOne)
        {
            if (go.GetComponent<Renderer>().material.color != Color.red && go.GetComponent<Renderer>().material.color != Color.blue)
            {
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                
            }
  
        }
        else
        {
            if (go.GetComponent<Renderer>().material.color != Color.red && go.GetComponent<Renderer>().material.color != Color.blue)
            {
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                
            }
       
        }
        isPlayerOne = !isPlayerOne;
    }

    int VerIzq(int x, int y, Color tinte)
    {
        int conth = 0;
        while (x > 0)
        {
            x = x - 1;
            if(grid[x,y].GetComponent<Renderer>().material.color == tinte)
            {
                conth++;
            }
            else
            {
                break;
            }
        }
        return conth;
        
            
    }
    int VerDer ( int x, int y, Color tinte)
    {
        int contk = 0;
        while (x < width-1)
        {
            x = x + 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contk++;
            }
            else
            {
                break;
            }
        }
        return contk;
    }
    int VerArr(int x, int y, Color tinte)
    {
        int contv = 0;
        while (y > 0)
        {
            y = y - 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contv++;
            }
            else
            {
                break;
            }
        }
        return contv;
    }
    int VerAba(int x, int y, Color tinte)
    {
        int contv = 0;
        while (y < height-1)
        {
            y = y + 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contv++;
            }
            else
            {
                break;
            }
        }
        return contv;
    }
    int DiagDerU(int x, int y, Color tinte)
    {
        int contk = 0;
        while (y < height-1 && x < width-1)
        {
            x = x + 1;
            y = y + 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contk++;
            }
            else
            {
                break;
            }
        }
        return contk;
    }
    int DiagIzqD(int x, int y, Color tinte)
    {
        int contk = 0;
        while (y > 0 && x > 0)
        {
            x = x - 1;
            y = y - 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contk++;
            }
            else
            {
                break;
            }
        }
        return contk;
    }
    int DiagIzqU(int x, int y, Color tinte)
    {
        int contp = 0;
        while (y < height-1 && x > 0)
        {
            x = x - 1;
            y = y + 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contp++;
            }
            else
            {
                break;
            }
        }
        return contp;
    }
    int DiagDerD(int x, int y, Color tinte)
    {
        int contp = 0;
        while (y > 0 && x < width-1)
        {
            x = x + 1;
            y = y - 1;
            if (grid[x, y].GetComponent<Renderer>().material.color == tinte)
            {
                contp++;
            }
            else
            {
                break;
            }
        }
        return contp;
    }
}

