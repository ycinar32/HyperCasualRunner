using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Paintable : MonoBehaviour
{

    public GameObject Brush;
    public GameObject Player;
    public float brushSize = 0.1f;
    public float upperBoundry = 8f;
    public float lowerBoundry = 0f;
    public float rightBoundry = 8.7f;
    public float leftBoundry = -8.7f;
    public int[,] array = new int[17, 8];
    public int arrayCounter = 0;
    public Slider Slider;
    public Text PercentageText;
    public Canvas WallUI;
    public Canvas RunnerUI;



    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Player.GetComponent<PlayerMovementTP>().finished)
        {
            WallUI.enabled = true;
            RunnerUI.enabled = false;
        }
        else
        {
            WallUI.enabled = false;
            RunnerUI.enabled = true;
        }
        if (Input.GetMouseButton(0) && Player.GetComponent<PlayerMovementTP>().finished)
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                if (hit.collider.tag == "Wall")
                { 
                    if ((hit.point.y <= upperBoundry && hit.point.y >= lowerBoundry))
                    {
                        if (((hit.point.x <= rightBoundry && hit.point.x >= leftBoundry)))
                        {
                            //Debug.Log(hit.point);
                            var go = Instantiate(Brush, hit.point + Vector3.back * 0.1f, Quaternion.identity, transform);
                            go.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
                            go.transform.localScale = Vector3.one * brushSize;

                            PercentageControl(hit.point);
                        }
                    } 
                }
            }
        }
    }

    public void PercentageControl(Vector3 point)
    {
        int x_val = (int)point.x + 8;
        int y_val = (int)point.y;

        if (array[x_val, y_val] == 0)
        {
            arrayCounter += 1;
            array[x_val, y_val] = 1;
        }

        Slider.value= (arrayCounter/9f *10f) / 100f;
        
        PercentageText.text = "%" + ((int)(Slider.value * 100)).ToString();

        if(Slider.value > 0.98)
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}

