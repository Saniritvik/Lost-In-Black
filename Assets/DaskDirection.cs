using UnityEngine;

public class DaskDirection : MonoBehaviour
{
    public bool clear;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("dashLimit"))
        {
            clear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("dashLimit"))
        {
            clear = false;
        }
    }
}
