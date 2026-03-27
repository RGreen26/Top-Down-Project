using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Animator anim;
    public GameObject KeyPrefab;
    public Vector3 KeySpawn1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsPress", true);
            Instantiate(KeyPrefab, KeySpawn1, Quaternion.identity);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsPress", false);
        }
    }
}
