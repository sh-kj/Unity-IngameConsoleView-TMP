using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace radiants.IngameConsole
{
	//,typeof(UnityEngine)
	[RequireComponent(typeof(UnityEngine.UI.Button), typeof(BoxCollider2D), typeof(RectTransform))]
	[ExecuteInEditMode]
	public class ShortcutButton : MonoBehaviour
	{
		[SerializeField]
		private string commandName;

		private CompositeDisposable Disposables = new CompositeDisposable();

		void Start()
		{
			UnityEngine.UI.Button myButton = GetComponent<UnityEngine.UI.Button>();
			myButton.OnClickAsObservable().Subscribe(_ =>
			{
				Console.Log(commandName);
				Console.ExecuteCommand(commandName.Split(' '));
			}).AddTo(Disposables);
		}

		private void OnDestroy()
		{
			Disposables.Dispose();
		}

#if UNITY_EDITOR
		private void Update()
		{
			//sync BoxCollider2D size to RectTransform
			var rectTrans = GetComponent<RectTransform>();
			var collider = GetComponent<BoxCollider2D>();


			collider.offset = (new Vector2(0.5f, 0.5f) - rectTrans.pivot) * rectTrans.rect.size;
			collider.size = rectTrans.rect.size;
		}
#endif
	}
}