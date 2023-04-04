using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed = 1f;
	public bool passFlag = false;
	private Rigidbody _rigidbody;
	private Camera _mainCam;
	private float _objZPos;
	private float _movZ;
	private int _checkpointFlag;
	private bool _firstEntry;


	private void Awake()
	{
		LevelStartSettings();
	}

	private void OnMouseDown()
	{
		_objZPos = _mainCam.WorldToScreenPoint(gameObject.transform.position).z;
	}

	private void LevelStartSettings()
	{
		_mainCam = Camera.main;
		_rigidbody = GetComponent<Rigidbody>();
		_checkpointFlag = 0;
		_firstEntry = true;
	}
	private void OnMouseDrag()
	{
		var mousePoint = Input.mousePosition;
		mousePoint.z = _objZPos;
		_movZ = _mainCam.ScreenToWorldPoint(mousePoint).z;
	}

	private void FixedUpdate()
	{
		MovementPlayer();
	}

	private void MovementPlayer()
	{
		if (GameManager.Instance.levelStart)
		{
			var x = (speed * Time.fixedDeltaTime) * -1;

			var newPosition = transform.position + new Vector3(x, 0, 0);
			
			if (_movZ > 0.9f)
			{
				newPosition.z = 0.9f;
			}
			else if (_movZ < -1.9f)
			{
				newPosition.z = -1.9f;
			}
			else
			{
				newPosition.z = _movZ;
			}

			_rigidbody.MovePosition(newPosition);
		}
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("StopPoint"))
		{
			speed = 0;
			Destroy(other.gameObject);
			StartCoroutine(Checkpoint());
		}

		if (other.CompareTag("EndPoint") & _firstEntry)
		{
			_firstEntry = false;
			StartCoroutine(EndPoint());
		}

		if (other.CompareTag("Finish"))
		{
			GameManager.Instance.UIManager.wonPanel.SetActive(true);
			GameManager.Instance.levelStart = false;
		}
	}

	private IEnumerator Checkpoint()
	{
		yield return new WaitForSeconds(2f);

		if (passFlag)
		{
			GameManager.Instance.currentLevel.checkpointAnim[_checkpointFlag].SetTrigger("Checkpoint");
			
			yield return new WaitForSeconds(2f);

			speed = 4f;
			
			_checkpointFlag = 1;
		}
		else
		{
			GameManager.Instance.UIManager.retryPanel.SetActive(true);
		}
	}

	private IEnumerator EndPoint()
	{
		yield return new WaitForSeconds(5f);
		_firstEntry = true;
	}
}