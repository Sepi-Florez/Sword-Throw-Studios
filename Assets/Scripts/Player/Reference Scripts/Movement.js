#pragma strict

var player : Transform;
var conversation : boolean;
var animator : Animator;

var speed : float;
var movementVector : Vector3;

var horizontalObject : GameObject;
var verticalObject : GameObject;
var sensitivity : float;
var lock : boolean;

var boundaryHit : RaycastHit;
var raycastVector : Vector3;
var boundaryDistance : float;
var raycastPoint :Transform;

var jumpHit : RaycastHit;
var jumpHeight : float;
var jumpRayDistance : float;

function Start () {
	lock = true;
}
//Als de speler in gesprek is zal in de update ook beweging worden uitgezet tot dat hij weer uitgesprek is
function Update () {
    if(conversation == false){
        Movement ();
        Jump ();
        Boundaries();
		CameraMovement();
    }
}
// Zorgt voor de beweging van de player.
function Movement () {
    movementVector = Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
}
function CameraMovement (){
	verticalObject.transform.Rotate(Vector3(-Input.GetAxis("Mouse Y"),0,0) * sensitivity * Time.deltaTime );
	horizontalObject.transform.Rotate(Vector3(0,Input.GetAxis("Mouse X"),0) * sensitivity * Time.deltaTime );
	if(lock == true){
		Cursor.visible = false;
		Cursor.lockState = Cursor.lockState.Locked;
	}
	else{
		Cursor.visible = true;
		Cursor.lockState = Cursor.lockState.None;
	}
}
// deze functie laat de speler springen als er grond onder hem is.
function Jump () {
	if(Input.GetButtonDown("Jump")){
		if(Physics.Raycast(player.position,player.position.down, jumpHit, jumpRayDistance)){
		    if(jumpHit.transform.tag == "Terrain"){    
		        player.GetComponent.<Rigidbody>().velocity.y = jumpHeight;
		    }
		}
	}
} 
// Dit is het systeem dat ervoor zorgt dat de speler niet door muren heen glitched. 
// Het zal een raycast schieten naar de kant die hij wilt op lopen en kijken of er iets is waar hij tegen aan zou lopen. Als er niks is kan hij gewoon lopen.
function Boundaries () {
    var rayColor : Color ;
    raycastPoint.Translate(movementVector);
    if(movementVector == Vector3.zero){
        raycastPoint.position = player.position;
    }
    if(Physics.Raycast(player.transform.position,raycastPoint.position, boundaryHit,boundaryDistance)){
        print(boundaryHit.transform.name); 
        rayColor = Color.red;
        
        
    }
    else{
        player.Translate(movementVector * speed * Time.deltaTime);
        rayColor = Color.green;
    }
    Debug.DrawRay(player.position,raycastPoint.position * 100,rayColor);
}
//Activeert een loop animatie wanneer de speler begint met lopen.
function Animations () {
	if(movementVector == Vector3.zero){
		animator.SetBool("Walking", false);
	}
	else{
		animator.SetBool("Walking", true);
	}
}
