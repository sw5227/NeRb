using Leap.Unity.Attachments;
using UnityEngine;

public class GestureTracker : MonoBehaviour
{
    //The Attachment Hand you want to attach the Cube to
    [SerializeField] AttachmentHand attachmentHand;


    //The Attachment Point you want to attach the Cube to
    AttachmentPointFlags thumbTip = AttachmentPointFlags.ThumbTip;
    AttachmentPointFlags indexTip = AttachmentPointFlags.IndexTip;
    AttachmentPointFlags middleTip = AttachmentPointFlags.MiddleTip;
    AttachmentPointFlags ringTip = AttachmentPointFlags.RingTip;
    AttachmentPointFlags pinkyTip = AttachmentPointFlags.PinkyTip;

    AttachmentPointFlags palm = AttachmentPointFlags.Palm;

    //The Cube that we make
    
    public bool gest1;
    public bool gest2;
    public bool gest3;
    public bool gest4;
    public bool gameStart = false;
    public bool isLeftHand = true;

    private GameObject cube;



    public void StartGestureTracker(bool isLeftHand)
    {
        this.isLeftHand = isLeftHand;

        //Make a basic cube
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Adjust the scale of the cube
        cube.transform.localScale *= 0.1f;

        gameStart = true;

        if (this.isLeftHand)
        {
            attachmentHand = transform.Find("Attachment Hand (Left)").GetComponent<AttachmentHand>();
        }
        else
        {
            attachmentHand = transform.Find("Attachment Hand (Right)").GetComponent<AttachmentHand>();
        }

    }

    public void QuitGestureTracker()
    {
        gameStart = false;
        Destroy(cube.gameObject);
    }


    private void Update()
    {
        if (gameStart)
        {
            //Get the attachment point behaviour of the desired finger and bone
            AttachmentPointBehaviour thumbBeh = attachmentHand.GetBehaviourForPoint(thumbTip);
            AttachmentPointBehaviour indexBeh = attachmentHand.GetBehaviourForPoint(indexTip);
            AttachmentPointBehaviour middleBeh = attachmentHand.GetBehaviourForPoint(middleTip);
            AttachmentPointBehaviour ringBeh = attachmentHand.GetBehaviourForPoint(ringTip);
            AttachmentPointBehaviour pinkyBeh = attachmentHand.GetBehaviourForPoint(pinkyTip);

            AttachmentPointBehaviour palmBeh = attachmentHand.GetBehaviourForPoint(palm);

            gest1 = false;
            gest2 = false;
            gest3 = false;
            gest4 = false;


            cube.transform.position = Vector3.zero;
            cube.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            //If the attachment point exists, make it the parent of the cube and ensure the cube is transformed correctly below it
            if (indexBeh != null)
            {


                // distance from palm to thumb; 0.04 seems to work
                float distP2t = Vector3.Distance(palmBeh.transform.position, thumbBeh.transform.position);
                // 0.04
                float distP2i = Vector3.Distance(palmBeh.transform.position, indexBeh.transform.position);
                // 0.03
                float distP2m = Vector3.Distance(palmBeh.transform.position, middleBeh.transform.position);

                float distP2r = Vector3.Distance(palmBeh.transform.position, ringBeh.transform.position);

                float distP2p = Vector3.Distance(palmBeh.transform.position, pinkyBeh.transform.position);

                if (this.isLeftHand)
                {
                    if (distP2t < 0.045)
                    {
                        //print("Distance to other: " + distP2t);
                        gest4 = true;
                        cube.transform.position = new Vector3(1.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));

                    }
                    else if (distP2i < 0.04)
                    {
                        gest3 = true;
                        cube.transform.position = new Vector3(0.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));

                    }
                    else if (distP2m < 0.03)
                    {
                        gest2 = true;
                        cube.transform.position = new Vector3(-0.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));

                    }
                    else if (distP2p < 0.045)
                    {
                        gest1 = true;
                        cube.transform.position = new Vector3(-1.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));
                    }
                }
                else
                {
                    if (distP2t < 0.045)
                    {
                        //print("Distance to other: " + distP2t);
                        gest1 = true;
                        cube.transform.position = new Vector3(-1.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));

                    }
                    else if (distP2i < 0.04)
                    {
                        gest2 = true;
                        cube.transform.position = new Vector3(-0.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));

                    }
                    else if (distP2m < 0.03)
                    {
                        gest3 = true;
                        cube.transform.position = new Vector3(0.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));

                    }
                    else if (distP2p < 0.045)
                    {
                        gest4 = true;
                        cube.transform.position = new Vector3(1.5f, 0, 1);
                        cube.transform.Rotate(UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f), UnityEngine.Random.Range(0.0f, 90.0f));
                    }
                }



            }
        }


    }
}