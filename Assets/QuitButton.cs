using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void DeleteGrandPa()
    {
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject);
    }
}
