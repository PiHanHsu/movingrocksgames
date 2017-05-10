using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingFlow : MonoBehaviour {

    public GameSettings GameSettings;
    public Text ScoreText;
    public Text TimeText;
    public Text GameOverText;
    public InputField NameInputField;
    public GameObject Targets;
    public UIControl UIControl;

	public GameObject HitTargetEffect;
	public GameObject Target;

    private string _playerName = "Anonymous";
    private int _score = 0;
    private float _timeLeft = 0;
    private bool _gamePlaying = false;
    private float _targetBaseScale = 25f;
	private GameObject _targetObject;
	private GameObject _hitTargetEffect;
	private int _numberOfTargets;

    // Use this for initialization
    void Start() {
        // NameInputField.onValueChanged.AddListener(delegate { setName(); });
        showTimeAndScore();
		float scale = _targetBaseScale + GameSettings.GetSizeOfTarget()* 15;
        Targets.transform.localScale = new Vector3(scale, scale, 1);
		_numberOfTargets = (int)GameSettings.GetNumOfTarget ();

    }

    // Update is called once per frame
    void Update() {

        if (_timeLeft > 0f)
        {

            PlayingGame();
        } else if (_gamePlaying == true)
        {
            StopGame();
        }
    }

    public void StartGame()
    {
        _score = 0;
        _timeLeft = GameSettings.GetDuration() * 30;
        showTimeAndScore();
        Targets.SetActive(true);
        UIControl.hideAll();
        _gamePlaying = true;
		print (_numberOfTargets);
		if (_numberOfTargets > 1) {
			for (int i = 1; i < _numberOfTargets; i++){
				createTarget ();
			}
		}


    }

    public void PlayingGame()
    {
        showTimeAndScore();
    }

    private void showTimeAndScore()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + getScore();
        TimeText.GetComponent<Text>().text = "Time: " + getTimeLeft();
    }

    public void StopGame()
    {
        // print("StopGame");
        _timeLeft = 0f;
        TimeText.GetComponent<Text>().text = "Time: 00:00.00";
        Targets.SetActive(false);
        _gamePlaying = false;
        GameOverText.GetComponent<Text>().text = _playerName + ":\nYour Score is " + getScore() + ".";
        UIControl.switchToUI2();
    }

    public void switchToUI1()
    {
        UIControl.switchToUI1();
    }

    public string getScore()
    {
        return _score.ToString();
    }

    public string getTimeLeft()
    {
        _timeLeft -= Time.deltaTime;
        if(_timeLeft < 0)
        {
            _timeLeft = 0;
        }
        // print(_timeLeft);
        return _timeLeft.ToString("00:00.00");
    }

    public void AddScore()
    {
        //_score += 100;
    }

	public void HitTarget(Vector3 pos){

		_score += 100;
		_hitTargetEffect = Instantiate (HitTargetEffect, pos, transform.rotation);
		Destroy (_hitTargetEffect, 2);

	}
		
    public void setName()
    {
        _playerName = NameInputField.text;
        if (_playerName == "") { _playerName = "Anonymous"; }
    }

	public void createTarget(){
		Vector3 pos = new Vector3(UnityEngine.Random.Range(940, -940), UnityEngine.Random.Range(500, -500), 0);	
		_targetObject = Instantiate (Target, pos, transform.rotation);
	}
}
