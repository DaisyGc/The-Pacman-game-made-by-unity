using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

	public GameObject [] waypointsGos;
	public float speed = 0.2f;
	private List <Vector3>waypoint=new List <Vector3>();
	private int index =0;
	private void Start()
	{
		LoadAPath(waypointsGos[Random.Range(0,4)]);
	}
	private void FixedUpdate()
	{
		if (transform.position != waypoint [index]) {
			Vector2 temp = Vector2.MoveTowards (transform.position, waypoint [index],speed);
			GetComponent<Rigidbody2D> ().MovePosition (temp);
		} else {
			index++;
			if(index>=waypoint.Count)
			{index=0;
				LoadAPath(waypointsGos[Random.Range(0,4)]);
			}
		}
		Vector2 dir = waypoint [index] - transform.position;
		GetComponent<Animator> ().SetFloat ("DirX", dir.x);
		GetComponent<Animator> ().SetFloat ("DirY", dir.y);
	}
	private void LoadAPath(GameObject go)
	{
		waypoint.Clear();
		foreach(Transform t in go.transform)
		{
			waypoint.Add(t.position);
		}
	}

}
