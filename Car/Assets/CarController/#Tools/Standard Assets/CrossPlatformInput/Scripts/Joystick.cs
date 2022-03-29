using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class Joystick : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler, IDragHandler*/
	{
		public Transform borderRight;
		public Transform borderLeft;
		public Transform car;
		public DynamicJoystick dynamicJoystick;
		//public enum AxisOption
		//{
		//	// Options for which axes to use
		//	Both, // Use both
		//	OnlyHorizontal, // Only horizontal
		//	OnlyVertical // Only vertical
		//}

		//public int MovementRange = 100;
		//public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		//public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		//public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

		//Vector3 m_StartPos;
		//bool m_UseX; // Toggle for using the x axis
		//bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
                                                                       //CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input
        private void Awake()
        {

			
			
		}

        void Start()
		{
			
			m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis("Horizontal");
			CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
			
		}
		public void Rest()
        {
			m_HorizontalVirtualAxis.Remove();
		}
		//void OnEnable()
		//{
		//	//CreateVirtualAxes();
			
		//}
		public bool remove;
        private void Update()
        {
            
            
				m_HorizontalVirtualAxis.Update(dynamicJoystick.Horizontal/2);
				
			
			
			
			//Debug.Log("JoyStick"+dynamicJoystick.Horizontal);

			//if ((car.transform.position.x < borderRight.transform.position.x)&& (car.transform.position.x > borderLeft.transform.position.x))
   //         {
			//	otoTurn = false;
   //         }
   //         else
   //         {
			//	UpdateVirtualAxes(transform.position);
			//	otoTurn = true;
   //         }
        }
       

		//void UpdateVirtualAxes(Vector3 value)
		//{
		//	var delta = m_StartPos - value;
		//	delta.y = -delta.y;
		//	delta /= MovementRange;
            
		//		if (m_UseX)
		//		{
					
		//		}
			
            
			

			
			

		//	if (m_UseY)
		//	{
		//		m_VerticalVirtualAxis.Update(delta.y);
		//	}
		//}

		//void CreateVirtualAxes()
		//{
		//	// set axes to use
		//	m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
		//	m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

		//	// create new axes based on axes to use
		//	if (m_UseX)
		//	{
		//		m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
		//		CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
		//	}
		//	if (m_UseY)
		//	{
		//		m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
		//		CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
		//	}
		//}


		//public void OnDrag(PointerEventData data)
		//{
		//	Vector3 newPos = Vector3.zero;

		//	if (m_UseX)
		//	{
		//		int delta = (int)(data.position.x - m_StartPos.x);
		//		delta = Mathf.Clamp(delta, - MovementRange, MovementRange);
		//		newPos.x = delta;
		//	}

		//	if (m_UseY)
		//	{
		//		int delta = (int)(data.position.y - m_StartPos.y);
		//		delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
		//		newPos.y = delta;
		//	}
		//	transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
		//	UpdateVirtualAxes(transform.position);
		//}


		//public void OnPointerUp(PointerEventData data)
		//{
		//	transform.position = m_StartPos;
		//	UpdateVirtualAxes(m_StartPos);
		//}


		//public void OnPointerDown(PointerEventData data) { }

		//void OnDisable()
		//{
		//	// remove the joysticks from the cross platform input
		//	if (m_UseX)
		//	{
		//		m_HorizontalVirtualAxis.Remove();
		//	}
		//	if (m_UseY)
		//	{
		//		m_VerticalVirtualAxis.Remove();
		//	}
		//}
	}
}