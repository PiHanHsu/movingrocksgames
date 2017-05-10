using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GamePlayingFlow GamePlayingFlow;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private float _probationTime = 0.15f; // In seconds.

    void Awake ()
    {
        //_anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
        randTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //hitTarget();
        }

        if (_probationTime > 0)
        {
            _probationTime -= Time.deltaTime;
        } else if (_probationTime < 0)
        {
            _probationTime = 0;
            _spriteRenderer.enabled = true;
        }
        // print(_probationTime.ToString("00:00.00"));
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
		//hitTarget();
    }

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag != "Body") {
			hitTarget (transform.position);
		} else {
			//Destroy (gameObject);
			randTarget();
		}

	}


	private void hitTarget(Vector3 pos)
    {
        if (_probationTime == 0)
        {
            GamePlayingFlow.AddScore();
			GamePlayingFlow.HitTarget (pos);
            _probationTime = 0.15f;
        }
        _spriteRenderer.enabled = false;
        randTarget();
        //_anim.SetTrigger("Click");
    }

    private void randTarget()
    {
        transform.position = new Vector3(Random.Range(940, -940), Random.Range(500, -500), 0);
    }
}
