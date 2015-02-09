using UnityEngine;
using System.Collections;

public class camera_mov : MonoBehaviour {
	
	public float offset_x;
	public float offset_y;
	public float offset_z;
	public float offset_posX;
	public float offset_posY;
	public float offset_posZ;

	public Transform target;

	Vector3 cam_pos;

	float cam_z, cam_x, cam_y;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		cam_pos = target.position;
		transform.position = target.position + new Vector3 (offset_x, offset_y, offset_z);
		transform.LookAt (target);
		cam_pos = transform.position;
		transform.position = new Vector3 (cam_pos.x + offset_posX, cam_pos.y + offset_posY, cam_pos.z + offset_posZ);


	}


}