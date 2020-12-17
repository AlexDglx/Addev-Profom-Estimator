{\rtf1\ansi\ansicpg1252\cocoartf2513
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\fmodern\fcharset0 Courier;\f1\fmodern\fcharset0 Courier-Bold;\f2\fmodern\fcharset0 Courier-Oblique;
}
{\colortbl;\red255\green255\blue255;\red90\green127\blue230;\red29\green29\blue29;\red197\green197\blue197;
\red34\green34\blue63;\red175\green175\blue175;\red178\green119\blue255;\red87\green183\blue193;\red51\green197\blue124;
\red188\green145\blue90;\red230\green125\blue179;\red217\green174\blue255;\red116\green187\blue89;}
{\*\expandedcolortbl;;\csgenericrgb\c35294\c49804\c90196;\csgenericrgb\c11373\c11373\c11373;\csgenericrgb\c77255\c77255\c77255;
\csgenericrgb\c13333\c13333\c24706;\csgenericrgb\c68627\c68627\c68627;\csgenericrgb\c69804\c46667\c100000;\csgenericrgb\c34118\c71765\c75686;\csgenericrgb\c20000\c77255\c48627;
\csgenericrgb\c73725\c56863\c35294;\csgenericrgb\c90196\c49020\c70196;\csgenericrgb\c85098\c68235\c100000;\csgenericrgb\c45490\c73333\c34902;}
\margl1440\margr1440\vieww10800\viewh8400\viewkind0
\pard\tx560\tx1120\tx1680\tx2240\tx2800\tx3360\tx3920\tx4480\tx5040\tx5600\tx6160\tx6720\pardirnatural\partightenfactor0

