   M S B A M L   `   `   `  ����D  @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel  5   	   ? ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView 5   	      View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @	viewModel*clr-namespace:ViewModel;assembly=ViewModel     5   	   $localclr-namespace:View     5   	     � Title$  
MainWindow��5	   	   $	��700��6   $	��900��6)   .��5
      �  � DataContext 5   
   #   ViewModel.ViewModelController  5       � ColumnDefinitions 5   
   �� 5      $	��800 �6   �� 5      $	��100 �6   .+�5   
   �� $��Center=�6   $��0,16,0,0q�6/    �� TextWrapping$
 Wrap=�6A   $	��Top=�6r   $��70��6�   $��18��6�   $��1��6�   ��6U   �� *OrbQuantity+6�   �� 5   
   $��Start��6   $��Center=�6!   $��0,51,0,0q�6>   $	��Top=�6P   $��70��6h   $��25��6s   $��1��6    �� 	IsDefault$
 True��6�   ��6�   �� *SignalEnable+{�6�   �� *	IsEnabled+6�   �� 5   
   -   5        $
��Stop��5      $��Center=�6    $��0,81,0,0q�6=   $	��Top=�6O   $��70��6g   $��25��6r   $��1��6�    �� IsCancel$
 True��6�   ��6~   �� *SignalDisable+{�6�   �� *	IsEnabled+6�   �� 5   
   $	��750��6   $	��600��6#   ��60   �� *	OrbList+��5      �� 5      .R�5      �� $	��750��6   $	��600��6)   ���	#FFAB515166   5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@��Left �� Value 64   �� *X+�� 5        �@��Top 63   �� *Y+5!      ��5#      �� 5$      .R�5%      A� 
����+��
��� d ���6   �� *Radius+��68   �� *Radius+6e   5&      5(      5)      5*      