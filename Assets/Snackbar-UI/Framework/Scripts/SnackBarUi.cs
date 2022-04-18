using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace DigvijaysinhG {

    namespace SnackBarUtility {

        public class SnackBarUi : MonoBehaviour {
            private float height;

            [SerializeField] private float animationTimeInSeconds = .5f;
            [HideInInspector] public bool autoHide = true;
            [HideInInspector] public float durationInSeconds = 5;

            [HideInInspector] public bool overrideWithCurve;
            [HideInInspector] public AnimationCurve easeCurve = AnimationCurve.Linear(0, 0, 1, 1);
            [HideInInspector] public LeanTweenType easeType = LeanTweenType.easeOutCubic;

            private RectTransform rectTransform;
            private TMP_Text tmpMessage;

            private RectTransform TransformRect {
                get {
                    if (rectTransform == null) {
                        rectTransform = GetComponent<RectTransform>();
                    }

                    return rectTransform;
                }
            }

            private TMP_Text TmpMessage {
                get {
                    if (tmpMessage == null) {
                        tmpMessage = GetComponentInChildren<TMP_Text>();
                    }

                    return tmpMessage;
                }
            }

            private void OnDisable() {
                LeanTween.cancel(gameObject);
                CancelInvoke(nameof(Hide));
            }

            private void Slide(float from, float to, UnityAction OnTweenComplete = null) {
                LeanTween.cancel(gameObject);
                LTDescr tween = LeanTween.value(gameObject, from, to, animationTimeInSeconds);

                if (overrideWithCurve) { tween.setEase(easeCurve); }
                else { tween.setEase(easeType); }

                tween.setOnUpdate(value => { TransformRect.anchoredPosition = Vector2.up * value; });
                tween.setOnComplete(() => OnTweenComplete?.Invoke());
            }

            private IEnumerator CrShow(string message) {
                TmpMessage.text = $"{message}";
                yield return new WaitForEndOfFrame();
                height = TransformRect.sizeDelta.y;
                Slide(-height, 0f);

                if (autoHide) {
                    Invoke(nameof(Hide), durationInSeconds);
                }
            }

            public void Show(string message) {
                gameObject.SetActive(true);
                CancelInvoke(nameof(Hide));
                StartCoroutine(CrShow(message));
            }

            public void Hide() {
                Slide(0, -height, () => gameObject.SetActive(false));
            }
        }

        #if UNITY_EDITOR
        [CustomEditor(typeof(SnackBarUi))]
        public class SnackBarUiEditor : Editor {
            public override void OnInspectorGUI() {
                base.OnInspectorGUI();

                SnackBarUi snackBarUi = target as SnackBarUi;

                snackBarUi.autoHide = GUILayout.Toggle(snackBarUi.autoHide, "Auto hide");

                if (snackBarUi.autoHide) {
                    snackBarUi.durationInSeconds =
                        EditorGUILayout.FloatField("Duration in seconds", snackBarUi.durationInSeconds);
                }

                snackBarUi.overrideWithCurve = GUILayout.Toggle(snackBarUi.overrideWithCurve, "Override with curve");

                if (snackBarUi.overrideWithCurve) {
                    snackBarUi.easeCurve =
                        EditorGUILayout.CurveField("Ease curve", snackBarUi.easeCurve);
                }
                else {
                    snackBarUi.easeType = (LeanTweenType) EditorGUILayout.EnumPopup("Ease type", snackBarUi.easeType);
                }
            }
        }
        #endif

    }

}