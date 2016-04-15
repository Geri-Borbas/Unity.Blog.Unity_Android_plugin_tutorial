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


NSDictionary* _instancesForGameObjectNames = nil;
const char* callbackMethodName = "AlertDidFinishWithResult";


@interface EPPZ_Alert_iOS ()

@property (nonatomic, strong) NSString *gameObjectName;
@property (nonatomic, weak) UIViewController *presentingViewController;

@end


@implementation EPPZ_Alert_iOS


#pragma mark - Instance management (Instance pool keyed by GameObject names)

+(NSDictionary*)instancesForGameObjectNames
{
    if (_instancesForGameObjectNames == nil)
    { _instancesForGameObjectNames = [NSDictionary new]; }
    return _instancesForGameObjectNames;
}

+(EPPZ_Alert_iOS*)instanceForGameObjectName:(const char*) gameObjectName_
{
    NSString *gameObjectName = [NSString stringWithUnityString:gameObjectName_];
    
    // Return cached instance (if any).
    if ([self.instancesForGameObjectNames.allKeys containsObject:gameObjectName])
    { return [self.instancesForGameObjectNames objectForKey:gameObjectName]; }
    
    // Create / cache new instance (if needed).
    EPPZ_Alert_iOS *instance = [self new];
    instance.gameObjectName = gameObjectName; // Store reference
    [self.instancesForGameObjectNames setValue:instance forKey:gameObjectName];
    return instance;
}


#pragma mark - Features

-(void)showAlertWithTitle:(const char*) title_
                  message:(const char*) message_
              buttonTitle:(const char*) buttonTitle_
        cancelButtonTitle:(const char*) cancelButtonTitle_
{
    // Fake "Ok".
    UnitySendMessage(self.gameObjectName.unityString,
                     callbackMethodName,
                     buttonTitle_);
}


@end
