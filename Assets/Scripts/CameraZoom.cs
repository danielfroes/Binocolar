using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    
    [SerializeField] private float zoomSize = 1.5f;
    [SerializeField] private float zoomLerpSpeed = 10f;

    private Camera _cam;
    private Vector3 _regularPosition;
    private Vector3 _targetPosition;
    private float _targetZoom;
    private float _regularSize;
    private float _screenBoundaryX;
    private float _screenBoundaryY;
    private bool _isZoomIn = false;
    private bool _enableZoom = false;
    // Start is called before the first frame update
    void Start() 
    {
        _cam = Camera.main;
        
        _regularSize = _cam.orthographicSize;
        _targetZoom = _regularSize;
        _regularPosition = _cam.transform.position;
        _targetPosition = _regularPosition;

        _screenBoundaryY  = _regularSize - zoomSize;
        _screenBoundaryX = _screenBoundaryY * _cam.aspect;
    } 

    // Update is called once per frame
    void Update()
    {

        if(_enableZoom)
        {
            if(Input.GetMouseButtonDown(0) && IsMouseOverBackground())
            {
                if(!_isZoomIn) //zoom
                {
                    _targetZoom = zoomSize;

                    Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
                    _targetPosition.x = Mathf.Clamp(mousePosition.x, -_screenBoundaryX, _screenBoundaryX);
                    _targetPosition.y = Mathf.Clamp(mousePosition.y, -_screenBoundaryY, _screenBoundaryY);
                }
                else //goes back to normal
                {
                    _targetZoom = _regularSize;    
                    _targetPosition = _regularPosition;
                }

                //toggles between the regular and zommed values;
                _isZoomIn = !_isZoomIn;
            }

            // 
            _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _targetZoom, Time.deltaTime * zoomLerpSpeed);
            _cam.transform.position = Vector3.Lerp(_cam.transform.position, _targetPosition, Time.deltaTime * zoomLerpSpeed);
           
        }
    }

    public void EnableZoom(bool status)
    {
        _enableZoom = status;
    }

    private bool IsMouseOverBackground()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        
    

        return raycastResultList.Count == 0;
    }
    
 
}
