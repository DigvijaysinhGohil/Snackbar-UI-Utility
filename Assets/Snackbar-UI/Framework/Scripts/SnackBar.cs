using UnityEngine;
using UnityEngine.UI;

namespace DigvijaysinhG {

    namespace SnackBarUtility {

        public class SnackBar {
            private static Canvas canvas;
            private static SnackBarUi snackBarUi;

            private static void Prepare() {
                if (canvas == null) {
                    CreateCanvas();
                }

                if (snackBarUi == null) {
                    snackBarUi = GameObject.Instantiate(Resources.Load<SnackBarUi>("SnackBar"), canvas.transform);
                }
            }

            private static void CreateCanvas() {
                GameObject canvasObject = new GameObject("SnackBar - Canvas");
                canvas = canvasObject.AddComponent<Canvas>();
                canvas.sortingOrder = 1000;
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasScaler.referenceResolution = new Vector2(1920, 1080);
                canvasScaler.matchWidthOrHeight = .5f;
                canvasObject.AddComponent<GraphicRaycaster>();
            }

            public static void Show(string message) {
                Prepare();
                snackBarUi.Show(message);
            }

            public static void Hide() {
                if (snackBarUi == null) {
                    return;
                }
                
                snackBarUi.Hide();
            }
        }

    }

}