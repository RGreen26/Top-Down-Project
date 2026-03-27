using UnityEngine;

public class DoorOpen : MonoBehaviour

{
    public TopDownMovement data;
    public bool CanDestroy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (data.KeyCollected == 4)
        {
          Debug.Log("4Keys");
          CanDestroy = true;
        }
        else
        {
            Debug.Log("NotEnoughKeys");
            CanDestroy = false;
        }

        // if (CanDestroy == true)
        // {
        //     if (Input.GetKeyDown(KeyCode.F))
        //     {
        //         Destroy("Door");
        //     }
           
        // }
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (CanDestroy == true)
    //     {
    //         if (Input.GetKeyDown(KeyCode.F))
    //         {
    //             Destroy(other.gameObject);
    //         }
           
    //     }
    // }
}
