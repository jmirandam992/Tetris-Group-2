   M S B A M L   `   `   `  ����A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TetrisTetris  5   	       Tetris.About   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Tetris     5   	   -   5          �Name$  About_Window��5   	    � Title$ About��5   	   $	��852��6   $	��600��6$    � AllowsTransparency .  � WindowStyle$
 None=�6J   .��5	      � $��0,0,0,10q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ 
lblHeading��5      $��ABOUT TETRIS��6$   $
��Left=�6;   $��41��6V   $��
201,21,0,0q�6b   $	��202��6v   $	��Top=�6�   $��Broadway)�6�   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   ���	#FF33F4FD6�   �� 5   
   -   5        $ lblControlls��5      $��Controls��6&   $
��Left=�69   $	��Top=�6T   $��
25,148,0,0q�6l   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblAboutTetris��5      $��About Tetris' Orgin��6(   $
��Left=�6F   $	��Top=�6a   $��
27,332,0,0q�6y   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ imgControls��5      $
��Left=�6%   $��79��6@   $	��Top=�6L   $	��165��6d   $��214,206,0,0q�6p   $��images/arrokeys.png��6�   �� 5   
   -   5        $ lblLeftControl��5      $��	Move Left��6(   $
��Left=�6<   $	��Top=�6W   $��123,226,0,0q�6o   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblRightControl��5      $��
Move Right��6)   $
��Left=�6>   $	��Top=�6Y   $��384,226,0,0q�6q   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblTopControl��5      $��Flip Game Piece��6'   $
��Left=�6A   $	��Top=�6\   $��232,171,0,0q�6t   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -	   5        $ lblDownControl��5      $��Increase Drop Speed��6(   $
��Left=�6F   $	��Top=�6a   $��216,287,0,0q�6y   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -
   5         ��Name$ txtBlkAboutTetrisOrgin��5      $
��Left=�64   $
��Wrap=�6O   $����Tetris is a block matching puzzle game that was programmed and designed by Alexey Pajitnov. Tetris was released for the first time in 1984. It was a massive success across many platforms, and was even one of the first games to be exported to the U.S from Russia.   ��6c   $	��Top=�6t  $��
35,368,0,0q�6�  $��54��6�  $	��543��6�  
���   �6�  �� 5   
   -   5        $ lblAboutTheGameplay��5      $��About the Gameplay��6-   $
��Left=�6J   $	��Top=�6e   $��
27,443,0,0q�6}   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $! txtBlkAboutTetrisOrgin_Copy��5      $
��Left=�69   $
��Wrap=�6T   $	��Top=�6h   $��
35,479,0,0q�6�   $	��104��6�   $	��543��6�   $����The goal of Tetris is to rearrange and stack falling game pieces into horizontal rows. By doing so the player is awarded points and the row(s) disappears. The more rows a player completes in a turn increases the score multiplayer. By reaching certain score-oriented goals a player advances in levels. Each level increases the speed at which pieces drop as well as the score multiplayer for completing rows. If any of the game pieces surpasses the top of the play area the game is over. A player can complete the game by surpassing all 10 levels. ��6�   �� 5   
   -   5        $ lblGameSettings��5      $��Scoring and Leveling��6)   $
��Left=�6H   $	��Top=�6c   $��
35,588,0,0q�6{   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblScoringAdvisory��5      $:��4In this version points will be rewards as follows...��6,   $
��Left=�6k   $��
35,615,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ lblAboutTheGameplay_Copy1��5      $�� ��63   $
��Left=�6>   $	��Top=�6Y   $��
35,649,0,0q�6q   ���	#FF3C3535$��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lbl1Row��5      $��1 Row = 100��6!   $
��Left=�67   $��
35,646,0,0q�6R   $	��Top=�6f   $
��Bold"�6~   $��13(�6�   �� 5   
   -   5        $ lbl2Row��5      $��2 Rows = 200��6!   $
��Left=�68   $��143,646,0,0q�6S   $	��Top=�6h   $
��Bold"�6�   $��13(�6�   �� 5   
   -   5        $ lbl3Row��5      $��3 Rows = 400��6!   $
��Left=�68   $��250,646,0,0q�6S   $	��Top=�6h   $
��Bold"�6�   $��13(�6�   �� 5   
   -   5        $ lbl4Row��5      $��4 Rows = 800��6!   $
��Left=�68   $��361,646,0,0q�6S   $	��Top=�6h   $
��Bold"�6�   $��13(�6�   �� 5   
   -   5        $ txtBlkMultipliers��5      $
��Left=�6/   $
��Wrap=�6J   $	��Top=�6^   $��
35,680,0,0q�6v   $��51��6�   $	��543��6�   $����In this version scoring will be multiplied by the given level number, and speed will increase by half the starting speed each level��6�   �� 5    
   -   5        $ lblMultiplier1��5       $��LVL 1 Score = x1��6(   $
��Left=�6C   $��
31,716,0,0q�6^   $	��Top=�6r   $
��Bold"�6�   $��13(�6�   �� 5!   
   -   5        $ lblMultiplier2��5!      $)��#LVL 2 Score = x2...       And so on��6(   $
��Left=�6V   $��156,716,0,0q�6q   $	��Top=�6�   $
��Bold"�6�   $��13(�6�   �� 5"   
   -   5        $ lblSpeedMultiplier1��5"      $!��LVL 1 Speed = Starting Rate��6-   $
��Left=�6S   $��
31,746,0,0q�6n   $	��Top=�6�   $
��Bold"�6�   $��13(�6�   �� 5#   
   -   5        $ lblSpeedMultiplier2��5#      $'��!LVL 2 Speed = 1.5...    And so on��6-   $
��Left=�6Y   $��225,746,0,0q�6t   $	��Top=�6�   $
��Bold"�6�   $��13(�6�   �� 5$   
   -   5        $ 	lblLevel1��5$      $��LVL 1 = 10,000pt��6#   $
��Left=�6>   $��
31,778,0,0q�6Y   $	��Top=�6m   $
��Bold"�6�   $��13(�6�   �� 5%   
   -   5        $ 	lblLevel2��5%      $�� ��6#   $
��Left=�6.   $��143,778,0,0q�6I   $	��Top=�6^   $
��Bold"�6v   $��13(�6�   �� 5&   
   -   5        $ lblLevel2_1��5&      $��LVL 2 = 20,000pt��6%   $
��Left=�6@   $��171,778,0,0q�6[   $	��Top=�6p   $
��Bold"�6�   $��13(�6�   �� 5'   
   -   5        $ 	lblLevel3��5'      $%��LVL 3 = 30,000pt...   And so on��6#   $
��Left=�6M   $��303,778,0,0q�6h   $	��Top=�6}   $
��Bold"�6�   $��13(�6�   �� 5(   
   -   5         ��Name$ 
BackButton��5(      $
��Back��6%   $	��Top=�64   $��250,67,250,0q�6L   ���	#FF33F4FD���	#FF33F4FD$��5q�6�   
�������$��Broadway)�6�   $��16(�6�   $
��Bold"�6�   $��Italic$�6  $��50��6  5*      5+      