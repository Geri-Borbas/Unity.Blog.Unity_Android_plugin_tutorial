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

#import "EPPZ_Alert_iOS_ObjC.h"


extern "C"
{

    
    void _showAlertWithAttributes(const char* title_,
                                  const char* message_,
                                  const char* buttonTitle_,
                                  const char* cancelButtonTitle_,
                                  const char* gameObjectName_)
    {
        [[EPPZ_Alert_iOS instanceForGameObjectName:gameObjectName_]
         showAlertWithTitle:title_
         message:message_
         buttonTitle:buttonTitle_
         cancelButtonTitle:cancelButtonTitle_];
    }
}