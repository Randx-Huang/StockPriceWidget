# StockPriceWidget
利用python抓取TWSE和STockQ指數資料 並顯示於C# winform 上

## 功能說明
* 可以選取台股+ETF(沒有權證&債券) & StockQ中的各市場指數
* 設定更新時間:預設1分鐘(目前控管不可低於30秒)

## 資料來源
* 證交所
* StockQ

## 系統需求
* 本機須安裝Anaconda並已設定環境變數 可透過Python.exe 執行Python檔案
* DevExpress 17.4.1
* Python 3.7
* Python Package
   + BeautifulSoup
   + json
   + re
   + pandas
   + requests

### 需修改功能
* 多檔商品時,顯示ScrollBar
* 可以調整顯示方式
* 設定顏色 (漲:預設紅色,跌:預設綠色)
* 顯示燭圖

---------------------------------------------------------------------------------

### 已知問題
* Build Mode : Realease 時會無法Call到Python
* 需有Reload等待圖示

### 啟動

![程式圖片](https://github.com/Randx-Huang/StockPriceWidget/blob/master/StockPriceWidget/program.PNG)

