using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ArmySDK
{
    public class InputController : MonoBehaviour
    {
        static Vector3 mouseLastPos;
        static Vector3 mouseDeltaPos;
        static bool mouseDown;

        static InputController instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }

            instance = this;
        }

        void Update()
        {
            if (Application.isEditor)
            {
                if (mouseDown)
                {
                    mouseDeltaPos = Input.mousePosition - mouseLastPos;
                    mouseLastPos = Input.mousePosition;
                    if (GetClickEnded(0))
                    {
                        mouseDown = false;
                    }
                }
                else
                {
                    if (GetClickBegin(0))
                    {
                        mouseDown = true;
                    }
                }
            }
        }

        public static bool CheckClickEvent()
        {
            if (Application.isEditor)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Input.GetMouseButton(i) || Input.GetMouseButtonDown(i) || Input.GetMouseButtonUp(i))
                    {
                        return true;
                    }
                }
            }

            return (Input.touchCount > 0);
        }

        public static Vector3 GetPointerPosition(int index)
        {
            if (Application.isEditor)
            {
                return Input.mousePosition;
            }

            return Input.GetTouch(index).position;
        }

        public static bool GetClickBegin(int index)
        {
            if (Application.isEditor)
            {
                //mouseDown = true;
                return Input.GetMouseButtonDown(index);
            }

            return (Input.GetTouch(index).phase == TouchPhase.Began);
        }

        public static bool GetClickEnded(int index)
        {
            if (Application.isEditor)
            {
                //mouseDown = false;
                return Input.GetMouseButtonUp(index);
            }

            return (Input.GetTouch(index).phase == TouchPhase.Ended);
        }

        public static bool GetClickCanceled(int index)
        {
            if (Application.isEditor)
            {
                return false;
            }

            return (Input.GetTouch(index).phase == TouchPhase.Canceled);
        }

        public static bool GetClickMoved(int index)
        {
            if (Application.isEditor)
            {
                return Input.GetMouseButton(index);
            }

            return (Input.GetTouch(index).phase == TouchPhase.Moved);
        }

        public static bool GetClickStationary(int index)
        {
            if (Application.isEditor)
            {
                return Input.GetMouseButton(index) && (mouseDeltaPos.magnitude <= 0.001f);
            }

            return (Input.GetTouch(index).phase == TouchPhase.Stationary);
        }

        public static Vector2 GetDeltaPosition(int index)
        {
            if (Application.isEditor)
            {
                return mouseDeltaPos;
            }

            return Input.GetTouch(index).deltaPosition;
        }

        public static bool CheckPointerOverUi(int index)
        {
            if (EventSystem.current == null) return false;
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = GetPointerPosition(index);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);
            return results.Count > 0;
        }
    }
}