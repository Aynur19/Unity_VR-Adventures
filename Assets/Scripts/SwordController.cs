using UnityEngine;

public class SwordController : OVRGrabber
{
    private OVRHand m_hand;
    private float pinchTreshold = 0.7f;

	private void Start()
	{
		m_hand = GetComponent<OVRHand>();
	}

	private void Update()
	{
		CheckIndexPinch();
	}

	private void CheckIndexPinch()
	{
		float pinchStrength = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

		if (!m_grabbedObj && pinchStrength > pinchTreshold && m_grabCandidates.Count > 0)
		{
			GrabBegin();
		}
		else if (m_grabbedObj && (pinchStrength > pinchTreshold))
		{
			GrabEnd();
		}
	}
}
