using UnityEngine;

public class PlayerInfo : SingletonMonoBehaviour<PlayerInfo>
{
    [SerializeField,Tooltip("�v���C���[�����n�ł��郌�C���[")]
    LayerMask _platformLayer;

    [HideInInspector]
    public Rigidbody g_rb = null;
    [HideInInspector]
    public CapsuleCollider g_collider = null;
    [HideInInspector]
    public bool g_isGround = true;
    [HideInInspector]
    public Transform g_transform = null;

    new private void Awake()
    {
        g_rb = GetComponent<Rigidbody>();
        g_collider = GetComponent<CapsuleCollider>();
        g_transform = transform;
    }

    private void Update()
    {
        Ray ray = new Ray(g_transform.position, Vector3.down);
        var size = new Vector3(g_collider.radius, 0.5f, 1);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.red, 0.1f);

        if(Physics.BoxCast
            (ray.origin,
            size,
            ray.direction,
            out hit,
            Quaternion.identity,
            2f,
            _platformLayer,
            QueryTriggerInteraction.Ignore))
        {
            //Debug.Log($"{hit.distance}{hit.transform.name}");
            if(hit.distance < 0.55f)
            {
                g_isGround = true;
                return;
            }
            g_isGround = false;
        }
    }
}