using UnityEngine;

public class AutodimmerScript : MonoBehaviour
{
    public Rigidbody Car;

    void Update () {
        transform.position = Car.transform.position;
        transform.forward = Car.transform.forward;
	}
    
    void DrawHalo(Light Light, bool Enable)
    {
        var halo = (Behaviour)Light.GetComponent("Halo");
        halo.enabled = Enable;
    }

    int _inRange;
    
    void OnTriggerEnter(Collider Collider)
    {
        if (StaticSettings.AutoDimmer && Collider.tag == "CarAI")
        {
            ++_inRange;

            foreach (var headlight in Collider.transform.parent.parent.gameObject.GetComponentsInChildren<Light>())
            {
                DrawHalo(headlight, false);

                headlight.intensity = 15;
                headlight.spotAngle = 50;
                headlight.range = 10;
            }

            foreach (var headlight in Car.GetComponentsInChildren<Light>())
            {
                headlight.intensity = 15;
                headlight.spotAngle = 50;
                headlight.range = 10;
            }
        }
    }

    void OnTriggerExit(Collider Collider)
    {
        if (StaticSettings.AutoDimmer && Collider.tag == "CarAI")
        {
            --_inRange;

            foreach (var headlight in Collider.transform.parent.parent.gameObject.GetComponentsInChildren<Light>())
            {
                DrawHalo(headlight, true);

                headlight.intensity = 50;
                headlight.spotAngle = 90;
                headlight.range = 15;
            }

            if (_inRange > 0)
                return;

            foreach (var headlight in Car.GetComponentsInChildren<Light>())
            {
                headlight.intensity = 30;
                headlight.spotAngle = 70;
                headlight.range = 15;
            }
        }
    }
}
