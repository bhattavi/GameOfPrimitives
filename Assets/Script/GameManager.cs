using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isSquaredDestoryed = false;
    bool isCircleDestoryed = false;
    public string nextScene;

   public Text score;
   static int total = 0;
   public int clicks = 5;
   public Text remClicks;

    // Start is called before the first frame update
    void Start()
    {
        score.text = total.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //}
      

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

      


        if (isCircleDestoryed && isSquaredDestoryed)
        {
            SceneManager.LoadScene(nextScene);
           
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {



                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("Square"))
                    {

                        Destroy(hit.collider.gameObject);
                        isSquaredDestoryed = true;
                        
                        total += 1;
                        score.text = total.ToString();
                       


                    }
                    if (hit.collider.gameObject.CompareTag("Circle"))
                    {


                        Destroy(hit.collider.gameObject);
                        isCircleDestoryed = true;
                       
                        total += 5;
                        score.text = total.ToString();


                    }

                }
                else
                {
                    clicks--;
                    remClicks.text = clicks.ToString();
                    if (clicks <= 0)
                    {
                        SceneManager.LoadScene(nextScene);
                    }
                }
            }
        }
      
    }
}
