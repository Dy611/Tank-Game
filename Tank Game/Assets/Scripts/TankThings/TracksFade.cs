using UnityEngine;

public class TracksFade : MonoBehaviour
{
    public bool canUse;

    [SerializeField]
    [Tooltip("Time It Takes To Fade Away")]
    private float fadeTime = 5;

    private float currTime;

    private SpriteRenderer sRend;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        currTime = fadeTime;
        canUse = false;
    }

    private void Update()
    {
        if(currTime > 0)
        {
            currTime -= Time.deltaTime;
            if(currTime <= 0)
            {
                canUse = true;
                gameObject.SetActive(false);
            }
        }

        sRend.material.color = Color.Lerp(Color.clear, Color.white, currTime / fadeTime);
    }
}