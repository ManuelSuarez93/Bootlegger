using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private GameObject _target;

    private Rigidbody2D _rigid;
    private Animator _anim;
    private Transform _playerTransform;
    [SerializeField] private CheckPlayer checkPlayer;
    

    [SerializeField] private LayerMask wall;

    [Tooltip("Max distance")]
    [SerializeField] private float mxdist = 0.5f;

    public float distance;
    void Awake()
    {
        checkPlayer = GetComponent<CheckPlayer>();
        _target = GameObject.FindGameObjectWithTag("Player");

        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        //NAVMESH AGENT SETTINGS
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.updateRotation = false;
        _navAgent.updateUpAxis = false;
    }

    private void Start()
    {
        _navAgent.enabled = true;
    }
    void Update()
    {
        setDistance();
        setDestination();
        setAnim();
    }
    void setDistance() 
    {
        distance = (transform.position - _target.transform.position).magnitude;
        transform.right = new Vector2(_target.transform.position.x - transform.position.x, _target.transform.position.y - transform.position.y);
        Transform _playerTransform = checkPlayer.SightCheck();
    }
    void setDestination()
    {
        if(Time.timeScale > 0)
        {
            if (_target != null)
            {
                if (distance >= Mathf.Abs(mxdist) && _playerTransform == null)
                {

                    _navAgent.SetDestination(_target.transform.position);
                }
                else
                {
                    _navAgent.SetDestination(-_target.transform.position);
                }
            }
        }
        else
        {
            _navAgent.SetDestination(transform.position);
        }
    }
    void setAnim()
    {
        if(_navAgent.isStopped) { _anim.SetFloat("Speed", 0); }
        else { _anim.SetFloat("Speed", 2); }
    }
}
