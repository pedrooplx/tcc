using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using Keras.Models;
using Numpy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Dnn;
using Python.Runtime;

namespace IaEngine
{
    public static class IaEngine
    {
        static BaseModel emotion_classifier;
        static CascadeClassifier face_detection;
        static string[] emotions = new string[] { "angry", "disgust", "scared", "happy", "sad", "surprised", "neutral" };
        static string basePath = Directory.GetCurrentDirectory().Replace("ProxyIA\\ProxyIA", "ProxyIA\\IaEngine");
        public static void Load()
        {
            if (!PythonEngine.IsInitialized) { PythonEngine.Initialize(); }
            //emotion_classifier = Sequential.ModelFromJson(File.ReadAllText(basePath + "\\models\\model.json"));
            //emotion_classifier.LoadWeight(basePath + "\\models\\model.h5");
            emotion_classifier = BaseModel.LoadModel(basePath + "\\models\\model.h5");
            face_detection = new CascadeClassifier(basePath + "\\models\\haarcascade_frontalface_default.xml");
            PythonEngine.BeginAllowThreads();
        }
        public static List<Tuple<string, double>> AnalisarFace(string base64Image)
        {
            using (Py.GIL())
            {
                string ImagePath = basePath + "\\work\\" + Guid.NewGuid() + ".jpg";
                byte[] bytes = Convert.FromBase64String(base64Image);

                using (var ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    System.Drawing.Image tempImage = System.Drawing.Image.FromStream(ms, true);
                    tempImage.Save(ImagePath);
                }

                Image<Gray, Byte> image = new Image<Gray, Byte>(ImagePath);
                File.Delete(ImagePath);
                List<Rectangle> recFaces = new List<Rectangle>();
                List<Image<Gray, Byte>> imgFaces = new List<Image<Gray, Byte>>();

                using (Image<Gray, Byte> gray = image)
                {
                    gray._EqualizeHist();

                    Rectangle[] facesDetected = face_detection.DetectMultiScale(
                       gray,
                       1.1,
                       10,
                       new Size(48, 48),
                       Size.Empty);
                    recFaces.AddRange(facesDetected);

                    foreach (Rectangle rec in facesDetected)
                        imgFaces.Add(image.GetSubRect(rec));
                }

                List<Tuple<string, double>> aIResponse = new List<Tuple<string, double>>();

                foreach (Image<Gray, Byte> face in imgFaces)
                {
                    Image<Gray, Byte> Area = face.Resize(48, 48, Inter.Area);
                    byte[,,] data = Area.Data;
                    NDarray exp = np.expand_dims(data, 0);
                    NDarray convert = exp.astype(np.float32) / 255;
                    var pred = emotion_classifier.Predict(convert)[0];
                    var emotion_probability = np.max(pred);
                    aIResponse.Add(new Tuple<string, double>(emotions[int.Parse(pred.argmax().ToString())], System.Math.Round(double.Parse(emotion_probability.repr.Replace(".", ",")) * 100, 2)));
                }

                return aIResponse;
            }
        }
    }
}
