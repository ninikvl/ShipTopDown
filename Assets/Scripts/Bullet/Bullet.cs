using UnityEngine;

public class Bullet : MonoBehaviour, IBulletable
{
    private readonly float _speed = 2f;

    private Vector2 _direction = new Vector2(1, 0);
    private Vector2 velocity;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        velocity = _direction * _speed;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.deltaTime;

        transform.position = pos;
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
    }
}
