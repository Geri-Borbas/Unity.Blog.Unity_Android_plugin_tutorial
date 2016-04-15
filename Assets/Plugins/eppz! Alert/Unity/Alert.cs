//
// Copyright (c) 2016 eppz! mobile (Gergely Borbás SP)
//
// http://www.twitter.com/_eppz
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;


namespace EPPZ.Plugins
{


	/// <summary>
	/// Shows a native alert that calls back with the title of the selected button.
	/// Currently support iOS and Android (Editor calls back with a simulated "Ok").
	/// </summary>

	public class Alert : MonoBehaviour
	{


		#region User hooks

		[System.Serializable]
		public class Text
		{
			public string title;
			public string message;
			public string buttonTitle = "Ok";
			public string cancelButtonTitle = "Cancel";
		}
		public Text text;

		[System.Serializable]
		public class StringEvent : UnityEvent<string> {}
		public StringEvent alertDidFinishWithResult;

		// ...

		#endregion


		#region Creation

		private EPPZ_Alert plugin;

		void Start()
		{
			// Create plugin instance (of whichever platform).
			plugin = EPPZ_Alert.pluginWithGameObjectName(gameObject.name);
		}

		#endregion


		#region Features

		public void Show()
		{
			// Call plugin (of whichever platform).
			plugin.ShowAlertWithAttributes(
				text.title,
				text.message,
				text.buttonTitle,
				text.cancelButtonTitle
			);
		}

		// ...

		#endregion


		#region Plugin callbacks (from whichever platform)

		// TODO: Make it mandatory with `IEPPZ_Alert`.
		public void AlertDidFinishWithResult(string selectedButtonTitle)
		{
			// Call event hooked in.
			alertDidFinishWithResult.Invoke(selectedButtonTitle);
		}

		// ...

		#endregion
	}
}