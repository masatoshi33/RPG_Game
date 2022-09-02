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
    private float moveSpeed = 10f;
    //　ジャンプ力
	[SerializeField]
	private float jumpPower = 100f;
    // 重力の倍率
    [SerializeField]
    private float gravityMultiplier = 15f;

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
        Debug.Log($"velocity:({mainCharacter.rigidbody.velocity.x}, {mainCharacter.rigidbody.velocity.y}, {mainCharacter.rigidbody.velocity.z})");
        // 重力
        mainCharacter.rigidbody.AddForce((gravityMultiplier - 1f) * Physics.gravity, ForceMode.Acceleration);

        // 方向決定
        mainCharacter.rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * 3, 0f, Input.GetAxis("Vertical")) * 3, ForceMode.VelocityChange);
        if ((mainCharacter.rigidbody.velocity - mainCharacter.rigidbody.velocity.y * Vector3.up).magnitude > 1e-3f)
        {
            mainCharacter.animator.SetBool("IsWalking", true);
		} 
        else mainCharacter.animator.SetBool("IsWalking", false);

        // 着地判定
        var distance = 1f;
        var rayPosition = mainCharacter.transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        var ray = new Ray(rayPosition, Vector3.down);
        var isGround = Physics.Raycast(ray, distance);
        // Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        // キャラがジャンプ
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGround)
            {
                if (!mainCharacter.animator.IsInTransition(0) && !mainCharacter.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !mainCharacter.animator.GetBool("IsJumping"))
                {
                    mainCharacter.animator.SetBool("IsJumping", true);
                    mainCharacter.rigidbody.velocity += jumpPower * Vector3.up;
                }
            }
        }
        else
        {
            if (isGround) mainCharacter.animator.SetBool("IsJumping", false);
        }

        if((mainCharacter.rigidbody.velocity - mainCharacter.rigidbody.velocity.y * Vector3.up).magnitude > 1e-3f){
			mainCharacter.transform.LookAt(mainCharacter.transform.position + mainCharacter.rigidbody.velocity - Vector3.up * mainCharacter.rigidbody.velocity.y);
		} 

        // 視点をキャラに追従
        mainCamera.transform.position = mainCharacter.transform.position + Vector3.up * 4.3f + Vector3.back * 5.25f;
    }

    public void OnDestroy()
    {
        // Event
        Singleton.instance.gameEvent.onMoveCharacter.RemoveListener(OnMoveCharacter);
    }
}
