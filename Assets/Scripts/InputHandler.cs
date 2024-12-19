using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float _maxHigtPosition = 3.3f;
    public float _minHigtPosition = -3.3f;
    private float _speed = 10f;   

    private void Update()
    {
        PLayer1InputHandler();
        PLayer2InputHandler();
    }

    private void PLayer1InputHandler()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float directionY = player1.position.y + _speed * Time.deltaTime;
            directionY = Mathf.Clamp(directionY, _minHigtPosition, _maxHigtPosition);
            player1.position = new Vector2(player1.position.x, directionY);
        }
        if (Input.GetKey(KeyCode.S))
        {
            float directionY = player1.position.y - _speed * Time.deltaTime;
            directionY = Mathf.Clamp(directionY, _minHigtPosition, _maxHigtPosition);
            player1.position = new Vector2(player1.position.x, directionY);
        }
    }

    private void PLayer2InputHandler()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float directionY = player2.position.y + _speed * Time.deltaTime;
            directionY = Mathf.Clamp(directionY, _minHigtPosition, _maxHigtPosition);
            player2.position = new Vector2(player2.position.x, directionY);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float directionY = player2.position.y - _speed * Time.deltaTime;
            directionY = Mathf.Clamp(directionY, _minHigtPosition, _maxHigtPosition);
            player2.position = new Vector2(player2.position.x, directionY);
        }
    }
}
