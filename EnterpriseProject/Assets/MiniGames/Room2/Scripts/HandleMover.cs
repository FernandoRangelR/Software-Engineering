using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMover : MonoBehaviour
{
	//This class moves moves the transform of a 2D object to a new location
	//Complicated so lots of comments, the name is derived from the Handle in Room2 which it was originally designed for
	//Default moveTime was 0.1, handle should be 0.2f, increasing reduces movement speed
	public float moveTime = 0.2f; 
	private float inverseMoveTime;
	private Rigidbody2D rb2D;
	
	private int movesCount = 0;
	private bool coroutineActive = false;
	 
	Animator anim;
	 
    // Start is called before the first frame update
    void Start()
    {
		rb2D = GetComponent <Rigidbody2D> ();
		anim = GetComponent<Animator>();
		//By storing the reciprocal of the move time we can use it by multiplying instead of dividing, this is more efficient.
        inverseMoveTime = 1f/moveTime;
	}
	
	public void Move(float x, float y)
	{
		Vector2 start = transform.position;
		//print("transform start is: " + start); //DEBUG
		Vector2 end = start + new Vector2 (x, y);
		//print("transform end is: " + end); //DEBUG
		
		//Coroutine is a function that has the ability to pause & return control to Unity and then continue on next frame
		coroutineActive = true;
		StartCoroutine (SmoothMovement (end));
	}
	
	//See coroutine above and yield below
	IEnumerator SmoothMovement(Vector3 end)
	{
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		
		//While that distance is greater than a very small amount (Epsilon, almost zero):
        while(sqrRemainingDistance > float.Epsilon)
        {
			coroutineActive = true;
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
                
				
            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition (newPosition);
                
            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                
            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
			//Yield is a required partner of IEnumerator, it allows the loop to pause and pass control back to Unity for a frame
			//It also means that the loop runs once per frame rather than completing all moves in a single frame
            yield return null;
        }
		if(this.movesCount > 0){
			movesCount = movesCount -1;
		}	
		coroutineActive = false;
    }

	//OnTriggerEnter2D is called when this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("interactableObj"))
			{
				 other.gameObject.SetActive(false);
			}
	}		
	public bool getCoroutineStatus()
	{
		return this.coroutineActive;
	}
	
	//Movescount can be passed from an object thats moving if its move is spread across multiple instructions
	//The number will tick down when each move completes in the coroutine
	//When used in combination with coroutineStatus it can let other objects know if the full move set is finished
	public void setMovesCount(int n)
	{
		this.movesCount = n;
	}
	
	public int getMovesCount()
	{
		return this.movesCount;
	}
	
	void Update()
    {
		if(coroutineActive == true){
			anim.SetBool("Moving", true);
		}
		else{
			anim.SetBool("Moving", false);
		}
	}
}
