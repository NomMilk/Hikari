using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
        // Reference to the Renderer of the effect
    [SerializeField] private GameObject Screen;
    [SerializeField] private Rigidbody2D Movement;
    [SerializeField] private string STag;
    private bool isInteracting = false;

    public void Start()
    {
        Screen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isInteracting = true;
        STag = other.name;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isInteracting = false;
        STag = " ";
    }
    
    void Update()
    {
        if ((isInteracting) && (Input.GetKeyDown(KeyCode.Z)))
        {
            Movement.constraints = RigidbodyConstraints2D.FreezeAll;
            switch(STag)
            {
                case "BulletinBoard":
                    InteractTextBox(true);
                    break;
                
                case "House":
                    SceneManager.LoadScene(2);
                    break;
                //Disable_type

                case "BulletinBoardNone":
                    InteractTextBox(false);
                    Movement.constraints = RigidbodyConstraints2D.None;
                    break;


                default:
                    print("LOL NO");
                    Movement.constraints = RigidbodyConstraints2D.None;
                    break;
            }
            
        }
    }

    //TOGGLE TEXTBOX FOR NPCs AND SIGNS
    private void InteractTextBox(bool x)
    {
        if (x)
        {
            Screen.SetActive(true);
            STag = "BulletinBoardNone";
        }
        else
        {
            Screen.SetActive(false);
            STag = "BulletinBoard";
        }
    }
}
