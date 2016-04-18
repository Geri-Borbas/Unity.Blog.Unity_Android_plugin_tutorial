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
using System.Runtime.InteropServices;


namespace EPPZ.Plugins
{


	public class EPPZ_Alert_iOS : EPPZ_Alert
	{


		public EPPZ_Alert_iOS(string gameObjectName) : base(gameObjectName) { }


		#region Native setup

		[DllImport ("__Internal")]
		private static extern void _showAlertWithAttributes(
			string title_,
			string message_,
			string buttonTitle_,
			string cancelButtonTitle_,
			string gameObjectName_
		);

		#endregion


		#region Features

		override public void ShowAlertWithAttributes(
			string title,
			string message,
			string buttonTitle,
			string cancelButtonTitle)
		{
			Debug.Log("EPPZ_Alert_iOS.ShowAlertWithAttributes(`"+title+"`, `"+message+"`, `"+buttonTitle+"`, `"+cancelButtonTitle+"`, )");
			_showAlertWithAttributes(
				title,
				message,
				buttonTitle,
				cancelButtonTitle,
				gameObjectName
			);
		}

		// ...

		#endregion
	}
}