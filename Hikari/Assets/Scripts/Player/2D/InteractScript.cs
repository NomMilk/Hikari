using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
        // Reference to the Renderer of the effect
    [SerializeField] private GameObject something;
    private bool isInteracting = false;


    private void OnTriggerEnter2D(){
        isInteracting = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detect "Z" key press for interaction
        

        // Call the Interact method when the player interacts
        if ((isInteracting) && (Input.GetKeyDown(KeyCode.Z)))
        {
            switch(something.tag){
                case "InteractTextBox":
                    InteractTextBox();
                    break;
                
                case "InteractLoadStage":
                    InteractLoadStage();
                    break;
                default:
                    print("LOL NO");
                    break;
            }
            
        }
    }

    //TOGGLE TEXTBOX FOR NPCs AND SIGNS
    private void InteractTextBox()
    {
       something.SetActive(true);
    }

    private void InteractLoadStage(){

    }

    //LOAD NEW SCENE
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("House"))
        {
            SceneManager.LoadScene(1);
        }
    }


}
