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


	public class EPPZ_Alert_Editor : EPPZ_Alert
	{


		public EPPZ_Alert_Editor(string gameObjectName) : base(gameObjectName) { }


		#region Features

		override public void ShowAlertWithAttributes(string title, string message, string buttonTitle, string cancelButtonTitle)
		{ GameObject.Find(gameObjectName).SendMessage("AlertDidFinishWithResult", buttonTitle); }

		// ...

		#endregion
	}
}