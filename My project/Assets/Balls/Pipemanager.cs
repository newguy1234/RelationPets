using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pipemanager : MonoBehaviour
{
    private string[,] mainList = new string[10, 10];

    public Dictionary<string, int> colorTotals;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject ballHolder;

    [SerializeField] private float ballHolderXStartOffset;
    [SerializeField] private float ballHolderYStartOffset;
    [SerializeField] private float ballHolderXSpacing;
    [SerializeField] private float ballHolderYSpacing;

    [SerializeField] private float ballXStartOffset;
    [SerializeField] private float ballYStartOffset;
    [SerializeField] private float ballXSpacing;
    [SerializeField] private float ballYSpacing;

    List<GameObject> balls = new List<GameObject>();


    public float xSpacing;
    public float ySpacing;

    public void moveBalls()
    {

    }

    private void Start()
    {
        setupBalls();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            setupBalls();
        }
    }

    private void DrawBalls()
    {
        for(int i = 0; i < balls.Count; i++)
        {
            Destroy(balls[i]);
        }

        for(int i = 0; i < 10; i++)
        {
            GameObject holder = Instantiate(ballHolder);
            balls.Add(holder);
            holder.transform.position = new Vector3(ballHolderXStartOffset + (i * ballHolderXSpacing), ballHolderYStartOffset, 0);
            for (int j = 0; j < 10; j++)
            {
                
                Color newCol;
                GameObject temp = Instantiate(ballPrefab);
                temp.transform.position = new Vector3(ballXStartOffset + (i * ballXSpacing), ballYStartOffset + (j * ballYSpacing), 0);
                if (mainList[i,j] == "empty")
                {
                    Color newColor = Color.red;
                    newColor.a = 0;
                    temp.GetComponent<SpriteRenderer>().material.color = newColor;
                }
                else
                {
                    ColorUtility.TryParseHtmlString("#" + mainList[i, j], out newCol);
                    temp.GetComponent<SpriteRenderer>().material.color = newCol;
                }
                balls.Add(temp);
            }
            
        }
    }

    private void setupBalls()
    {
        colorTotals = new Dictionary<string, int>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                mainList[i, j] = "empty";
            }
        }

        colorTotals.Add("FF0000", 8);
        colorTotals.Add("FF4500", 8);
        colorTotals.Add("FFA500", 8);
        colorTotals.Add("FFD700", 8);
        colorTotals.Add("FFFF00", 8);
        colorTotals.Add("32CD32", 8);
        colorTotals.Add("008000", 8);
        colorTotals.Add("00FFFF", 8);
        colorTotals.Add("0000FF", 8);
        colorTotals.Add("8A2BE2", 8);


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {

                bool found = false;
                while (found != true)
                {
                    int randomColor = Random.Range(0, 10);
                    if (colorTotals.ElementAt(randomColor).Value > 0)
                    {
                        found = true;
                        colorTotals[colorTotals.ElementAt(randomColor).Key] -= 1;
                        mainList[i, j] = colorTotals.ElementAt(randomColor).Key;
                    }
                }

            }
        }

        DrawBalls();
    }
}
