using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject puzzlePiece;
    public GameObject[,] grid;
    public bool isPlayerOne;
	public int rojo = 0;

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
                ColorFijo(x, y, go);
				Verificacion(x,y,go);
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

	public void Verificacion(int x, int y, GameObject go)
	{
		
		for (int _y = 0; _y < width -1; _y++) 

		{
			if (grid [x, _y].gameObject.GetComponent<Renderer> ().material.color == grid [x, _y + 1].gameObject.GetComponent<Renderer> ().material.color) 
			{
				if (go.GetComponent<Renderer> ().material.color != Color.white) 
				{
					if (go.GetComponent<Renderer> ().material.color == Color.red) 
					{
						rojo++;
					} 

				}
			}
			else
			{
				rojo = 0;
			}
		}
	}
}

