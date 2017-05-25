using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;
    [SerializeField]
    private float speed;
    Rigidbody rb;
	bool started;
	bool gameOver;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!started) {
			if (Input.GetMouseButtonDown(0))
			{
				rb.velocity = new Vector3(speed, 0, 0);
				started = true;

				GameManager.instance.StartGame ();
			}
		}

		if( !Physics.Raycast(transform.position, Vector3.down, 1f) ){
			gameOver = true;

			GameManager.instance.GameOver ();
			rb.velocity = new Vector3 (0, -25 ,0);

			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
		}

		if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            switchDirection();
        }
	}

    void switchDirection()
    {
        if (rb.velocity.z >0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Diamond"){
			GameObject part =  Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			Destroy (part, 1f);
		}
	}
}
