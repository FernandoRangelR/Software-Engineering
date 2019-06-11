using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10;
    private bool facingRight = true;
	  private bool walking = false;
  //  private static count = 1;
    Animator anim;
    private CameraMovement cam;
  //  public VectorValue startingPos;

  private void SetCamera(){
    Vector2 MinPos = new Vector2(-4.78F,-58.03F);
    Vector2 MaxPos = new Vector2(5.77F, -48.99F);
    cam.maxPosition = MaxPos;
    cam.minPosition = MinPos;
  }

    void Start()
    {
      cam = Camera.main.GetComponent<CameraMovement>();
        if(SetPrefs.CheckCount() == 0){
          SetValues();
          SetCamera();
        }else{
          SetPrefs.SetCount();
          float MaxX = PlayerPrefs.GetFloat("CamMaxX");
          float MaxY = PlayerPrefs.GetFloat("CamMaxY");

          float MinX = PlayerPrefs.GetFloat("CamMinX");
          float MinY = PlayerPrefs.GetFloat("CamMinY");

          Vector2 MaxPos = new Vector2(MaxX, MaxY);
          Vector2 MinPos = new Vector2(MinX, MinY);
          cam.maxPosition = MaxPos;
          cam.minPosition = MinPos;
        }
        anim = GetComponent<Animator>();
        float x = PlayerPrefs.GetFloat("X");
        float y = PlayerPrefs.GetFloat("Y");
        float z = PlayerPrefs.GetFloat("Z");
        Vector3 position = new Vector3(x,y,z);
        transform.position = position;
        float x2 = 1.01F;
        float y2 = -58.41F;
        float z2 = 0.00F;

        //RoomMove camera = new RoomMove();
        PlayerPrefs.SetFloat("X", x2);
        PlayerPrefs.SetFloat("Y", y2);
        PlayerPrefs.SetFloat("Z", z2);
        //cam.SetCamera(MaxPos, MinPos);
        /*cam.maxPosition = MaxPos;
        cam.minPosition = MinPos;*/
        //transform.position = startingPos.initialValue;
    }

    void SetValues(){
      float x2 = 1.01F;
      float y2 = -58.41F;
      float z2 = 0.00F;
      PlayerPrefs.SetFloat("X", x2);
      PlayerPrefs.SetFloat("Y", y2);
      PlayerPrefs.SetFloat("Z", z2);
      SetPrefs.SetCount();
      PlayerPrefs.SetInt("NumKeys", 0);
    }

	  void Update()
	  {

  	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		if(moveHorizontal > 0){
			anim.SetBool("FacingRight", true);
		}
		else{
			anim.SetBool("FacingRight", false);
		}
        anim.SetFloat("XSpeed", moveHorizontal);
		    anim.SetFloat("YSpeed", moveVertical);
        GetComponent<Rigidbody2D>().velocity = (movement * maxSpeed);
    }
}
