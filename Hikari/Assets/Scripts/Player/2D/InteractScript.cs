using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
        // Reference to the Renderer of the effect
    [SerializeField] private GameObject Screen;
    [SerializeField] private GameObject PressE;
    [SerializeField] private Rigidbody2D Movement;
    [SerializeField] private string STag;
    [SerializeField] private Camera Cam;
    [SerializeField] private GameObject player;
    private bool isInteracting = false;

    public void Start()
    {
        Screen.SetActive(false);
        PressE.SetActive(false);
        Cam.transform.position = new Vector3(-0.779999971f,0,-10);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PressE.SetActive(true);
        isInteracting = true;
        STag = other.name;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        PressE.SetActive(false);
        isInteracting = false;
        STag = " ";
    }
    
    void Update()
    {
        if ((isInteracting) && (Input.GetKeyDown(KeyCode.E)))
        {
            PressE.SetActive(false);
            Movement.constraints = RigidbodyConstraints2D.FreezeAll;
            switch(STag)
            {
                case "BulletinBoard":
                    InteractTextBox(true);
                    break;
                
                case "House":
                    Cam.transform.position = new Vector3(20.4699993f,19.8099995f,-10);
                    player.transform.position = new Vector3(14.6000004f,18.1499996f,0);
                    Cam.backgroundColor = Color.black;
                    Movement.constraints = RigidbodyConstraints2D.None;
                    break;

                case "Door_Exit":
                    Cam.transform.position = new Vector3(-0.779999971f,0,-10);
                    player.transform.position = new Vector3(3.72000003f,-1.94000006f,0);
                    Cam.backgroundColor = new Color(24f/255f, 23f/255f, 37f/255f , 0f);
                    Movement.constraints = RigidbodyConstraints2D.None;
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
