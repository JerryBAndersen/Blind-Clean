using UnityEngine;
using System.Collections;

public class Flight : MonoBehaviour {

	Rigidbody rigid;
	public float glide = 2f;
	public float up = 1f;
	float y;

	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody> ();
        Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
        foreach (Renderer r in renderers) {
            r.material.SetFloat("_VisibleDistance", 10f* Mathf.Abs(Mathf.Sin(4f*Time.time)));
        }
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (rigid.velocity.y < 0f) {
			y = rigid.velocity.y;
		}
		rigid.AddForce(Vector3.up * -y * up);
		rigid.AddRelativeForce(Vector3.forward * -y * glide);

		if (Input.GetButton ("Fire1")) {			
			rigid.AddForce(Vector3.up * 4f);
		}
		transform.Rotate (new Vector3 (Input.GetAxis ("Vertical2"), Input.GetAxis ("Horizontal"), -Input.GetAxis ("Horizontal2")));
		if (Input.GetButtonUp ("Fire2")) {			
			Application.LoadLevel(0);
		}
        if (Input.GetButton("Left Shoulder") || true)
        {
            Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.SetFloat("_VisibleDistance", 6f * Mathf.Abs(0.6f+0.4f*Mathf.Sin(3f * Time.time)));
                r.material.SetVector("_Origin", transform.position);
            }
        }
        else {
            Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.material.SetFloat("_VisibleDistance", 0f);
                r.material.SetVector("_Origin", transform.position);
            }
        }
	}
}
