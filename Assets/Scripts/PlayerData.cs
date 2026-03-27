using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int coinsCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsCollected += 1;

            //other.gameObject.SetActive(false);

            Destroy(other.gameObject);
        }
    }
}