\f0\fs26 \cf2 \cb3 public class \cf4 \cb5 LICENSE\cb3  : Window\cf6 , \cf7 IComponentConnector\
  \cf6 \{\
    \cf2 public static bool \cf8 normalMainWindowState\cf6 ;\
    \cf2 internal \cf4 Image \cf8 CloseImage\cf6 ;\
    \cf2 internal \cf4 Image \cf8 MaximizeImage\cf6 ;\
    \cf2 internal \cf4 Image \cf8 MinimizeImage\cf6 ;\
    \cf2 internal \cf4 TextBlock \cf8 licenseTextBlock\cf6 ;\
    \cf2 private bool \cf8 _contentLoaded\cf6 ;\
\
    \cf2 public \cf7 LICENSE\cf6 ()\
    \{\
      \cf2 base\cf6 .\cf4 \\u002Ector\cf6 ();\
      \cf2 this\cf6 .\cf9 InitializeComponent\cf6 ();\
      \cf7 StreamReader \cf6 streamReader = \cf2 new \cf7 StreamReader\cf6 (\cf10 "LICENSE.txt"\cf6 );\
      \cf2 this\cf6 .\cf8 licenseTextBlock\cf6 .\cf4 set_Text\cf6 (streamReader.\cf9 ReadToEnd\cf6 ());\
      streamReader.\cf9 Close\cf6 ();\
    \}\
\
    \cf2 private void \cf9 CloseImage_MouseDown\cf6 (\cf2 object \cf6 sender, \cf4 MouseButtonEventArgs \cf6 e) \cf4 => \cf2 this\cf6 .\cf4 Close\cf6 ();\
\
    \cf2 private void \cf9 MaximizeImage_MouseDown\cf6 (\cf2 object \cf6 sender, \cf4 MouseButtonEventArgs \cf6 e)\
    \{\
      \cf2 if \cf6 (\cf4 !\cf7 LICENSE\cf6 .\cf8 normalMainWindowState\cf6 )\
      \{\
        \cf7 LICENSE\cf6 .\cf8 normalMainWindowState \cf6 = \cf2 true\cf6 ;\
        \cf2 this\cf6 .\cf4 set_WindowState\cf6 ((\cf4 WindowState\cf6 ) \cf11 0\cf6 );\
      \}\
      \cf2 else\
      \cf6 \{\
        \cf7 LICENSE\cf6 .\cf8 normalMainWindowState \cf6 = \cf2 false\cf6 ;\
        \cf2 this\cf6 .\cf4 set_WindowState\cf6 ((\cf4 WindowState\cf6 ) \cf11 2\cf6 );\
      \}\
    \}\
\
    \cf2 private void \cf9 MinimizeImage_MouseDown\cf6 (\cf2 object \cf6 sender, \cf4 MouseButtonEventArgs \cf6 e) \cf4 => \cf2 this\cf6 .\cf4 set_WindowState\cf6 ((\cf4 WindowState\cf6 ) \cf11 1\cf6 );\
\
    \cf2 private void \cf9 Menu_MouseMove\cf6 (\cf2 object \cf6 sender, \cf4 MouseEventArgs \cf6 e)\
    \{\
      \cf2 if \cf6 (e.\cf4 get_LeftButton\cf6 () != \cf11 1\cf6 )\
        \cf2 return\cf6 ;\
      \cf2 this\cf6 .\cf4 DragMove\cf6 ();\
    \}\
\
    \cf2 private void \cf9 Menu_MouseDoubleClick\cf6 (\cf2 object \cf6 sender, \cf4 MouseButtonEventArgs \cf6 e)\
    \{\
      \cf2 if \cf6 (((\cf4 MouseEventArgs\cf6 ) e).\cf4 get_LeftButton\cf6 () == \cf11 1 \cf6 && \cf4 !\cf7 LICENSE\cf6 .\cf8 normalMainWindowState\cf6 )\
      \{\
        \cf7 LICENSE\cf6 .\cf8 normalMainWindowState \cf6 = \cf2 true\cf6 ;\
        \cf2 this\cf6 .\cf4 set_WindowState\cf6 ((\cf4 WindowState\cf6 ) \cf11 0\cf6 );\
      \}\
      \cf2 else\
      \cf6 \{\
        \cf7 LICENSE\cf6 .\cf8 normalMainWindowState \cf6 = \cf2 false\cf6 ;\
        \cf2 this\cf6 .\cf4 set_WindowState\cf6 ((\cf4 WindowState\cf6 ) \cf11 2\cf6 );\
      \}\
    \}\
\
    [\cf7 DebuggerNonUserCode\cf6 ]\
    [\cf7 GeneratedCode\cf6 (\cf10 "PresentationBuildTasks"\cf6 , \cf10 "4.0.0.0"\cf6 )]\
    \cf2 public void \cf9 InitializeComponent\cf6 ()\
    \{\
      \cf2 if \cf6 (\cf2 this\cf6 .\cf8 _contentLoaded\cf6 )\
        \cf2 return\cf6 ;\
      \cf2 this\cf6 .\cf8 _contentLoaded \cf6 = \cf2 true\cf6 ;\
      \cf4 Application\cf6 .\cf4 LoadComponent\cf6 ((\cf2 object\cf6 ) \cf2 this\cf6 , \cf2 new \cf7 Uri\cf6 (\cf10 "/Addev Profom Estimator;component/license.xaml"\cf6 , \cf12 UriKind\cf6 .
\f1\b \cf8 Relative
\f0\b0 \cf6 ));\
    \}\
\
    [\cf7 DebuggerNonUserCode\cf6 ]\
    [\cf7 GeneratedCode\cf6 (\cf10 "PresentationBuildTasks"\cf6 , \cf10 "4.0.0.0"\cf6 )]\
    [\cf7 EditorBrowsable\cf6 (\cf12 EditorBrowsableState\cf6 .
\f1\b \cf8 Never
\f0\b0 \cf6 )]\
    \cf2 void \cf7 IComponentConnector\cf6 .\cf9 Connect\cf6 (\cf2 int \cf6 connectionId, \cf2 object \cf6 target)\
    \{\
      \cf2 switch \cf6 (connectionId)\
      \{\
        \cf2 case \cf11 1\cf4 :\
          
\f2\i \cf13 // ISSUE: method pointer\
          
\f0\i0 \cf6 ((\cf4 UIElement\cf6 ) target).\cf4 add_MouseMove\cf6 (\cf2 new \cf4 MouseEventHandler\cf6 ((\cf2 object\cf6 ) \cf2 this\cf6 , \cf4 __methodptr\cf6 (\cf9 Menu_MouseMove\cf6 )));\
          
\f2\i \cf13 // ISSUE: method pointer\
          
\f0\i0 \cf6 ((\cf4 Control\cf6 ) target).\cf4 add_MouseDoubleClick\cf6 (\cf2 new \cf4 MouseButtonEventHandler\cf6 ((\cf2 object\cf6 ) \cf2 this\cf6 , \cf4 __methodptr\cf6 (\cf9 Menu_MouseDoubleClick\cf6 )));\
          \cf2 break\cf6 ;\
        \cf2 case \cf11 2\cf4 :\
          \cf2 this\cf6 .\cf8 CloseImage \cf6 = (\cf4 Image\cf6 ) target;\
          
\f2\i \cf13 // ISSUE: method pointer\
          
\f0\i0 \cf6 ((\cf4 UIElement\cf6 ) \cf2 this\cf6 .\cf8 CloseImage\cf6 ).\cf4 add_MouseDown\cf6 (\cf2 new \cf4 MouseButtonEventHandler\cf6 ((\cf2 object\cf6 ) \cf2 this\cf6 , \cf4 __methodptr\cf6 (\cf9 CloseImage_MouseDown\cf6 )));\
          \cf2 break\cf6 ;\
        \cf2 case \cf11 3\cf4 :\
          \cf2 this\cf6 .\cf8 MaximizeImage \cf6 = (\cf4 Image\cf6 ) target;\
          
\f2\i \cf13 // ISSUE: method pointer\
          
\f0\i0 \cf6 ((\cf4 UIElement\cf6 ) \cf2 this\cf6 .\cf8 MaximizeImage\cf6 ).\cf4 add_MouseDown\cf6 (\cf2 new \cf4 MouseButtonEventHandler\cf6 ((\cf2 object\cf6 ) \cf2 this\cf6 , \cf4 __methodptr\cf6 (\cf9 MaximizeImage_MouseDown\cf6 )));\
          \cf2 break\cf6 ;\
        \cf2 case \cf11 4\cf4 :\
          \cf2 this\cf6 .\cf8 MinimizeImage \cf6 = (\cf4 Image\cf6 ) target;\
          
\f2\i \cf13 // ISSUE: method pointer\
          
\f0\i0 \cf6 ((\cf4 UIElement\cf6 ) \cf2 this\cf6 .\cf8 MinimizeImage\cf6 ).\cf4 add_MouseDown\cf6 (\cf2 new \cf4 MouseButtonEventHandler\cf6 ((\cf2 object\cf6 ) \cf2 this\cf6 , \cf4 __methodptr\cf6 (\cf9 MinimizeImage_MouseDown\cf6 )));\
          \cf2 break\cf6 ;\
        \cf2 case \cf11 5\cf4 :\
          \cf2 this\cf6 .\cf8 licenseTextBlock \cf6 = (\cf4 TextBlock\cf6 ) target;\
          \cf2 break\cf6 ;\
        \cf2 default\cf4 :\
          \cf2 this\cf6 .\cf8 _contentLoaded \cf6 = \cf2 true\cf6 ;\
          \cf2 break\cf6 ;\
      \}\
    \}\
  \}\
\}\
\
}