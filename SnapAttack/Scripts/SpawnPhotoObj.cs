using UnityEngine;

public class SpawnPhotoObj : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject[] photoObj;
    [SerializeField] private bool isMoving;
    private Collider2D spawnAera;

    private float maxY;
    private float minY;
    private float maxX;
    private float minX;
    #endregion

    public GameObject[] PhotoObj
    {
        get { return photoObj; }
        set { photoObj = value; }
    }

    void Start()
    {
        spawnAera = GetComponent<Collider2D>();
        maxX = spawnAera.bounds.extents.x;
        maxY = spawnAera.bounds.extents.y;
        minX = -spawnAera.bounds.extents.x;
        minY = -spawnAera.bounds.extents.y;

    }
    public void randomizeLocation(int i)
    {
        float x = UnityEngine.Random.Range(minX, maxX);
        float y = UnityEngine.Random.Range(minY, maxY);
        Vector2 place = new Vector2(x, y);
        GameObject phobj = Instantiate(photoObj[i],transform);
        phobj.transform.position = place;
        if (isMoving)
        {
            phobj.GetComponent<PhotoObj>().move = true;
        }
        else
        {
            phobj.GetComponent<PhotoObj>().move = false;
        }
        
    }

}
