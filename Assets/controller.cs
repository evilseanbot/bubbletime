using UnityEngine;
using Valve.VR;


public class controller : MonoBehaviour
{
    public static bool LeftIsPressed;
    public static bool RightIsPressed;

    private bool leftWasPressed;
    private bool rightWasPressed;

    uint left = 0;
    uint right = 0;

    public GameObject bubble;
    public GameObject device1;
    public GameObject device2;
    public GameObject device3;
    public GameObject device4;

    public Material bubbleMaterial;

    public GameObject leftController;
    public GameObject rightController;

    private Vector3 leftOldPos;
    private Vector3 rightOldPos;

    void Start()
    {
        //leftController = GameObject.Find("ControllerLeft");
    }

    public void OnEnable()
    {
        SteamVR_Utils.Event.Listen("device_connected", OnDeviceConnected);
    }
    public void OnDisable()
    {
        SteamVR_Utils.Event.Remove("device_connected", OnDeviceConnected);
    }

    private void OnDeviceConnected(params object[] args)
    {
        var i = (int)args[0];
        var connected = (bool)args[1];

        var vr = SteamVR.instance;
        var isController = (vr.hmd.GetTrackedDeviceClass((uint)i) == Valve.VR.TrackedDeviceClass.Controller);
        if (isController)
        {
            if (left == 0)
            {
                left = (uint)i;
                Debug.Log("Left connected = " + i);
                if (i == 1)
                {
                    leftController = device1;
                }
                else if (i == 2)
                {
                    leftController = device2;
                }
                else if (i == 3)
                {
                    leftController = device3;
                }
                else if (i == 4)
                {
                    leftController = device4;
                }
                Invoke("makeBubble", 10);
            }

            else if (right == 0)
            {
                right = (uint)i;
                Debug.Log("Right connected = " + i);
                if (i == 1)
                {
                    rightController = device1;
                }
                else if (i == 2)
                {
                    rightController = device2;
                }
                else if (i == 3)
                {
                    rightController = device3;
                }
                else if (i == 4)
                {
                    rightController = device4;
                }
            }

            Debug.Log("Device connection");

        }
    }

    public void makeBubble()
    {
        Debug.Log("Setting material to bubble");
        leftController.GetComponent<Renderer>().materials[0] = bubbleMaterial;
        rightController.GetComponent<Renderer>().materials[0] = bubbleMaterial;
    }

    public void Update()
    {
        var vr = SteamVR.instance;

        LeftIsPressed = GetIsPressed(vr, left);
        RightIsPressed = GetIsPressed(vr, right);

        if (LeftIsPressed && !leftWasPressed)
        {
            GameObject newBubble = (GameObject) Instantiate(bubble, leftController.transform.position, Quaternion.identity);
            newBubble.GetComponent<Rigidbody>().velocity = (leftController.transform.position - leftOldPos) / 3.0f;
            leftController.GetComponent<AudioSource>().Play();

        }

        if (RightIsPressed && !rightWasPressed)
        {
            GameObject newBubble = (GameObject) Instantiate(bubble, rightController.transform.position, Quaternion.identity);
            newBubble.GetComponent<Rigidbody>().velocity = (rightController.transform.position - rightOldPos) / 3.0f;
            rightController.GetComponent<AudioSource>().Play();

        }

        leftWasPressed = LeftIsPressed;
        rightWasPressed = RightIsPressed;
        leftOldPos = leftController.transform.position;
        rightOldPos = rightController.transform.position;
        
        //Debug.Log(string.Format("Left Trigger: {0}    Right Trigger: {1}", LeftIsPressed, RightIsPressed));
    }


    bool GetIsPressed(SteamVR vr, uint controller)
    {
        if (controller == 0)
            return false;
        var state = new VRControllerState_t();
        var success = vr.hmd.GetControllerState(controller, ref state);
        return (state.ulButtonPressed & SteamVR_Controller.ButtonMask.Trigger) != 0;
    }
}