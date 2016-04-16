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
import android.content.Context;
import android.app.Activity;
import android.app.Dialog;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.app.DialogFragment;
import android.os.Bundle;

// Debug.
import android.util.Log;


// Implemented according http://developer.android.com/guide/topics/ui/dialogs.html
public class EPPZ_DialogFragment extends DialogFragment
{


    // Constants.
    private static final String TAG = "EPPZ_DialogFragment";
    private static final String TITLE = "TITLE";
    private static final String MESSAGE = "MESSAGE";
    private static final String POSITIVE_BUTTON_TITLE = "POSITIVE_BUTTON_TITLE";
    private static final String NEGATIVE_BUTTON_TITLE = "NEGATIVE_BUTTON_TITLE";

    // Listener interface.
    public interface Listener
    { void dialogDidFinishWithResult(EPPZ_DialogFragment dialog, String selectedButtonTitle); }
    Listener listener;


    public static EPPZ_DialogFragment newInstance(String title, String message, String positiveButtonTitle, String negativeButtonTitle)
    {
        Log.i(TAG, TAG+".newInstance(`"+title+"`, `"+message+"`, `"+positiveButtonTitle+"`, `"+negativeButtonTitle+"`)");

        EPPZ_DialogFragment instance = new EPPZ_DialogFragment();

        // Bundle arguments.
        Bundle arguments = new Bundle(4);
        arguments.putString(TITLE, title);
        arguments.putString(MESSAGE, message);
        arguments.putString(POSITIVE_BUTTON_TITLE, positiveButtonTitle);
        arguments.putString(NEGATIVE_BUTTON_TITLE, negativeButtonTitle);
        instance.setArguments(arguments);

        return instance;
    }

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState)
    {
        Log.i(TAG, TAG+".onCreateDialog(`"
                +getArguments().getString(TITLE)+"`, `"
                +getArguments().getString(MESSAGE)+"`, `"
                +getArguments().getString(POSITIVE_BUTTON_TITLE)+"`, `"
                +getArguments().getString(NEGATIVE_BUTTON_TITLE)+"`)");

        // Get main fragment.
        EPPZ_Alert alert = (EPPZ_Alert)getFragmentManager().findFragmentByTag(EPPZ_Alert.TAG);
        listener = (Listener)alert;

        // Build dialog.
        return new AlertDialog.Builder(getActivity())
                .setTitle(getArguments().getString(TITLE))
                .setMessage(getArguments().getString(MESSAGE))
                .setPositiveButton(
                        getArguments().getString(POSITIVE_BUTTON_TITLE),
                        new DialogInterface.OnClickListener()
                        {
                            public void onClick(DialogInterface dialog, int whichButton)
                            { listener.dialogDidFinishWithResult(EPPZ_DialogFragment.this, EPPZ_DialogFragment.this.getArguments().getString(POSITIVE_BUTTON_TITLE)); }
                        }
                )
                .setNegativeButton(
                        getArguments().getString(NEGATIVE_BUTTON_TITLE),
                        new DialogInterface.OnClickListener()
                        {
                            public void onClick(DialogInterface dialog, int whichButton)
                            { listener.dialogDidFinishWithResult(EPPZ_DialogFragment.this, EPPZ_DialogFragment.this.getArguments().getString(NEGATIVE_BUTTON_TITLE)); }
                        }
                )
                .create();
    }
}