   M S B A M L   `   `   `  ���� A  =MMS.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MMS.UI.DefaultMMS.UI.Default  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   DefaultWindowTemplate �� 
TargetType    MMS.UI.Default.Window J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   Color ��Name	 ]�Name
 �� Orientation ��Name  win_btn_mini � FocusVisualStyle  win_btn_max  win_btn_restore  win_btn_close ��Name �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  DefaultWindowStyle �� 
TargetType�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     &localclr-namespace:MMS.UI.Default  8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006    �� $6 0/MMS.UI;Component/Default/Resource/Resource.xaml?�%!  &	        7  7  7  7  &	 P    7   �� "   .R�� $��0q�   $ 10Q�$ 0Q�$	 0.6Q�.+��� ���	#FF636363$��1q����	#FFB6B6B6._��� ���	#FF7A7A7A$��1q�$��6,30,6,6q����	#FFFFFFFF�� $��TitleTextBlock��$��38,6,0,0q�$
��Wrap=�$�� ��$	��Top=�$��Segoe UI)�$��14(����	#FF333333   $ White��$ 0Q�$ 8Q�$ 1Q��� ._��� $
 logo��$
��Left=�$��24��$��24��$��10,5,0,0q�$��UniformToFill=�$	��Top=�� .+�]� $	 titleBorder��$	��Top=���.  $��0q�$
��auto��
������ .+��� $��Right=�$
 
Horizontal=�$��0,1,6,0q�.+��� $ minBtn����.  $	��Min��$
��Left=�$��20��$��26��$��0,0,1,0q�$	��Top=�8��   Z� �� $ maxBtn����.  $	��Max��$
��Left=�$��20��$��25��$��0,0,1,0q�$	��Top=�8��  Z� �� $ 
restoreBtn����.  $��Restore��$
��Left=�$��20��$��25��$��0,0,1,0q�$	��Top=�8�� $y�	Collapsed=� Z� �� $ closeBtn����.  $��Close��$
��Left=�$��20��$��45��$��0,0,1,0q�$	��Top=�8��  Z� � $��8,32,8,8q����#293955.+��� .u��� �� $ WindowResizeGrip��$��Right=�$��Bottom=�$y�	Collapsed=���.   P�  �@�
ResizeMode$ CanResizeWithGrip=�. ��� $ WindowResizeGrip�� � y�$ Visible=�P�  �@�WindowState$ 	Maximized=�. ��� $ maxBtn�� � y�$ 	Collapsed=��� $ 
restoreBtn�� � y�$ Visible=��� "   .���  �@J�SnapsToDevicePixels . ��  � ��8   ��  �@�AllowsTransparency . ��  �@�WindowStyle$
 None=���  � ��$	 500��