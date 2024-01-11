<!--     範例       -->

### 
<!--                 
# \[{  \color{Fuchsia}精\;銳\; \color{Purple}矩\;陣\;  \color{Red}計\;算\; \color{Green} 求\;解\;器  }\] 
-->  
![](Images/11-10-01.png) 


<!--         
#### \[{  \color{Fuchsia} 【 \color{Green}  Sharp \; Matrix \; Solver \;  \color{Brown} \iff  \;  \color{Red} S\;M\;S】 }\]  
-->  
![](Images/11-10-02.png)  

---

<!--   
## \[{ \color{Fuchsia} Time-Frequency-Signal \;(Response) \quad Solution  }\] 
-->
![](Images/11-30-01.png)    

 
<!--     ##### \[ using \]   -->
![](Images/11-30-07.png)   


<!--   
## \[  \color{Red} Precisely \; Numerical \; Value \; Computations  \]  
-->  
![](Images/11-30-02.png) 

  
<!--     ##### \[ with \]   -->   
![](Images/11-30-08.png) 

<!--   
## \[{ \color{Green} Real \; \color{Red} And \; \color{magenta} Complex \quad \; \color{Brown} Matrix \;\; Transform  }\] 
-->
![](Images/11-30-03.png)  

  
<!--         ##### \[ Part \; 1 \]    -->   
![](Images/11-30-09.png)   

####

---  

# $時\quad頻\quad數\quad值\quad計\quad算$   

### $$Precisely \quad Time-Frequency \quad Numerical \quad Computations$$  

#  $微分方程式 :$

### $$M(t) \times \ddot{y}_h(t) + C(t) \times \dot{y}_h(t) + K(t) \times y_h(t) = d_h$$  

## $$由齊次微分方程式，得到\quad \ddot{y}_h(t)、\dot{y}_h(t)、y_h(t)$$  

### $$M(t) \times \ddot{y}_p(t) + C(t) \times \dot{y}_p(t) + K(t) \times y_p(t) = f(t)$$  

## $$由非齊次微分方程式，得到\quad \ddot{y}_p(t)、\dot{y}_p(t)、y_p(t)$$   

## $通\qquad解 ：$ 

## 
$$
\begin{bmatrix}
\dot{y}(t) \\\\ y(t)
\end{bmatrix} =
\begin{bmatrix}
\dot{y}_h(t) \\\\ y_h(t)
\end{bmatrix} + 
\begin{bmatrix}
\dot{y}_p(t) \\\\ y_p(t)
\end{bmatrix}
$$

---  

>  ***空間多自由度、且多階的時間函數、齊次微分方程式：M(t) * yh''(t) + C(t) * yh'(t) + K(t) * yh(t) = dh，使用友矩陣(Companion Matrix)的方法，求得系統或狀態矩陣 A(t)，再求得 A(t) * Q(t) = Q(t) * D(t)，其中Q（t）是特徵向量矩陣，D（t）是特徵值矩陣，稱此法為實數與複數矩陣轉換（ Real And Complex Matrix Transform ），本求解法可對應於 Laplace、 Fourier、 Z Transform 或是捲積積分法等等。隨時間變化的角頻率（w）是系統矩陣 A（t）之複數特徵值的虛數值，隨時間變化的模態，是系統矩陣 A（t）的特徵向量。D（t）和Q（t）為系統的潛在特性，並在系統受到外力時，才會顯現出來。若要求得系統的訊號響應值[Signal Response]，應由實際量測的初始值或是邊界值，求得複數係數向量dh，再依據如下推導的公式求得。有關初始值和邊界值分別參見App_6J和App_6M儲存庫，而相關的推導公式和所顯示的數學矩陣方程式，如以下所示的矩陣表示式，其中D為複數特徵值矩陣，Q為複數特徵向量矩陣（模態），Qi為Q之逆矩陣，Hexp(D, Q, t)和dh分別爲複數矩陣和複數向量。***   

## 

$$
\begin{bmatrix}
\dot{y}_h(t) \\\\ y_h(t)
\end{bmatrix} =  Hexp(D, Q, t) \times d_h
$$

#  $實 \quad 例 \quad 計 \quad 算 \quad :$

### $$詳細的【CSharp】程式碼和輸出圖表，請參考本儲存庫中的檔案$$ 

##

$$M(t) = 
\begin{bmatrix}
19 & -1.5 & -2+13.3 \times sin(0.85 \times t) \\\\ 
-1 & 15 & 0 \\\\ 
-10-2.7 \times cos(1.3 \times t) & -3 & 27  
\end{bmatrix}
$$  
 
###

$$K(t) = 
\begin{bmatrix}
60 & -8 & -2-332 \times sin(1.37 \times t) \\\\ 
-16 & 180 & -120 \\\\ 
-20 & -100+579 \times cos(0.24 \times t) & 300 
\end{bmatrix}
$$  

###

$$C(t) = 
\begin{bmatrix}
35 & -1-13.2 \times sin(0.35 \times t) & -0.5 \\\\ 
-1.5 & 40 & -1.5 \\\\ 
-1.2+22.5 \times cos(1.95 \times t) & -1.5 & 75 
\end{bmatrix}
$$  

#    

$$A(t) = 
\begin{bmatrix} 
-M_i(t) \times C(t) & -M_i(t) \times K(t) \\\\ I & O 
\end{bmatrix}
$$

###  $$A(t) \times Q(t) = Q(t) \times D(t) \quad  => \quad A(t) = Q(t) \times D(t) \times Q_i(t)$$  

### 

$$
\begin{bmatrix} 
\ddot{y}_h(t) \\\\ \dot{y}_h(t) 
\end{bmatrix} = A(t) \times 
\begin{bmatrix} 
\dot{y}_h(t) \\\\ y_h(t) 
\end{bmatrix}
$$

### 

$$
\begin{bmatrix} 
\dot{y}_h(t) \\\\ y_h(t) 
\end{bmatrix} = Hexp(D, Q, t)  \times d
$$

### 

$$
\begin{bmatrix}
\dot{y}(t) \\\\ y(t) 
\end{bmatrix} = 
\begin{bmatrix} 
\dot{y}_h(t) \\\\ y_h(t) 
\end{bmatrix} + 
\begin{bmatrix} 
\dot{y}_p(t) \\\\ y_p(t) 
\end{bmatrix}
$$

##  

--- 

# 本人初淺的見解如下 ： 

### **時頻數值計算，因爲每一段時間（可能是一秒或是千分之一秒或是百萬之一秒），系統都在變動，也就是相對的頻率都在變動。** 

### **實際時頻數值計算，必須使用程式碼，才有可能計算出來，使用手算幾乎不可能。**  

### **分析（Analysis）包含轉換（Transform）是方法的闡釋，但最後的目標應是實際精確的數值計算結果。**

###  **動態系統的數值計算，輸入的數據應是實數，輸出的結果也應該是實數，要得到【精確的數值】，中間的運算過程，可能必須使用複數矩陣的計算，此部分也是使人產生困惑的地方，故【從古至今，複數矩陣的數學理論，似乎無法處理此問題，唯有使用程式碼，並作實際的計算來解決】。** 

##

---  

![](Images/name_card.png)  

##
##
