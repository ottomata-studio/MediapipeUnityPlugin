using Mediapipe;
using System.Collections.Generic;
using UnityEngine;

namespace Mediapipe {
  class RectListAnnotationController : ListAnnotationController<RectAnnotationController> {
    public void Draw(Transform screenTransform, List<NormalizedRect> rects, bool isFlipped = false) {
      var drawingCount = Mathf.Min(rects.Count, MaxSize);

      for (var i = 0; i < drawingCount; i++) {
        GetAnnotationController(i).Draw(screenTransform, rects[i], isFlipped);
      }

      ClearAll(drawingCount);
    }
  }
}
