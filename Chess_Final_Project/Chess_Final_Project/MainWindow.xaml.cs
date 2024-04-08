using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess_Final_Project
{

    public partial class MainWindow : Window
    {
        public static int[,] board = {
                                { -50, -30, -33, -1000, -90, -33, -30, -50 },
                                { -10, -10, -10, -10, -10, -10, -10, -10 },
                                { 0, 0, 0, 0, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 0, 0, 0, 0 },
                                {  10,  10,  10,  10,  10,  10,  10,  10 },
                                {  50,  30,  33,  90,  1000,  33,  30,  50 }
        };
        (int, int) BlackRookIndex = (0, 0), BlackKnightIndex=(0,1), BlackBishopIndex=(0,2), BlackKingIndex=(0,3),
            BlackQueenIndex=(0,4), BlackBishop2Index=(0,5), BlackKnight2Index=(0,6), BlackRook2Index=(0,7),
            BlackPawn1Index=(1,0), BlackPawn2Index = (1, 1), BlackPawn3Index = (1, 2), BlackPawn4Index = (1,3),
            BlackPawn5Index = (1, 4), BlackPawn6Index = (1, 5), BlackPawn7Index = (1, 6), BlackPawn8Index = (1, 7);

        (int, int) WhiteRookIndex = (7, 0), WhiteKnightIndex = (7, 1), WhiteBishopIndex = (7, 2), WhiteKingIndex = (7, 4),
    WhiteQueenIndex = (7, 3), WhiteBishop2Index = (7, 5), WhiteKnight2Index = (7, 6), WhiteRook2Index = (7, 7),
    WhitePawn1Index = (6, 7), WhitePawn2Index = (6, 6), WhitePawn3Index = (6, 5), WhitePawn4Index = (6, 4),
    WhitePawn5Index = (6, 3), WhitePawn6Index = (6, 2), WhitePawn7Index = (6, 1), WhitePawn8Index = (6, 0);

        bool WhiteRookClicked, WhiteKnightClicked, WhiteBishopClicked, WhiteKingClicked, WhiteQueenClicked,
            WhiteBishop2Clicked, WhiteKnight2Clicked, WhiteRook2Clicked, WhitePawn1Clicked, WhitePawn2Clicked, WhitePawn3Clicked,
            WhitePawn4Clicked, WhitePawn5Clicked, WhitePawn6Clicked, WhitePawn7Clicked, WhitePawn8Clicked;
        double DeltaX, DeltaY;
        bool BlackMoved = false;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();

        }
        void BlackMoves(MouseEventArgs e)
        {
            //Pordum en utel material-in
            //EatingMaterial(e);
            if (!EatingMaterial(e))
            {
                heuristic(e);
            }
            Image[] BlackFigures = {BlackRook,BlackKnight,BlackBishop,BlackKing,BlackQueen,BlackBishop2,BlackKnight2,BlackRook2,
            BlackPawn1,BlackPawn2,BlackPawn3,BlackPawn4,BlackPawn5,BlackPawn6,BlackPawn7,BlackPawn8};

        }
        void heuristic(MouseEventArgs e)
        {

        }
        bool EatingMaterial(MouseEventArgs e)
        {
            bool eaten = false;
     
            for (int i = 0; i <= 350; i+=50)
            {
                for (int j = 0; j <= 350; j += 50)
                {
                    if (eaten == false)
                    {
                        if (board[i / 50, j / 50] > 0 && board[i / 50, j / 50]!=1000 && !HaveBeenThere(i,j))
                        {
                            //taguhin e pordzum utel
                            if ((j==(BlackQueenIndex.Item2*50) || i==(BlackQueenIndex.Item1*50)||i+j==((BlackQueenIndex.Item1+BlackQueenIndex.Item2)*50)||i-j==(50*(BlackQueenIndex.Item1-BlackQueenIndex.Item2)))&&eaten==false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackQueenIndex.Item1, BlackQueenIndex.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackQueenIndex.Item1 = i / 50;
                                BlackQueenIndex.Item2 = j / 50;
                                board[BlackQueenIndex.Item1, BlackQueenIndex.Item2] = -10;
                                BlackQueen.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //dzin e pordzum
                            if (((Math.Abs(j - (BlackKnightIndex.Item2 * 50)) == 50 && Math.Abs(i - (BlackKnightIndex.Item1 * 50)) == 100) ||
                                (Math.Abs(j - (BlackKnightIndex.Item2 * 50)) == 50 && Math.Abs(i - (BlackKnightIndex.Item1 * 50)) == 100)) && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackKnightIndex.Item1, BlackKnightIndex.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackKnightIndex.Item1 = i / 50;
                                BlackKnightIndex.Item2 = j / 50;
                                board[BlackKnightIndex.Item1, BlackKnightIndex.Item2] = -10;
                                BlackKnight.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                            if (((Math.Abs(j - (BlackKnight2Index.Item2 * 50)) == 50 && Math.Abs(i - (BlackKnight2Index.Item1 * 50)) == 100) ||
                                (Math.Abs(j - (BlackKnight2Index.Item2 * 50)) == 50 && Math.Abs(i - (BlackKnight2Index.Item1 * 50)) == 100)) && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackKnight2Index.Item1, BlackKnight2Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackKnight2Index.Item1 = i / 50;
                                BlackKnight2Index.Item2 = j / 50;
                                board[BlackKnight2Index.Item1, BlackKnight2Index.Item2] = -10;
                                BlackKnight2.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                            //pixn e pordzum utel
                            if ((i + j == ((BlackBishopIndex.Item1 + BlackBishopIndex.Item2) * 50) || i - j == (50 * (BlackBishopIndex.Item1 - BlackBishopIndex.Item2))) && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackBishopIndex.Item1, BlackBishopIndex.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackBishopIndex.Item1 = i / 50;
                                BlackBishopIndex.Item2 = j / 50;
                                board[BlackBishopIndex.Item1, BlackBishopIndex.Item2] = -10;
                                BlackBishop.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                            //pixn e pordzum utel
                            if ((i + j == ((BlackBishop2Index.Item1 + BlackBishop2Index.Item2) * 50) || i - j == (50 * (BlackBishop2Index.Item1 - BlackBishop2Index.Item2))) && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackBishop2Index.Item1, BlackBishop2Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackBishop2Index.Item1 = i / 50;
                                BlackBishop2Index.Item2 = j / 50;
                                board[BlackBishop2Index.Item1, BlackBishop2Index.Item2] = -10;
                                BlackBishop2.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                            //navn e pordzum utel
                            if ((j == (BlackRookIndex.Item2 * 50) || i == (BlackRookIndex.Item1 * 50) ) && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackRookIndex.Item1, BlackRookIndex.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackRookIndex.Item1 = i / 50;
                                BlackRookIndex.Item2 = j / 50;
                                board[BlackRookIndex.Item1, BlackRookIndex.Item2] = -10;
                                BlackRook.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                            if ((j == (BlackRook2Index.Item2 * 50) || i == (BlackRook2Index.Item1 * 50)) && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackRook2Index.Item1, BlackRook2Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackRook2Index.Item1 = i / 50;
                                BlackRook2Index.Item2 = j / 50;
                                board[BlackRook2Index.Item1, BlackRook2Index.Item2] = -10;
                                BlackRook2.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                            //zinvor 1-n e pordzum utel
                            if (i - BlackPawn1Index.Item1 * 50 == 50 && Math.Abs((BlackPawn1Index.Item2*50)-j) == 50 && eaten == false)
                            {                            
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn1Index.Item1, BlackPawn1Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn1Index.Item1 = i / 50;
                                BlackPawn1Index.Item2 = j / 50;
                                board[BlackPawn1Index.Item1, BlackPawn1Index.Item2] = -10;
                                BlackPawn1.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 2-y
                            if (i - BlackPawn2Index.Item1 * 50 == 50 && Math.Abs(j - (BlackPawn2Index.Item2 * 50)) <= 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn2Index.Item1, BlackPawn2Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn2Index.Item1 = i / 50;
                                BlackPawn2Index.Item2 = j / 50;
                                board[BlackPawn2Index.Item1, BlackPawn2Index.Item2] = -10;
                                BlackPawn2.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 3-y
                            if (i - BlackPawn3Index.Item1 * 50 == 50 && Math.Abs(j - BlackPawn3Index.Item2 * 50) == 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn3Index.Item1, BlackPawn3Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn3Index.Item1 = i / 50;
                                BlackPawn3Index.Item2 = j / 50;
                                board[BlackPawn3Index.Item1, BlackPawn3Index.Item2] = -10;
                                BlackPawn3.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 4-y
                            if (i - BlackPawn4Index.Item1 * 50 == 50 && Math.Abs(j - BlackPawn4Index.Item2 * 50) == 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn4Index.Item1, BlackPawn4Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn4Index.Item1 = i / 50;
                                BlackPawn4Index.Item2 = j / 50;
                                board[BlackPawn4Index.Item1, BlackPawn4Index.Item2] = -10;
                                BlackPawn4.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 5-y
                            if (i - BlackPawn5Index.Item1 * 50 == 50 && Math.Abs(j - BlackPawn5Index.Item2 * 50) == 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn5Index.Item1, BlackPawn5Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn5Index.Item1 = i / 50;
                                BlackPawn5Index.Item2 = j / 50;
                                board[BlackPawn5Index.Item1, BlackPawn5Index.Item2] = -10;
                                BlackPawn5.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 6-y
                            if (i - BlackPawn6Index.Item1 * 50 == 50 && Math.Abs(j - BlackPawn6Index.Item2 * 50) == 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn6Index.Item1, BlackPawn6Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn6Index.Item1 = i / 50;
                                BlackPawn6Index.Item2 = j / 50;
                                board[BlackPawn6Index.Item1, BlackPawn6Index.Item2] = -10;
                                BlackPawn6.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 7-y
                            if (i - BlackPawn7Index.Item1 * 50 == 50 && Math.Abs(j - BlackPawn7Index.Item2 * 50) == 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn7Index.Item1, BlackPawn7Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn7Index.Item1 = i / 50;
                                BlackPawn7Index.Item2 = j / 50;
                                board[BlackPawn7Index.Item1, BlackPawn7Index.Item2] = -10;
                                BlackPawn7.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);

                            }
                            //pordzum e utel zinvor 8-y
                            if (i - BlackPawn8Index.Item1 * 50 == 50 && Math.Abs(j - BlackPawn8Index.Item2 * 50) == 50 && eaten == false)
                            {
                                RemoveWhiteFigure(j, i);
                                board[BlackPawn8Index.Item1, BlackPawn8Index.Item2] = 0;
                                board[i / 50, j / 50] = 0;
                                BlackPawn8Index.Item1 = i / 50;
                                BlackPawn8Index.Item2 = j / 50;
                                board[BlackPawn8Index.Item1, BlackPawn8Index.Item2] = -10;
                                BlackPawn8.Margin = new Thickness(j, i, 0, 0);
                                eaten = true;
                                CapturedField(i, j);
                            }
                        }

                    }
                }
            }
            return eaten;
        }
        void CapturedField(int i,int j)
        {
            i = i / 50;
            j = j / 50;
            string  name ="R"+i+j;

            Rectangle foundElement = ramka.FindName(name) as Rectangle;
            if (foundElement.Visibility != Visibility.Visible)
            {
                foundElement.Visibility = Visibility.Visible;
            }
        }
        bool HaveBeenThere(int i,int j)
        {
            i = i / 50;
            j = j / 50;
            string name = "R" + i + j;

            Rectangle foundElement = ramka.FindName(name) as Rectangle;
            if (foundElement.Visibility == Visibility.Visible)
            {
                return true;
            }
            return false;
        }
        void RemoveWhiteFigure(int i, int j)
        {
            Image[] WhiteFigures = {WhitePawn1, WhitePawn2, WhitePawn3, WhitePawn4, WhitePawn5, WhitePawn6, WhitePawn7, WhitePawn8,
            WhiteRook,WhiteRook2,WhiteBishop,WhiteBishop2,WhiteKnight,WhiteKnight2,WhiteKing,WhiteQueen};
            //(int, int)[] WhiteFigureIndexes = {WhitePawn1Index,WhitePawn2Index,WhitePawn3Index,WhitePawn4Index,
            //WhitePawn5Index,WhitePawn6Index,WhitePawn7Index,WhitePawn8Index,WhiteRookIndex,WhiteRook2Index,
            //WhiteBishop2Index,WhiteBishopIndex,WhiteKnight2Index,WhiteKnightIndex,WhiteKingIndex,WhiteQueenIndex};
            foreach (var item in WhiteFigures)
            {
                if(item.Margin.Left==i && item.Margin.Top == j && item!=null && item.Parent is Grid GridBoard)
                {
                    //item.Visibility = Visibility.Hidden;
                    GridBoard.Children.Remove(item);
                }
            }
        }
        //void RemoveBlackFigure(int i, int j)
        //{
        //    Image[] Blackigures = {BlackPawn1, BlackPawn2, BlackPawn3, BlackPawn4, BlackPawn5, BlackPawn6, BlackPawn7, BlackPawn8,
        //    BlackRook,BlackRook2,BlackBishop,BlackBishop2,BlackKnight,BlackKnight2,BlackKing,BlackQueen};
        //    //(int, int)[] WhiteFigureIndexes = {WhitePawn1Index,WhitePawn2Index,WhitePawn3Index,WhitePawn4Index,
        //    //WhitePawn5Index,WhitePawn6Index,WhitePawn7Index,WhitePawn8Index,WhiteRookIndex,WhiteRook2Index,
        //    //WhiteBishop2Index,WhiteBishopIndex,WhiteKnight2Index,WhiteKnightIndex,WhiteKingIndex,WhiteQueenIndex};
        //    foreach (var item in Blackigures)
        //    {
        //        if (item.Margin.Left == i && item.Margin.Top == j && item != null && item.Parent is Grid GridBoard)
        //        {
        //            //item.Visibility = Visibility.Hidden;
                   
        //            GridBoard.Children.Remove(item);
        //        }
        //    }
        //}
        void WindowMouseMove(object sender, MouseEventArgs e)
        {
            if (WhiteRookClicked)
                WhiteRook.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteRook2Clicked)
                WhiteRook2.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteKnightClicked)
                WhiteKnight.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteKnight2Clicked)
                WhiteKnight2.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteBishopClicked)
                WhiteBishop.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteBishop2Clicked)
                WhiteBishop2.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteKingClicked)
                WhiteKing.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhiteQueenClicked)
                WhiteQueen.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);

            if (WhitePawn1Clicked)
                WhitePawn1.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn2Clicked)
                WhitePawn2.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn3Clicked)
                WhitePawn3.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn4Clicked)
                WhitePawn4.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn5Clicked)
                WhitePawn5.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn6Clicked)
                WhitePawn6.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn7Clicked)
                WhitePawn7.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);
            if (WhitePawn8Clicked)
                WhitePawn8.Margin = new Thickness(e.GetPosition(this).X - DeltaX,
                e.GetPosition(this).Y - DeltaY, 0, 0);

        }

        void WhiteRookMouseDown(object sender,MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteRook, 1);
                WhiteRookClicked = true;
                DeltaX = e.GetPosition(this).X - WhiteRook.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteRook.Margin.Top;
            }
        }
        void WhiteRookMouseUp(object sender, MouseEventArgs e)
        {
            WhiteRookClicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
            //MessageBox.Show($"{WhiteRookIndex.Item2 * 50},{WhiteRookIndex.Item1 * 50}");
            if ((newX==WhiteRookIndex.Item2*50 || newY==WhiteRookIndex.Item1*50) && board[newY/50,newX/50]<=0)
            {
                WhiteRook.Margin = new Thickness(newX, newY, 0, 0);
                //if (board[newY / 50, newX / 50] < 0)
                //{
                //    RemoveBlackFigure(newX, newY);
                //}
                board[WhiteRookIndex.Item1, WhiteRookIndex.Item2] = 0;
                board[newY / 50, newX / 50] = 50;
                WhiteRookIndex = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);

            }
            else
            {
                WhiteRook.Margin = new Thickness(WhiteRookIndex.Item2*50, WhiteRookIndex.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhiteRook2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteRook2, 1);
                WhiteRook2Clicked = true;
                DeltaX = e.GetPosition(this).X - WhiteRook2.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteRook2.Margin.Top;
            }
        }
        void WhiteRook2MouseUp(object sender, MouseEventArgs e)
        {
            WhiteRook2Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
            //MessageBox.Show($"{WhiteRookIndex.Item2 * 50},{WhiteRookIndex.Item1 * 50}");
            if ((newX == WhiteRook2Index.Item2 * 50 || newY == WhiteRook2Index.Item1 * 50) && board[newY / 50, newX / 50] <= 0)
            {
                WhiteRook2.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteRook2Index.Item1, WhiteRook2Index.Item2] = 0;
                board[newY / 50, newX / 50] = 50;
                WhiteRook2Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteRook2.Margin = new Thickness(WhiteRook2Index.Item2 * 50, WhiteRook2Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }
        
        void WhiteBishopMouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteBishop, 1);
                WhiteBishopClicked = true;
                DeltaX = e.GetPosition(this).X - WhiteBishop.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteBishop.Margin.Top;
            }
        }
        void WhiteBishopMouseUp(object sender, MouseEventArgs e)
        {
            WhiteBishopClicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
           // MessageBox.Show($"{WhiteBishopIndex.Item2/50},{WhiteBishopIndex.Item1/50}");
            if ((newX+newY== WhiteBishopIndex.Item1*50 + WhiteBishopIndex.Item2*50 || newY-newX == WhiteBishopIndex.Item1 * 50 - WhiteBishopIndex.Item2 * 50) && board[newY / 50, newX / 50] <= 0)
            {
                WhiteBishop.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteBishopIndex.Item1, WhiteBishopIndex.Item2] = 0;
                board[newY / 50, newX / 50] = 33;
                WhiteBishopIndex = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteBishop.Margin = new Thickness(WhiteBishopIndex.Item2 * 50, WhiteBishopIndex.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhiteBishop2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteBishop2, 1);
                WhiteBishop2Clicked = true;
                DeltaX = e.GetPosition(this).X - WhiteBishop2.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteBishop2.Margin.Top;
            }
        }
        void WhiteBishop2MouseUp(object sender, MouseEventArgs e)
        {
            WhiteBishop2Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
            // MessageBox.Show($"{WhiteBishopIndex.Item2/50},{WhiteBishopIndex.Item1/50}");
            if ((newX + newY == WhiteBishop2Index.Item1 * 50 + WhiteBishop2Index.Item2 * 50 || newY - newX == WhiteBishop2Index.Item1 * 50 - WhiteBishop2Index.Item2 * 50) && board[newY / 50, newX / 50] <= 0)
            {
                WhiteBishop2.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteBishop2Index.Item1, WhiteBishop2Index.Item2] = 0;
                board[newY / 50, newX / 50] = 33;
                WhiteBishop2Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteBishop2.Margin = new Thickness(WhiteBishop2Index.Item2 * 50, WhiteBishop2Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhiteKnightMouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteKnight, 1);
                WhiteKnightClicked = true;
                DeltaX = e.GetPosition(this).X - WhiteKnight.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteKnight.Margin.Top;
            }
        }
        void WhiteKnightMouseUp(object sender, MouseEventArgs e)
        {
            WhiteKnightClicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
            // MessageBox.Show($"{WhiteBishopIndex.Item2/50},{WhiteBishopIndex.Item1/50}");
            if (((Math.Abs(newX-(WhiteKnightIndex.Item2*50))==100&& Math.Abs(newY - (WhiteKnightIndex.Item1*50)) == 50)||(Math.Abs(newX - (WhiteKnightIndex.Item2*50)) == 50 && Math.Abs(newY - (WhiteKnightIndex.Item1*50)) == 100)) && board[newY / 50, newX / 50] <= 0)
            {
                WhiteKnight.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteKnightIndex.Item1, WhiteKnightIndex.Item2] = 0;
                board[newY / 50, newX / 50] = 30;
                WhiteKnightIndex = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteKnight.Margin = new Thickness(WhiteKnightIndex.Item2 * 50, WhiteKnightIndex.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhiteKnight2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteKnight2, 1);
                WhiteKnight2Clicked = true;
                DeltaX = e.GetPosition(this).X - WhiteKnight2.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteKnight2.Margin.Top;
            }
        }
        void WhiteKnight2MouseUp(object sender, MouseEventArgs e)
        {
            WhiteKnight2Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
                                                                             // MessageBox.Show($"{WhiteBishopIndex.Item2/50},{WhiteBishopIndex.Item1/50}");
            if (((Math.Abs(newX - (WhiteKnight2Index.Item2 * 50)) == 100 && Math.Abs(newY - (WhiteKnight2Index.Item1 * 50)) == 50) || (Math.Abs(newX - (WhiteKnight2Index.Item2 * 50)) == 50 && Math.Abs(newY - (WhiteKnight2Index.Item1 * 50)) == 100)) && board[newY / 50, newX / 50] <= 0)
            {
                WhiteKnight2.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteKnight2Index.Item1, WhiteKnight2Index.Item2] = 0;
                board[newY / 50, newX / 50] = 30;
                WhiteKnight2Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteKnight2.Margin = new Thickness(WhiteKnight2Index.Item2 * 50, WhiteKnight2Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhiteKingMouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteKing, 1);
                WhiteKingClicked = true;
                DeltaX = e.GetPosition(this).X - WhiteKing.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteKing.Margin.Top;
            }
        }
        void WhiteKingMouseUp(object sender, MouseEventArgs e)
        {
            WhiteKingClicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
            // MessageBox.Show($"{WhiteBishopIndex.Item2/50},{WhiteBishopIndex.Item1/50}");
            if (Math.Abs(newX-(WhiteKingIndex.Item2*50))<=50 && Math.Abs(newY - (WhiteKingIndex.Item1*50)) <= 50 && board[newY / 50, newX / 50] <= 0)
            {
                WhiteKing.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteKingIndex.Item1, WhiteKingIndex.Item2] = 0;
                board[newY / 50, newX / 50] = 1000;
                WhiteKingIndex = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteKing.Margin = new Thickness(WhiteKingIndex.Item2 * 50, WhiteKingIndex.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhiteQueenMouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteQueen, 1);
                WhiteQueenClicked = true;
                DeltaX = e.GetPosition(this).X - WhiteQueen.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteQueen.Margin.Top;
            }
        }
        void WhiteQueenMouseUp(object sender, MouseEventArgs e)
        {
            WhiteQueenClicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if (((newX == WhiteQueenIndex.Item2 * 50 || newY == WhiteQueenIndex.Item1 * 50)||((newX + newY == WhiteQueenIndex.Item1 * 50 + WhiteQueenIndex.Item2 * 50 || newY - newX == WhiteQueenIndex.Item1 * 50 - WhiteQueenIndex.Item2 * 50))) && board[newY / 50, newX / 50] <= 0)
            {
                WhiteQueen.Margin = new Thickness(newX, newY, 0, 0);
                board[WhiteQueenIndex.Item1, WhiteQueenIndex.Item2] = 0;
                board[newY / 50, newX / 50] = 90;
                WhiteQueenIndex = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhiteQueen.Margin = new Thickness(WhiteQueenIndex.Item2 * 50, WhiteQueenIndex.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn1MouseDown(object sender,MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn1, 1);
                WhitePawn1Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn1.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn1.Margin.Top;
            }
        }
        void WhitePawn1MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn1Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top
            if ((WhitePawn1Index.Item1*50-newY==50 && newX==WhitePawn1Index.Item2*50 && board[newY / 50, newX / 50] == 0)||((WhitePawn1Index.Item1*50-newY == 50 && Math.Abs(newX-WhitePawn1Index.Item2*50)==50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn1.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn1Index.Item1, WhitePawn1Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn1Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn1.Margin = new Thickness(WhitePawn1Index.Item2 * 50, WhitePawn1Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn2, 1);
                WhitePawn2Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn2.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn2.Margin.Top;
            }
        }
        void WhitePawn2MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn2Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn2Index.Item1 * 50 - newY == 50 && newX == WhitePawn2Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn2Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn2Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn2.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn2Index.Item1, WhitePawn2Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn2Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn2.Margin = new Thickness(WhitePawn2Index.Item2 * 50, WhitePawn2Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn3MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn3, 1);
                WhitePawn3Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn3.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn3.Margin.Top;
            }
        }
        void WhitePawn3MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn3Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn3Index.Item1 * 50 - newY == 50 && newX == WhitePawn3Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn3Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn3Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn3.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn3Index.Item1, WhitePawn3Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn3Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn3.Margin = new Thickness(WhitePawn3Index.Item2 * 50, WhitePawn3Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn4MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn4, 1);
                WhitePawn4Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn4.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn4.Margin.Top;
            }
        }
        void WhitePawn4MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn4Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn4Index.Item1 * 50 - newY == 50 && newX == WhitePawn4Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn4Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn4Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn4.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn4Index.Item1, WhitePawn4Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn4Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn4.Margin = new Thickness(WhitePawn4Index.Item2 * 50, WhitePawn4Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn5MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn5, 1);
                WhitePawn5Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn5.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn5.Margin.Top;
            }
        }
        void WhitePawn5MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn5Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn5Index.Item1 * 50 - newY == 50 && newX == WhitePawn5Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn5Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn5Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn5.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn5Index.Item1, WhitePawn5Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn5Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn5.Margin = new Thickness(WhitePawn5Index.Item2 * 50, WhitePawn5Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn6MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn6, 1);
                WhitePawn6Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn6.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn6.Margin.Top;
            }
        }
        void WhitePawn6MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn6Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn6Index.Item1 * 50 - newY == 50 && newX == WhitePawn6Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn6Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn6Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn6.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn6Index.Item1, WhitePawn6Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn6Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn6.Margin = new Thickness(WhitePawn6Index.Item2 * 50, WhitePawn6Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn7MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn7, 1);
                WhitePawn7Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn7.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn7.Margin.Top;
            }
        }
        void WhitePawn7MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn7Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn7Index.Item1 * 50 - newY == 50 && newX == WhitePawn7Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn7Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn7Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn7.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn7Index.Item1, WhitePawn7Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn7Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn7.Margin = new Thickness(WhitePawn7Index.Item2 * 50, WhitePawn7Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

        void WhitePawn8MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn8, 1);
                WhitePawn8Clicked = true;
                DeltaX = e.GetPosition(this).X - WhitePawn8.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn8.Margin.Top;
            }
        }
        void WhitePawn8MouseUp(object sender, MouseEventArgs e)
        {
            WhitePawn8Clicked = false;
            int newX = (int)(e.GetPosition(this).X + DeltaX - 25) / 50 * 50; //left
            int newY = (int)(e.GetPosition(this).Y + DeltaY - 25) / 50 * 50; //top

            if ((WhitePawn8Index.Item1 * 50 - newY == 50 && newX == WhitePawn8Index.Item2 * 50 && board[newY / 50, newX / 50] == 0) || ((WhitePawn8Index.Item1 * 50 - newY == 50 && Math.Abs(newX - WhitePawn8Index.Item2 * 50) == 50) && board[newY / 50, newX / 50] < 0))
            {
                WhitePawn8.Margin = new Thickness(newX, newY, 0, 0);
                board[WhitePawn8Index.Item1, WhitePawn8Index.Item2] = 0;
                board[newY / 50, newX / 50] = 10;
                WhitePawn8Index = (newY / 50, newX / 50);
                ramka.Children.Clear();
                BlackMoves(e);
            }
            else
            {
                WhitePawn8.Margin = new Thickness(WhitePawn8Index.Item2 * 50, WhitePawn8Index.Item1 * 50, 0, 0);
                ramka.Children.Clear();
            }
        }

    }
}
