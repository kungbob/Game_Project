#pragma strict

var firstPersonCamera: Camera;
var overheadCamera: Camera;

function Start() {
    ShowOverheadView();
}

function ShowOverheadView() {
    firstPersonCamera.enabled = false;
    overheadCamera.enabled = true;

}

function ShowFirstPersonView() {
    firstPersonCamera.enabled = true;
    overheadCamera.enabled = false;
}

function Update() {
 
    if (Input.GetKeyDown(KeyCode.C)) {
        if (firstPersonCamera.enabled){
            
            ShowOverheadView();
        }else{
            ShowFirstPersonView();
        }
        
    }
}