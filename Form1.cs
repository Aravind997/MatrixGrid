﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MatrixGridPrg

{
    public partial class Form1 : Form
    {
        public int m_iWidth;
        public int m_iHeight;
        public int m_iNoOfRows;
        public int m_iNoOfCols;
        public int m_iXOffset;
        public int m_iYOffset;
        public int m_iCount = 2;
        public int m_iGridMaxSize = 2;

        public const int DEFAULT_X_OFFSET = 100;
        public const int DEFAULT_Y_OFFSET = 150;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 20;
        public const int DEFAULT_HEIGHT = 20;


        public Form1()
        {
            Initialize();
            InitializeComponent();
            bThreadStatus = false;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid();
        }
        public void Initialize()
        {

            m_iNoOfRows = DEFAULT_NO_ROWS;
            m_iNoOfCols = DEFAULT_NO_COLS;
            m_iWidth = DEFAULT_WIDTH;
            m_iHeight = DEFAULT_HEIGHT;
            m_iXOffset = DEFAULT_X_OFFSET;
            m_iYOffset = DEFAULT_Y_OFFSET;

        }
        private void DrawGrid()
        {
            Graphics boardLayout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Black);
            layoutPen.Width = 3;


            int X = DEFAULT_X_OFFSET;
            int Y = DEFAULT_Y_OFFSET;

            for (int i = 0; i <= m_iCount; i++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X + this.m_iWidth * this.m_iCount, Y);
                Y = Y + this.m_iHeight;
            }

            X = DEFAULT_X_OFFSET;
            Y = DEFAULT_Y_OFFSET;
            for (int j = 0; j <= m_iCount; j++)
            {
                boardLayout.DrawLine(layoutPen, X, Y, X, Y + this.m_iHeight * this.m_iCount);
                X = X + this.m_iWidth;

            }
        }
        private void maxsizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 2;
                this.Refresh();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 4;
                this.Refresh();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 6;
                this.Refresh();
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            m_iGridMaxSize = 8;
                this.Refresh();
        }

 
        public void ThreadCounter()
        {
            
            try
            {
                while (true)
                {
                    m_iCount++;
                    if(m_iCount > m_iGridMaxSize)
                    {
                        m_iCount = 2;
                    }
                    Invalidate();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            {
                MatrixGridPrg = new Thread(new ThreadStart(ThreadCounter));
                MatrixGridPrg.Start();
                bThreadStatus = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MatrixGridPrg.Suspend();
        }
    }
}


       
    
        
    

