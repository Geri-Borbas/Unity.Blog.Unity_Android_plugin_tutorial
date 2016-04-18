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

#import "NSString+Unity.h"


@implementation NSString (Unity)

+(NSString*)stringWithUnityString:(const char*) unityString_
{
    if (unityString_ == nil) return [NSString new];
    return [NSString stringWithUTF8String:unityString_];
}

-(char*)unityString
{
    const char* cString = self.UTF8String;
    char* _unityString = (char*)malloc(strlen(cString) + 1);
    strcpy(_unityString, cString);
    return _unityString;
}

@end
