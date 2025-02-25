using System.Collections.Generic;
using UnityEngine;

public class PipeFactory : MonoBehaviour
{
    public static PipeFactory Instance
    {
        get;
        private set;
    }

    public GameObject Prefab;

    [Range(1f, 3f)]
    public float speed = 1f;

    private int poolSize = 5;
    private Queue<GameObject> pool = new Queue<GameObject>();

    private Vector2 prefabSize;
    private Vector3 prefabPos;
    private Vector3 topPos = new Vector3(1080, 540, 0);
    private Vector3 bottomPos = new Vector3(1080, -540, 0);

    private SpriteRenderer sprRend;
    private BoxCollider2D boxCol;

    private float totalTime = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(Prefab);
            pool.Enqueue(obj);
            obj.SetActive(false);
        }

        prefabSize = Prefab.GetComponent<SpriteRenderer>().size;
        prefabPos = Prefab.transform.position;
    }

    void Update()
    {
        if (totalTime < (4 - speed))
        {
            totalTime += Time.deltaTime;
        }
        else
        {
            GameObject pipe = TakeFromPool();

            sprRend = pipe.GetComponent<SpriteRenderer>();
            sprRend.size = new Vector2(prefabSize.x, prefabSize.y * Random.Range(3, 8));

            boxCol = pipe.GetComponent<BoxCollider2D>();
            boxCol.size = sprRend.size;
            boxCol.offset = new Vector2(0, sprRend.size.y * 0.5f);

            if (Random.Range(0, 2) == 0)
            {
                pipe.transform.position = topPos;
                sprRend.flipY = true;
                boxCol.offset *= -1;
            }
            else
            {
                pipe.transform.position = bottomPos;
                sprRend.flipY = false;
            }

            totalTime = 0;
        }
    }

    private GameObject TakeFromPool()
    {
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(Prefab);
        }

        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        pool.Enqueue(obj);
        obj.transform.position = prefabPos;
        obj.SetActive(false);
    }
}
