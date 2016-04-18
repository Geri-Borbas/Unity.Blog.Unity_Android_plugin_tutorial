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

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "UnityString.m"


extern void UnitySendMessage(const char *, const char *, const char *);


@interface EPPZ_Alert_iOS : NSObject

+(EPPZ_Alert_iOS*)instanceForGameObjectName:(const char*) gameObjectName_;
-(void)showAlertWithTitle:(const char*) title_
                  message:(const char*) message_
              buttonTitle:(const char*) buttonTitle_
        cancelButtonTitle:(const char*) cancelButtonTitle_;

@end
