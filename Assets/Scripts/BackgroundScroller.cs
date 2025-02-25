using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(0f, 5f)]
    public float speed = 1f;

    private Material material;
    private float offset = 0;
    
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            offset = 0;
            return;
        }

        offset += (Time.deltaTime * speed) / 10f;
        material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
