using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private InputAction upButton;
    private InputAction downButton;

    private AudioSource myCDPlayer;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");

        myCDPlayer = GetComponent<AudioSource>(); 
       
    }

    // Update is called once per frame
    void Update()
    {
 
        // vector means x,y,z 
        //so this is saying transform the x,y,z of player position
        Vector3 playerPosition = transform.position; 
        if (upButton.IsPressed())
        {
            playerPosition.y += 2 * Time.deltaTime; //this is just y+2!! 
            Debug.Log("Go up.");
        }
        
        if (downButton.IsPressed())
        {
            playerPosition.y -= 2 * Time.deltaTime; //this is just y-2!! 
            Debug.Log("Go down.");
        }
        //collidewithscreenedge
     

        transform.position = playerPosition; 
        
        //BOUNDARIES RESET!
        Vector3 currentPosition = transform.position;
        if (currentPosition.y>= 6f)
        {
            currentPosition.y = 0f;
        }
        transform.position = currentPosition;
       if (currentPosition.y<= -6f)
       {
           currentPosition.y = 0f;
       }
        transform.position = currentPosition;

        if (currentPosition.x<= -11f)
        {
            currentPosition.x = 0f;
        }
        transform.position = currentPosition;
        
        if (currentPosition.x>= 11f)
        {
            currentPosition.x = 0f;
        }
        transform.position = currentPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        myCDPlayer.Play();
        Debug.Log("touched somehting");
    }
    
}
