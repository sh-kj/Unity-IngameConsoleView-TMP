using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace radiants.IngameConsole
{
	[DefaultExecutionOrder(-10000)]

	public class CommandInjector : MonoBehaviour
	{
		private void Awake()
		{
			Console.Initialize(typeof(ConsoleCommands));
		}
	}
}