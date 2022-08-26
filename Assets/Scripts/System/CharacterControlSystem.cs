using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlSystem : IUpdateSystem, IGameSystem
{
    private CharacterComponent mainCharacter;
    private Camera mainCamera;
    private float rotationTime = 0f;
    // 前の速度
	private Vector3 oldVelocity;
	// 回転の速さ
	[SerializeField]
	private float rotateSpeed = 5f;
    // 移動の速さ
    [SerializeField]
    private float moveSpeed = 5f;

    public CharacterControlSystem(CharacterComponent chara, Camera camera)
    {
        mainCharacter = chara;
        mainCamera = camera;
        mainCamera.transform.position = mainCharacter.transform.position + Vector3.up * 4.3f + Vector3.back * 5.25f;
        mainCamera.transform.rotation = mainCharacter.transform.rotation;
        
        // Event
        Singleton.instance.gameEvent.onMoveCharacter.AddListener(OnMoveCharacter);
    }

    private void OnMoveCharacter(CharacterComponent.Direction dir)
    {
        var rotationSpeed = 0.1f;
        // 視点の向き固定

    }

    public void OnUpdate(float deltaTime)
    {
        // 方向決定
        var velocity = Vector3.zero;
		velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        velocity = Vector3.Lerp(oldVelocity, velocity, rotateSpeed * Time.deltaTime);
        oldVelocity = velocity;
        if(velocity.magnitude > 0f){
			mainCharacter.transform.LookAt(mainCharacter.transform.position + velocity);
		} 

        // 視点をキャラに追従
        mainCamera.transform.position = mainCharacter.transform.position + Vector3.up * 4.3f + Vector3.back * 5.25f;
        mainCharacter.transform.position = mainCharacter.transform.position + velocity * deltaTime * moveSpeed;
    }

    public void OnDestroy()
    {
        // Event
        Singleton.instance.gameEvent.onMoveCharacter.RemoveListener(OnMoveCharacter);
    }
}
