using UnityEngine;

public class PhotoObj : MonoBehaviour
{
    SnapAttackGameManager sm;
    Rigidbody2D _rigid;

    [SerializeField] private float speed;
    private float randx;
    private float randy;

    public bool move;
    void Start()
    {
        randx = UnityEngine.Random.Range(-1f, 1f);
        randy = UnityEngine.Random.Range(-1f, 1f);
        _rigid = GetComponent<Rigidbody2D>();
        sm = GameObject.Find("SnapAttackGameManager").GetComponent<SnapAttackGameManager>();
    }

    void Update()
    {
        moveTo();
    }
    public void missed()
    {
        sm.Missed();
    }

    void moveTo()
    {
        if(_rigid && move)
        {
            _rigid.velocity = new Vector2(randx,randy).normalized * speed;
        }
    }

}
