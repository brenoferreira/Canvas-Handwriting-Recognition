using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Ink;
using System.Windows.Input;
using Newtonsoft.Json;

namespace eWriter.Web.Controllers
{
    public class RecognitionController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage<String> Recognize(string strokes)
        {
            var strokePointsData = JsonConvert.DeserializeObject<dynamic>(strokes);

            var strokeCollection = GetStrokeCollectionFromPoints(strokePointsData);

            var inkAnalyzer = new InkAnalyzer();

            inkAnalyzer.AddStrokes(strokeCollection);

            var analysisStatus = inkAnalyzer.Analyze();

            if (analysisStatus.Successful)
            {
                var recognizedString = inkAnalyzer.GetRecognizedString();
                return new HttpResponseMessage<string>(recognizedString);
            }
            else
                return new HttpResponseMessage<string>("Data not recognized");
        }

        private StrokeCollection GetStrokeCollectionFromPoints(dynamic strokePoints)
        {
            var strokeCollection = new StrokeCollection();

            foreach (var stroke in strokePoints.Strokes)
            {
                var points = new StylusPointCollection();

                foreach (var point in stroke.Points)
                {
                    var x = (float)point.X;
                    var y = (float)point.Y;

                    points.Add(new StylusPoint(x, y));
                }

                strokeCollection.Add(new Stroke(points));
            }

            return strokeCollection;
        }
    }
}
