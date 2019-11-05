# -*- coding: utf-8 -*-
"""
Created on Tue Oct 22 15:42:58 2019

@author: RHuang3
"""

import requests
import pandas as pd
import datetime as dt
import os
from bs4 import BeautifulSoup
import re


'''
空白預設抓上市櫃 

未上市上櫃公開發行 strMode=1
上市 strMode=2
上市上櫃債券 strMode=3
上櫃 strMode=4
興櫃 strMode=5
期貨及選擇權 strMode=6
開放式證券投資信託基金 strMode=7
未公開發行之創櫃板證券 strMode=8
買賣黃金現貨 strMode=9
外幣計價可轉換定期存單 strMode=10 (空白)
'''

markets = { 'tse' : { 'Name' : '上市股票' , 'Value' : '2'} , 'otc' : { 'Name' : '上櫃股票' , 'Value' : '4'} , 'StockQ' : { 'Name' : 'StockQ' , 'Value' : 'Q'}} 
def ClearData():
    ex_7_day = dt.date.today() - dt.timedelta(days=7)  
    for file in os.listdir("."):
       if(file.endswith(".json") or file.endswith(".log")):
           filePath = os.path.join(".",file)
           modifiedDate = dt.datetime.fromtimestamp(os.path.getmtime(filePath)).date()
           if(modifiedDate < ex_7_day):
               os.remove(filePath)

def getPath(mkt):
    d = dt.date.today()
    return "StockInfo_{market}_{date}.json".format(market=mkt,date=d.strftime("%Y%m%d"))

def getStockList(stockType=""):   
    
    ClearData()
    
    mkt = markets.copy()
    if stockType != "":
        for key,value in markets.items():
            if value['Value'] not in stockType:
                mkt.pop(key)
    
    stock_df = pd.DataFrame()
    for mktKey in mkt:
        path = getPath(mktKey)
        if os.path.isfile(path) == False:
            CrawlerStockInfo(mkt[mktKey]['Value'],path)
        
        if(stock_df.empty):
            stock_df = pd.read_json(path)
        else:
            stock_df = pd.concat([stock_df,pd.read_json(path)])
            
    return stock_df.to_json(force_ascii=False ,orient='records')   

def CrawlerStockInfo(mktValue,path):
    url = ""
    df = pd.DataFrame()
    if(mktValue =='Q'):
        url = "http://www.stockq.org/"
        resp = requests.get(url)
        df = GetStockQProductInfo(resp.text)
    else:
        url = "http://isin.twse.com.tw/isin/C_public.jsp?strMode={market}".format(market=mktValue)
        resp = requests.get(url)
        df = GetTWSEStockInfo(mktValue,resp.text)
    return df.to_json(path,force_ascii=False ,orient='records')  

def GetTWSEStockInfo(mktValue,html_content):
    df = pd.read_html(html_content)[0]

     #設定columns
    df.columns = df.iloc[0]      
    #刪除掉na
    df = df.dropna(thresh=3, axis=0).dropna(thresh=3, axis=1)
    
    #只篩選股票和ETF
    prefixes = ['ES','CE'] 
    df = df[df['CFICode'].str.startswith(tuple(prefixes))]
    
    df = df.loc[:,["有價證券代號及名稱","市場別"]]
    df.rename(columns={"市場別":"Exchange"},inplace=True)
    df['Exchange'] = df['Exchange'].replace('上市','tse').replace('上櫃','otc')
 
    if(mktValue =="2"):
        df[["StockNo","StockName","None"]]=df.有價證券代號及名稱.str.split(expand=True)
    else:
        df[["StockNo","StockName"]]=df.有價證券代號及名稱.str.split(expand=True)        
    
    return df.loc[:,"Exchange":"StockName"]

def GetStockQProductInfo(html_content):
    soup = BeautifulSoup(html_content.replace('\n',''),'lxml')
    column=[]
    data = soup.find_all('tr' , {'class' ,re.compile('^row[1-6]')})
    for d in data:
        for title in d.find_all('a'):
            index = re.split('^/index/+',title['href'])
            if(len(index)>1):
                column.append(['StockQ',re.split('^/index/+',title['href'])[1].replace('.php',''),title.text])
            else:
                continue

    return pd.DataFrame(column,columns=["Exchange","StockNo","StockName"])


#print(getStockList('2,4'))