using System;
using Matrix_0; 

// 儲存於 C:\2302\Misc_13\CSharpTest02 
namespace CSharpTest02
{
	internal class Program
	{
		static void Main(string[] args)
		{


// 空間維度有m個自由度。
int m = 3;
// 微分方程式有r個階度(Order)。
int r = 2;

// 建構初始矩陣 M、C、K、O、I 
ReMatrix M = (new Zero(m)).GetMatrix;
ReMatrix C = (new Zero(m)).GetMatrix;
ReMatrix K = (new Zero(m)).GetMatrix;
ReMatrix O = (new Zero(m)).GetMatrix;
ReMatrix I = (new Iden(m)).GetMatrix;

// 建構初始系統矩陣 A、特徵值矩陣 D、特徵向量矩陣 Q。 
ReMatrix A = (new Zero(m * r)).GetMatrix;
CxMatrix D = (new Zero(m * r)).GetMatrix;
CxMatrix Q = (new Zero(m * r)).GetMatrix;

// 狀態響應 : 加速度、速度，和變位。(Step = 1.0秒，共計 t = 20秒) 
double step = 1.0;
int iRow = (int)(20 / step + 1);

// 建構時間軸上的儲存矩陣(時間t壹行和儲存矩陣m * r行。
int iColD = m * r + 1;
// 儲存矩陣為 iRow X iColD 
CxMatrix CxVal = new CxMatrix(iRow, iColD);
ReMatrix ReVal = new ReMatrix(iRow, iColD);

for (int i = 0; i != iRow; i++)
{
	double t = step * i;

	// 建構實際的M、C、K矩陣。
	M.Matrix[0, 0] = 19;
	M.Matrix[0, 1] = -1.5;
	M.Matrix[0, 2] = -2 + 13.3 * Math.Sin(0.85 * t);  
	M.Matrix[1, 0] = -1;
	M.Matrix[1, 1] = 15;
	M.Matrix[1, 2] = 0;
	M.Matrix[2, 0] = -10 - 2.7 * Math.Cos(1.3 * t); 
	M.Matrix[2, 1] = -3;
	M.Matrix[2, 2] = 27;
	// End of M 

	C.Matrix[0, 0] = 35;
	C.Matrix[0, 1] = -1 - 13.2 * Math.Sin(0.35 * t);  
	C.Matrix[0, 2] = -0.5;
	C.Matrix[1, 0] = -1.5;
	C.Matrix[1, 1] = 40;
	C.Matrix[1, 2] = -1.5;
	C.Matrix[2, 0] = -1.2 + 22.5 * Math.Cos(1.95 * t);  
	C.Matrix[2, 1] = -1.5;
	C.Matrix[2, 2] = 75;    
	// End of Matrix C 

	K.Matrix[0, 0] = 60; 
	K.Matrix[0, 1] = -8;
	K.Matrix[0, 2] = -2 - 332 * Math.Sin(1.37 * t); 
	K.Matrix[1, 0] = -16;
	K.Matrix[1, 1] = 180; 
	K.Matrix[1, 2] = -120; 
	K.Matrix[2, 0] = -20;
	K.Matrix[2, 1] = -100 + 579 * Math.Cos(0.24 * t); 
	K.Matrix[2, 2] = 300; 
	// End of Matrix K 

	// 隨時間變化的系統(狀態)矩陣 A ，A 矩陣為6X6的實數矩陣( m = 3, r = 2)。   
	ReMatrix Mi = ~M;
	A = (-1.0 * Mi * C) & (-1.0 * Mi * K);
	A = A | (I & O );

	Console.WriteLine("  i = {0}    t = {1}  ", i, t); 
	Console.WriteLine("計算特徵值和特徵向量矩陣之前: ");
	// 隨時間變化的系統特徵值矩陣 D ，特徵向量 Q 。 
	D = (new EIG(A)).CxMatrixD;
	Q = (new EIG(A)).CxMatrixQ;
	Console.WriteLine("   ** 計算特徵值和特徵向量矩陣之後 : **");

	// 將時間轉爲複數值。
	CxScalar cxScalar = new CxScalar(t, 0);
	// 隨時間變化的特徵值矩陣(複數)。
	CxVal[i, 0] = new CxMatrix(cxScalar);
	CxVal[i, 1] = D[0, 0];
	CxVal[i, 2] = D[1, 1];
	CxVal[i, 3] = D[2, 2];
	CxVal[i, 4] = D[3, 3];
	CxVal[i, 5] = D[4, 4];
	CxVal[i, 6] = D[5, 5];

	// 隨時間變化的角頻率(實數值轉爲矩陣)。       
	double[,] tMatrix = { { t } };
	ReVal[i, 0] = (ReMatrix)tMatrix;
	ReVal[i, 1] = D[0, 0].Im;
	ReVal[i, 2] = D[1, 1].Im;
	ReVal[i, 3] = D[2, 2].Im;
	ReVal[i, 4] = D[3, 3].Im;
	ReVal[i, 5] = D[4, 4].Im;
	ReVal[i, 6] = D[5, 5].Im;

}

Console.WriteLine("\n***  時間和特徵值(有六組)，共有七組複數值  ***");
Console.WriteLine("\n{0}\n\n", new PR(CxVal));

Console.WriteLine("\n ***  特徵值矩陣的虛數值即角頻率  ***\n");
Console.WriteLine("         時間 t     ....   六個角頻率  " );  
Console.WriteLine("\n{0}\n", new PR(ReVal));

// 轉爲序列方式，使用python程式繪圖。
Console.WriteLine("\n時間序列:   t\n{0}\n", new PR4(ReVal, 0));
Console.WriteLine("\n角頻率序列:w0\n{0}\n", new PR4(ReVal, 1));
Console.WriteLine("\n角頻率序列:w1\n{0}\n", new PR4(ReVal, 2));
Console.WriteLine("\n角頻率序列:w2\n{0}\n", new PR4(ReVal, 3));
Console.WriteLine("\n角頻率序列:w3\n{0}\n", new PR4(ReVal, 4));
Console.WriteLine("\n角頻率序列:w4\n{0}\n", new PR4(ReVal, 5));
Console.WriteLine("\n角頻率序列:w5\n{0}\n", new PR4(ReVal, 6));  


		}
	}
}
