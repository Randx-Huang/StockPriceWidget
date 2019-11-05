# -*- coding: utf-8 -*-
"""
Created on Tue Oct 22 13:54:05 2019

@author: RHuang3 
"""
import sys
from stockList import getStockList
from priceInfo import getPriceInfo
import logging
import datetime as dt

if __name__ == '__main__':
    d = dt.date.today()
    logFileName = '.\my_{dd}.log'.format(dd=d.strftime("%Y%m%d"))

    #get or set a Logger
    #不要直接去對logging做設定 不然log下來的資料不會是append會是每一次都被覆蓋
    logger = logging.getLogger(__name__)
    logger.setLevel(logging.DEBUG)
    
    file_handler = logging.FileHandler(logFileName)
    formatter = logging.Formatter('%(asctime)s - %(levelname)s : %(message)s')
    file_handler.setFormatter(formatter)
    logger.addHandler(file_handler) 
    
    logger.info(sys.argv)
    
    try:
        if(len(sys.argv) > 1):
            if(sys.argv[1]=='0'):
                print(getStockList(sys.argv[2]))
                logger.info('call getStockList')
            else:
                print(getPriceInfo(sys.argv[2],sys.argv[3]))
                logger.info('call getInfo')
        
        file_handler.close()
        logger.removeHandler(file_handler)
    except Exception as ex:
        logger.exception(ex.with_traceback)
 
#
for 測試用
#

#print(getStockList())
#print(getPriceInfo('tse_2330.TW|otc_1565.TW|StockQ_KOSPI.Index|tse_2330.TW|StockQ_SHSZ300.Index|otc_00696B.TW','1234564878'))