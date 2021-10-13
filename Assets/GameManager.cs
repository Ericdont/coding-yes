using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Player1Score;
    public int Player2Score;

    [Header("UI")]
    public TMP_Text Player1ScoreUI;
    public TMP_Text Player2ScoreUI;

    public TMP_Text CountdownText;

    [SerializeField]
    private Ball _ball;

    [SerializeField]
    private Paddle _player1;

    [SerializeField]
    private Paddle _player2;

    public Vector2 ResetPosition;

    [Range(1, 3)]
    [SerializeField]
    private int _numberOfSeconds;

    private WaitForSeconds _timeToWait;

    

    private void Start()
    {
        Player1ScoreUI.text = Player1Score.ToString();
        Player2ScoreUI.text = Player2Score.ToString();

        _timeToWait = new WaitForSeconds(1);
        CountdownText.text = _numberOfSeconds.ToString();
        StartCoroutine(Run());
    }

    

    private IEnumerator Run()
    {
        print("Run before");
        _ball.ResetPosition();

        _player1.ResetPosition();
        _player2.ResetPosition();

        CountdownText.text = _numberOfSeconds.ToString();
        CountdownText.gameObject.SetActive(true);

        for (int i = _numberOfSeconds; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            yield return _timeToWait;
        }

        CountdownText.gameObject.SetActive(false);
        _ball.AddForceInRandomDirection();
        print("Run after");
    }

    

    public void Player1Scored()
    {
        Player1Score++;
        Player1ScoreUI.text = Player1Score.ToString();
        print("Player 1 Scored! :D");

        _ball.ResetPosition();
        _ball.AddForceInRandomDirection();

        _player1.ResetPosition();
        _player2.ResetPosition();

        StopCoroutine(Run());
        StartCoroutine(Run());
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2ScoreUI.text = Player2Score.ToString();
        print("Player 2 Scored! :D");

        _ball.ResetPosition();
        _ball.AddForceInRandomDirection();

    }
}
