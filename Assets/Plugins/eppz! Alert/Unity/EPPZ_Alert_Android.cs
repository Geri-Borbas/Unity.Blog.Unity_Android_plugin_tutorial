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


	public class EPPZ_Alert_Android : EPPZ_Alert
	{
		

		public EPPZ_Alert_Android(string gameObjectName) : base(gameObjectName) { }


		#region Native setup

		AndroidJavaClass _class;
		AndroidJavaObject instance { get { return _class.CallStatic<AndroidJavaObject>("getInstance"); } }

		override protected void Setup()
		{
			Debug.Log("EPPZ_Alert_Android.Setup()");

			// Get Unity player `Activity`.
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject unityPlayerActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

			// Start plugin `Fragment`.
			_class = new AndroidJavaClass("com.eppz.plugins.EPPZ_Alert");
			_class.CallStatic("start", unityPlayerActivity, gameObjectName);
		}

		#endregion


		#region Features

		override public void ShowAlertWithAttributes(string title, string message, string buttonTitle, string cancelButtonTitle)
		{
			Debug.Log("EPPZ_Alert_Android.ShowAlertWithAttributes(`"+title+"`, `"+message+"`, `"+buttonTitle+"`, `"+cancelButtonTitle+"`, )");
			instance.Call("showAlertWithAttributes", title, message, buttonTitle, cancelButtonTitle);
		}

		#endregion
	}
}