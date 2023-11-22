using UnityEngine;
using System.Collections;


public class TaskLauncher : MonoBehaviour
{
    [SerializeField] GameObject taskToLaunch;
    [SerializeField] private TargetToFollow playerMovement;
    private bool started, finish;
    private string namee;


    private float currentValue = 1.0f;
    private float targetValue = 1.5f;
    private float duration = 2.0f;
    private float elapsedTime = 0.0f;

    private bool scalingUp = true;

    void Start()
    {
        StartCoroutine(ScaleOverTime());
    }

    IEnumerator ScaleOverTime()
    {
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            if (scalingUp)
            {
                currentValue = Mathf.Lerp(1.0f, targetValue, t);
            }
            else
            {
                currentValue = Mathf.Lerp(targetValue, 1.0f, t);
            }

            // Faire quelque chose avec la valeur actuelle (par exemple, mettre à l'échelle un objet)
            // gameObject.transform.localScale = new Vector3(currentValue, currentValue, currentValue);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        scalingUp = !scalingUp;

        elapsedTime = 0.0f;

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(ScaleOverTime());
    }



    void OnMouseDown()
    {
        if (!started)
        {
            namee = taskToLaunch.name;
            taskToLaunch = Instantiate(taskToLaunch);
            started = true;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        gameObject.transform.localScale = new Vector3(currentValue, currentValue, currentValue);
        if (started && !finish)
        {
            playerMovement.paused = true;
        }


        if (started && taskToLaunch == null && !finish)
        {
            Debug.Log(">> " + namee + " plus de pause pause !!");
            playerMovement.paused = false;
            finish = true;
        }
    }
}
