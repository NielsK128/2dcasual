using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody2D rb;
	public Rigidbody2D Hook;

	public float releaseTime = .15f;
	public float maxDragDistance = 2f;

	public GameObject ballSpawner;
	private bool isPressed = false;

    public GameObject explosionParticles;
    public GameObject explosionSound;

	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;

	private Ray leftCatapultToProjectile;

	bool ballReleased = false;
	//private float circleRadius;


	// Start is called before the first frame update
	void Start()
	{
		catapultLineFront = GameObject.FindWithTag("FrontPoint").GetComponent<LineRenderer>();
		catapultLineBack = GameObject.FindWithTag("BackPoint").GetComponent<LineRenderer>();
		ballSpawner = GameObject.FindWithTag("Mechanics");
		Hook = GameObject.FindWithTag("Hook").GetComponent<Rigidbody2D>();
		LineRendererSetup();
		//circleRadius = 0.3f;
		leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
		this.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector3.Distance(mousePos, Hook.position) > maxDragDistance)
				rb.position = Hook.position + (mousePos - Hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}

		LineRendererUpdate();
	}

	void LineRendererSetup()
	{
		catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";

		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}

	void LineRendererUpdate()
	{
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude /*+ circleRadius */);
		catapultLineFront.SetPosition(1, holdPoint);
		catapultLineBack.SetPosition(1, holdPoint);
	}

	void OnMouseDown()
	{
		if(ballReleased == false) {
		isPressed = true;
		rb.isKinematic = true;
		}
	}

	void OnMouseUp()
	{
		if(ballReleased == false) {
		StartCoroutine(Release());
		isPressed = false;
		rb.isKinematic = false;
		}
	}

	IEnumerator Release()
	{
		ballReleased = true;
		yield return new WaitForSeconds(releaseTime);
		this.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;
		//yield return new WaitForSeconds(0.1f);
		//Band.BandVisible = 1;


		yield return new WaitForSeconds(.5f);
	    ballSpawner.GetComponent<BallSpawner>().SpawnBall();
		ballReleased = false;
		yield return new WaitForSeconds(1.5f);
		Instantiate(explosionParticles, this.gameObject.transform.position, Quaternion.identity );
        Instantiate(explosionSound, this.gameObject.transform.position, Quaternion.identity );
		Destroy(this.gameObject);
	}
}
