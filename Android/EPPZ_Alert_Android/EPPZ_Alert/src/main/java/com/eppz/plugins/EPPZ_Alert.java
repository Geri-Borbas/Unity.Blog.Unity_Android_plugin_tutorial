//
// Copyright (c) 2016 eppz! mobile, Gergely Borbás (SP)
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

package com.eppz.plugins;

// Features.
import android.app.Activity;
import android.app.Fragment;
import android.content.Context;
import android.os.Bundle;

// Unity.
import com.unity3d.player.UnityPlayer;

// Debug.
import android.util.Log;


public class EPPZ_Alert extends Fragment
                        implements EPPZ_DialogFragment.Listener
{


    // Constants.
    public static final String TAG = "EPPZ_Alert_Fragment";
    private static final String CALLBACK_METHOD_NAME = "AlertDidFinishWithResult";

    // Singleton instance.
    public static EPPZ_Alert instance;

    // Unity context.
    String gameObjectName;


    // region Creation

    public static void start(String gameObjectName)
    {
        // Instantiate and add to Unity Player Activity.
        instance = new EPPZ_Alert();
        instance.gameObjectName = gameObjectName; // Store `GameObject` reference
        UnityPlayer.currentActivity.getFragmentManager().beginTransaction().add(instance, EPPZ_Alert.TAG).commit();
    }

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setRetainInstance(true); // Retain between configuration changes (like device rotation)
    }

    // endregion


    // region Plugin features

    public void showAlertWithAttributes(String title, String message, String positiveButtonTitle, String negativeButtonTitle)
    {
        Log.i(TAG, TAG+".showAlertWithAttributes(`"+title+"`, `"+message+"`, `"+positiveButtonTitle+"`, `"+negativeButtonTitle+"`)");

        // Create and show dialog.
        EPPZ_DialogFragment dialogFragment = EPPZ_DialogFragment.newInstance(
                title,
                message,
                positiveButtonTitle,
                negativeButtonTitle
        );
        dialogFragment.show(getFragmentManager(), title);
    }

    @Override
    public void dialogDidFinishWithResult(EPPZ_DialogFragment dialog, String selectedButtonTitle)
    {
        Log.i(TAG, TAG+".dialogDidFinishWithResult(selectedButtonTitle: `"+selectedButtonTitle+"`)");

        // Call back to Unity.
        SendUnityMessage(CALLBACK_METHOD_NAME, selectedButtonTitle);
    }

    // endregion


    // region Utilities

    void SendUnityMessage(String methodName, String parameter)
    {
        Log.i(TAG, TAG+"SendUnityMessage(`"+methodName+"`, `"+parameter+"`)");
        UnityPlayer.UnitySendMessage(gameObjectName, methodName, parameter);
    }

    // endregion
}