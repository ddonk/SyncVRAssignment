using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TigerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private List<Sprite> _tigerSprites;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Button _popupButton;
    private RandomRange timeRange;
    private RandomRange coorRange;
    private RandomRange popupRange;
    
    private const float XBounds = 8.8f;
    private const float YBounds = 4.5f;

    private Vector3 direction;
    private Vector3 currentPos;
    
    private void Awake()
    {
        if (!TryGetComponent(out _spriteRenderer))
        {
            Debug.LogWarning($"Couldn't get sprite renderer component on {gameObject.name}");
        }
        else
        {
            _spriteRenderer.sprite = _tigerSprites[0];
        }
        
        timeRange = new RandomRange(2, 5);
        coorRange = new RandomRange(0.1f, 1);
        popupRange = new RandomRange(4, 8);
        
        StartCoroutine(UpdatePopUp());
        RandomMove();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (gameObject.transform.position.x > XBounds || gameObject.transform.position.x < -XBounds)
        {
            direction.x = -direction.x;
        } else if (gameObject.transform.position.y > YBounds || gameObject.transform.position.y < -YBounds)
        {
            direction.y = -direction.y;
        }
        
        gameObject.transform.position += direction * moveSpeed * Time.deltaTime;
    }
    private IEnumerator UpdatePopUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRange.GetRandomNumber());
            _popupButton.interactable = true;
            _spriteRenderer.sprite = _tigerSprites[1];
            direction = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(popupRange.GetRandomNumber());
            _popupButton.interactable = false;
            _spriteRenderer.sprite = _tigerSprites[0];
            RandomMove();
        }
    }

    private void RandomMove()
    {
        direction = new Vector2(coorRange.GetRandomNumber() * RandomDirection(), coorRange.GetRandomNumber() * RandomDirection());
    }

    private int RandomDirection()
    {
        int result = Random.Range(0, 2);

        if (result == 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}

public readonly struct RandomRange
{
    private float min { get; }
    private float max { get; }

    public float GetRandomNumber()
    {
        return Random.Range(min, max);
    }
    
    public RandomRange(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
