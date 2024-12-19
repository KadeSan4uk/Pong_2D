using System.Collections;
using TMPro;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    private Transform _transform;
    public Transform playerLeft;
    public Transform playerRight;

    public TMP_Text _winCountForLeftPlayerText;
    public TMP_Text _winCountForRightPlayerText;

    private int _winCountLeftPlayer;
    private int _winCountRightPlayer;

    public float _speed = 5f;
    public float _topBottomWall = 4.5f;
    public float _rightWall = 8f;
    public float _leftWall = -8f;
    public int SpeedCount = 1;


    private Vector2 _direction;

    private bool _gameOver = false;

    private void Awake()
    {
        _transform = transform;
    }
    private void Start()
    {
        RandomStartirection();
    }

    private void RandomStartirection()
    {
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.2f, 0.2f)).normalized;
    }

    private void Update()
    {
        if (_gameOver)
            return;
        _transform.Translate(_direction * _speed * Time.deltaTime);
        CheckLimits();
    }

    private void CheckLimits()
    {
        if (_transform.position.y > _topBottomWall)
        {
            _direction = new Vector2(_direction.x, -_direction.y);
            _transform.position = new Vector2(_transform.position.x, _topBottomWall);
        }
        else if (_transform.position.y < -_topBottomWall)
        {
            _direction = new Vector2(_direction.x, -_direction.y);
            _transform.position = new Vector2(_transform.position.x, -_topBottomWall);
        }

        //PlayerLeftPosition
        if (_transform.position.x < _leftWall)
        {
            if (_transform.position.y < playerLeft.position.y + 1.5f && _transform.position.y > playerLeft.position.y - 1.5f)
            {
                _direction = new Vector2(-_direction.x, _direction.y + 0.1f).normalized;
                _transform.position = new Vector2(_leftWall, _transform.position.y);
                SpeedCount--;

            }
            else
            {
                _gameOver = true;
                _winCountRightPlayer++;
                _winCountForRightPlayerText.text = _winCountRightPlayer.ToString();
                StartCoroutine(Restart());
            }
        }

        //PlayerRightPosition
        if (_transform.position.x > _rightWall)
        {
            if (_transform.position.y < playerRight.position.y + 1.5f && _transform.position.y > playerRight.position.y - 1.5f)
            {
                _direction = new Vector2(-_direction.x, _direction.y + 0.1f).normalized;
                _transform.position = new Vector2(_rightWall, _transform.position.y);
                SpeedCount--;
            }
            else
            {
                _gameOver = true;
                _winCountLeftPlayer++;
                _winCountForLeftPlayerText.text = _winCountLeftPlayer.ToString();
                StartCoroutine(Restart());
            }
        }

        if (SpeedCount == 0)
        {
            _speed += 0.5f;
            SpeedCount = 1;
        }
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.5f);
        _transform.position = Vector2.zero;
        SpeedCount = 1;
        _speed = 5f;
        _gameOver = false;
        RandomStartirection();
    }


}
