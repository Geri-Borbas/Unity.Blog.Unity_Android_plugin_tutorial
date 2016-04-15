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
using System.Collections;


namespace EPPZ.Plugins
{


	public class EPPZ_Alert
	{


		#region Native setup

		protected string gameObjectName;

		public static EPPZ_Alert pluginWithGameObjectName(string gameObjectName)
		{
			EPPZ_Alert plugin;

			// Get plugin class for the actual platform.
			#if UNITY_IPHONE
			plugin = (Application.isEditor)
			? (EPPZ_Alert)new EPPZ_Alert_Editor(gameObjectName)
			: (EPPZ_Alert)new EPPZ_Alert_iOS(gameObjectName);
			#elif UNITY_ANDROID
			plugin = (Application.isEditor)
				? (EPPZ_Alert)new EPPZ_Alert_Editor(gameObjectName)
				: (EPPZ_Alert)new EPPZ_Alert_Android(gameObjectName);
			#endif

			return plugin;
		}

		public EPPZ_Alert(string gameObjectName)
		{
			this.gameObjectName = gameObjectName;
			Setup();
		}

		virtual protected void Setup() { }

		#endregion


		#region Features

		virtual public void ShowAlertWithAttributes(string title, string message, string buttonTitle, string cancelButtonTitle) { }

		// ...

		#endregion
	}
}
