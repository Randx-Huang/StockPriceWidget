# -*- coding: utf-8 -*-
"""
Created on Tue Oct 29 11:36:57 2019

@author: RHuang3
"""

import requests
import json
import pandas as pd
import re
from bs4 import BeautifulSoup

def getPriceInfo(stock,timeinterval):
    
    df = pd.DataFrame()
    
    if('tse' in stock or 'otc' in stock):
        TWSE_Stock = getStockNo(stock,r"^[a-zA-Z_0-9]+.tw$",rtn='string')
        url = "https://mis.twse.com.tw/stock/api/getStockInfo.jsp?ex_ch={stockNo}&json=1&delay=0&_={timeintervalRnd}".format(stockNo=TWSE_Stock,timeintervalRnd=timeinterval)
        resp = requests.get(url)
        if(resp.status_code==200):
            respJson = json.loads(resp.text.replace('\r','').replace('\n',''))
            df = pd.DataFrame(respJson['msgArray'])
            df['y'] =  df['y'].astype(float)
            df['z'] =  df['z'].astype(float)
            df['Point'] = df['z']- df['y']
            df['y'] = round((df["z"]/df["y"] - 1) *100 ,2)
            df = df.loc[:,["ex","c","n","ch","z","y","Point"]]
            df = df.rename(columns={"ex":"Exchange","c":"StockNo","n":"StockName","ch":"StockNoWithMarket","z":"ClosingPrice","y":"Change"})
    
    if('StockQ' in stock):
        StockQ_list = getStockNo(stock,r"^[a-zA-Z_0-9]+.index$",rtn='list')
        url = 'http://www.stockq.org/'
        req = requests.get(url)
        if(req.status_code == 200):
            soup = BeautifulSoup(req.text.replace('\n',''),'lxml')
            data= []
            for index in StockQ_list: #StockQ_KOSPI.Index
                index = index.replace('StockQ_','')
                i = index.split('.')
                pattern = '/{productType}/{productNo}.php'.format(productType=i[1],productNo=i[0])
                tr = soup.find('a',{'href':re.compile(pattern)}).find_parent('tr') 
                name = tr.select("td:nth-of-type(1)")[0].get_text(strip=True)
                closingPrice = float(tr.select("td:nth-of-type(2)")[0].get_text(strip=True))
                point = float(tr.select("td:nth-of-type(3)")[0].get_text(strip=True).replace('%',''))
                change = float(tr.select("td:nth-of-type(4)")[0].get_text(strip=True).replace('%',''))
                data.append(['StockQ',i[0],name,"{n}.{m}".format(n=i[0],m=i[1]),closingPrice,change,point])
               
            df2 = pd.DataFrame(data,columns=['Exchange','StockNo','StockName','StockNoWithMarket','ClosingPrice','Change','Point'])

            if(df.empty):
                df = df2
            else:
                df = df.append(df2)

    return df.to_json(force_ascii=False,orient='records')
   
def getStockNo(string,patten,rtn='string'):
    r = re.compile(patten)
    newlist = list(filter(r.match, string.split('|')))
    sep = "|"
    if rtn == 'string':
        return sep.join(newlist)
    else:
        return newlist
    
#print(getPriceInfo('tse_2317.tw|StockQ_AS30.index|StockQ_SHCOMP.index','1234564878'))