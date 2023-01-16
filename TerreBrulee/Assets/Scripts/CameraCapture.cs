using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Drawing;
using System.Threading;

public class CameraCapture : MonoBehaviour
{
    VideoCapture webcam;
    Mat img = new Mat();
    public RawImage webcamScreen;
    CascadeClassifier faceDetector;

    [SerializeField]
    Vector3 infBornBlue;
    [SerializeField]
    Vector3 suppBornBlue;

    // Start is called before the first frame update
    void Start()
    {
        webcam = new VideoCapture(0, VideoCapture.API.DShow);
        webcam.ImageGrabbed += HandleWebcamQueryFrame;
        webcam.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (webcam.IsOpened)
        {
            webcam.Grab();
            DisplayFrameOnPlan();
        }
        
    }

    private void HandleWebcamQueryFrame(object sender, System.EventArgs e)
    {
        webcam.Retrieve(img, 0);

        if (!img.IsEmpty)
        {
            
        }
    }

    void DisplayFrameOnPlan()
    {
        //Création de la texture
        int width = webcam.Width;
        int height = webcam.Height;
        Texture2D textImage = new Texture2D(width, height, TextureFormat.RGBA32, false);

        //Conversion de l'image
        //CvInvoke.Resize(img, img, new System.Drawing.Size(width, height));
        CvInvoke.CvtColor(img, img, ColorConversion.Bgr2Rgba);
        CvInvoke.Flip(img, img, 0);
        CvInvoke.Flip(img, img, Emgu.CV.CvEnum.FlipType.Horizontal);

        // HSV
        Emgu.CV.Image<Hsv, byte> hsv = new Emgu.CV.Image<Hsv, byte>(img.Width, img.Height);
        CvInvoke.CvtColor(img, hsv, ColorConversion.Bgr2Hsv);
        //CvInvoke.Imshow("Hsv", hsv);

        // Seui hsv
        Hsv borneInfBlue = new Hsv(infBornBlue.x, infBornBlue.y, infBornBlue.z);
        Hsv borneSuppBlue = new Hsv(suppBornBlue.x, suppBornBlue.y, suppBornBlue.z);

        Emgu.CV.Image<Gray, byte> treshHSVBlue = hsv.InRange(borneInfBlue, borneSuppBlue);
        treshHSVBlue = treshHSVBlue.Erode(3);
        treshHSVBlue = treshHSVBlue.Dilate(6);

        Mat hier = new Mat();
        Emgu.CV.Util.VectorOfVectorOfPoint contoursBlue = new Emgu.CV.Util.VectorOfVectorOfPoint();

        CvInvoke.FindContours(treshHSVBlue, contoursBlue, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
       
        CvInvoke.DrawContours(img, contoursBlue, 0, new MCvScalar(255, 255, 255), 2);

        Moments mBlue = CvInvoke.Moments(treshHSVBlue);

        int cGx = (int)(mBlue.M10 / mBlue.M00);
        int cGy = (int)(mBlue.M01 / mBlue.M00);
        System.Drawing.Point pBlue = new System.Drawing.Point(cGx, cGy);

        CvInvoke.Circle(img, pBlue, 10, new MCvScalar(255, 0, 0), 2);

        if(pBlue.X > -500000)
            Debug.Log(pBlue);
        //Copie de l'image sur la texture
        textImage.LoadRawTextureData(img.ToImage<Rgba, byte>().Bytes);
        textImage.Apply();
        
        //Ajout de la texture a webcamScreen
        webcamScreen.texture = textImage;
        

        Thread.Sleep(50);
    }

    private void OnDestroy()
    {
        webcam.Stop();
        webcam.Dispose();
    }
}
